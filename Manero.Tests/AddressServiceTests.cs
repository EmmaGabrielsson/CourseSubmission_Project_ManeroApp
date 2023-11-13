using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Linq.Expressions;
using System.Security.Claims;
using Xunit;

namespace Manero.Tests;

public class AddressServiceTests
{
	
	[Fact]
	public async Task GetUserAddressesByUserIdAsync_ShouldReturnAddressViewModel_ContainingUserAddressesIfExist_WithValidUserId()
	{
		// Arrange
		//------------------------------------------------------------------
		var mockAddressRepository = new Mock<IAdressRepository>();
		var mockUserAddressRepository = new Mock<IUserAdressRepository>();
		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
		var userId = "testUserId";

		mockUserAddressRepository.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<UserAdressEntity, bool>>>()))
			.ReturnsAsync(new List<UserAdressEntity>
			{
				new UserAdressEntity { UserId = userId, AdressId = 1 },
				new UserAdressEntity { UserId = userId, AdressId = 2 }
            });

		mockAddressRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<AdressEntity, bool>>>()))
		.ReturnsAsync(new AdressEntity { Id = 1, StreetName = "TestStreet 1", PostalCode = "12345", City = "TestCity" });

		mockAddressRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<AdressEntity, bool>>>()))
		.ReturnsAsync(new AdressEntity { Id = 2, StreetName = "TestStreet 2", PostalCode = "12345", City = "TestCity" });

		var addressService = new AddressService(
			mockAddressRepository.Object,
			mockUserAddressRepository.Object,
			mockHttpContextAccessor.Object
		);

		// Act
		//------------------------------------------------------------------
		var result = await addressService.GetUserAddressesByUserIdAsync(userId);

		// Assert
		//------------------------------------------------------------------
		Assert.NotNull(result);
		Assert.Equal(userId, result.UserId);
		Assert.NotEmpty(result.Addresses);
		Assert.NotNull(result.UserAddressIds);
		Assert.IsType<List<UserAdressEntity>>(result.UserAddressIds);

	}
	

	[Fact]
	public async Task AddUserAddressAsync_ShouldReturnTrue_IfUserAddressAdded_WithValidViewModel_AndNewAddressCreated()
	{
		// Arrange
		//------------------------------------------------------------------
		var mockAddressRepository = new Mock<IAdressRepository>();
		var mockUserAddressRepository = new Mock<IUserAdressRepository>();
		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
		AdressEntity createdAddress = null!;
		UserAdressEntity createdUserAddress = null!;

		var viewModel = new AddAddressViewModel
		{
			Title = "Test Title",
			StreetName = "TestStreet 1",
			PostalCode = "12345",
			City = "TestCity"
		};

		mockHttpContextAccessor.SetupGet(x => x.HttpContext)
			.Returns(new DefaultHttpContext
			{
				User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, "testUserId")
				}))
			});

		// Mocking create address in the database
		mockAddressRepository.Setup(repo => repo.CreateAsync(It.IsAny<AdressEntity>()))
		.ReturnsAsync(createdAddress = new AdressEntity
		{
			Id = 1,
			StreetName = viewModel.StreetName,
			PostalCode = viewModel.PostalCode,
			City = viewModel.City
		});

		mockUserAddressRepository.Setup(repo => repo.CreateAsync(It.IsAny<UserAdressEntity>()))
		.ReturnsAsync(createdUserAddress = new UserAdressEntity { UserId = "testUserId", AdressId = 1, Title = "Test Title" });

		var addressService = new AddressService(
			mockAddressRepository.Object,
			mockUserAddressRepository.Object,
			mockHttpContextAccessor.Object
		);
		

		// Act
		//------------------------------------------------------------------

		var result = await addressService.AddUserAddressAsync(viewModel);


		// Assert
		//------------------------------------------------------------------
		Assert.True(result);
		Assert.NotNull(createdAddress);
		Assert.NotNull(createdUserAddress);
		Assert.Equal(viewModel.Title, createdUserAddress.Title);
		Assert.Equal(createdAddress.Id, createdUserAddress.AdressId);
		Assert.Equal(viewModel.StreetName, createdAddress.StreetName);
		Assert.Equal(viewModel.PostalCode, createdAddress.PostalCode);
		Assert.Equal(viewModel.City, createdAddress.City);

		mockAddressRepository.Verify(repo => repo.CreateAsync(It.IsAny<AdressEntity>()), Times.Once);
		mockUserAddressRepository.Verify(repo => repo.CreateAsync(It.IsAny<UserAdressEntity>()), Times.Once);

	}


	[Fact]
	public async Task AddUserAddressAsync_ShouldReturnTrue_IfUserAddressAdded_WithExistingAddressInDatabase()
	{

		// Arrange
		//------------------------------------------------------------------
		var mockAddressRepository = new Mock<IAdressRepository>();
		var mockUserAddressRepository = new Mock<IUserAdressRepository>();
		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
		var viewModel = new AddAddressViewModel
		{
			StreetName = "TestStreet 1",
			PostalCode = "12345",
			City = "TestCity"
		};

		mockHttpContextAccessor.SetupGet(x => x.HttpContext)
			.Returns(new DefaultHttpContext
			{
				User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, "testUserId")
				}))
			});

		// Mocking the address already existing in the database
		mockAddressRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<AdressEntity, bool>>>()))
			.ReturnsAsync(new AdressEntity { Id = 1, StreetName = "TestStreet 1", PostalCode = "12345", City = "TestCity" });
		
		mockUserAddressRepository.Setup(repo => repo.CreateAsync(It.IsAny<UserAdressEntity>()))
			.ReturnsAsync(new UserAdressEntity { UserId = "testUserId", AdressId = 1, Title = "Test Title" });


		var addressService = new AddressService(
			mockAddressRepository.Object,
			mockUserAddressRepository.Object,
			mockHttpContextAccessor.Object
		);

		// Act
		//------------------------------------------------------------------
		var result = await addressService.AddUserAddressAsync(viewModel);


		// Assert
		//------------------------------------------------------------------
		Assert.True(result);
		mockAddressRepository.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<AdressEntity, bool>>>()), Times.Once);
		mockUserAddressRepository.Verify(repo => repo.CreateAsync(It.IsAny<UserAdressEntity>()), Times.Once);
	}


	[Fact]
	public async Task RemoveUserAddressAsync_ShouldReturnTrue_IfUserAddressRemovedFromDatabase_AndAddressCheckedIfNotInUse_AddressRemovedToo()
	{
		// Arrange
		//------------------------------------------------------------------
		var mockUserAddressRepository = new Mock<IUserAdressRepository>();
		var mockAdressRepository = new Mock<IAdressRepository>();
		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
		UserAdressEntity existingUserAddress = null!;
		AdressEntity unUsedAddress = null!;
		var viewModel = new AddressViewModel
		{
			UserId = "testUserId",
			RemoveUserAddressId = 1,
			Addresses = new List<AdressEntity> {  new AdressEntity { Id = 1, StreetName = "TestGatan 1", PostalCode = "12345", City = "TestCity" } }
		};

		mockHttpContextAccessor.SetupGet(x => x.HttpContext)
			.Returns(new DefaultHttpContext
			{
				User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, "testUserId")
				}))
			});


		// Mocking the repository methods for GetAsync and DeleteAsync
		mockUserAddressRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<UserAdressEntity, bool>>>()))
			.ReturnsAsync(existingUserAddress = new UserAdressEntity { UserId = "testUserId", AdressId = 1, Title = "Test Title" });

		mockUserAddressRepository.Setup(repo => repo.DeleteAsync(existingUserAddress))
			.ReturnsAsync(true); 

		// Mocking the repository GetAllAsync method
		mockUserAddressRepository.Setup(repo => repo.GetAllAsync(It.IsAny<Expression<Func<UserAdressEntity, bool>>>()))
			.ReturnsAsync(new List<UserAdressEntity> {});

		// Mocking the AdressRepository GetAsync and DeleteAsync methods
		mockAdressRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<AdressEntity, bool>>>()))
			.ReturnsAsync(unUsedAddress = new AdressEntity { Id = 1, StreetName = "TestGatan 1", PostalCode = "12345", City = "TestCity" });

		mockAdressRepository.Setup(repo => repo.DeleteAsync(unUsedAddress))
			.ReturnsAsync(true);

		var addressService = new AddressService(
			mockAdressRepository.Object,
			mockUserAddressRepository.Object,
			mockHttpContextAccessor.Object
		);

		// Act
		//------------------------------------------------------------------
		var result = await addressService.RemoveUserAddressAsync(viewModel);


		// Assert
		//------------------------------------------------------------------
		Assert.True(result);
		mockUserAddressRepository.Verify(repo => repo.DeleteAsync(existingUserAddress), Times.Once);
		mockAdressRepository.Verify(repo => repo.DeleteAsync(It.IsAny<AdressEntity>()), Times.Once);
		mockUserAddressRepository.Verify(repo => repo.GetAllAsync(It.IsAny<Expression<Func<UserAdressEntity, bool>>>()), Times.Once);
		mockUserAddressRepository.Verify(repo => repo.GetAsync(It.IsAny<Expression<Func<UserAdressEntity, bool>>>()), Times.Once);

	}

}
