using Manero.Contexts;
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Claims;
using Xunit;

namespace Manero.Tests.PaymentTest;

public class PaymentControllerIntegrationTest : IDisposable
{
    private readonly DbContextOptions<DataContext> _dbContextOptions;
    public PaymentControllerIntegrationTest()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }
    public void Dispose()
    {
        // Clean up the in-memory database after each test
        using (var context = new DataContext(_dbContextOptions))
        {
            context.Database.EnsureDeleted();
        }
        GC.SuppressFinalize(this);
    }

    [Fact]
    public void List_ShouldRedirectToAddWhenNoPaymentMethods()
    {
        // Arrange
        var userManagerProviderMock = new Mock<IUserManagerProvider>();
        var paymentServiceMock = new Mock<IPaymentService>();

        // Mock user setup
        var userEntity = new UserEntity(); // Create a user entity
        var userManagerMock = new Mock<UserManager<UserEntity>>(
            Mock.Of<IUserStore<UserEntity>>(), null!, null!, null!, null!, null!, null!, null!, null!);
        userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(userEntity);

        var controller = new PaymentController(paymentServiceMock.Object, userManagerMock.Object, userManagerProviderMock.Object);

        // Act
        var result = controller.List();

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Add", redirectToActionResult.ActionName);
        // Verify that GetUserPaymentMethods was called with the correct user ID
        paymentServiceMock.Verify(provider => provider.GetUserPaymentMethods(It.IsAny<string>()), Times.Once);
    }
    //end of test//
    //next test//
    [Fact]
    public void List_ShouldRedirectToListWhenUserHasPaymentMethod()
    {
        // Arrange
        var userManagerProviderMock = new Mock<IUserManagerProvider>();

        // Mock user setup
        var userEntity = new UserEntity(); // Create a user entity
        var userManagerMock = new Mock<UserManager<UserEntity>>(
            Mock.Of<IUserStore<UserEntity>>(), null!, null!, null!, null!, null!, null!, null!, null!);
        userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(userEntity);

        var paymentServiceMock = new Mock<IPaymentService>();
        // Simulate a scenario where the user has a payment method
        paymentServiceMock.Setup(provider => provider.GetUserPaymentMethods(It.IsAny<string>())).Returns(new List<PaymentMethodEntity> { new PaymentMethodEntity() });

        var controller = new PaymentController(paymentServiceMock.Object, userManagerMock.Object, userManagerProviderMock.Object);

        // Act
        var result = controller.List();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model); // Assuming your view model is being passed to the view
                                          // Verify that GetUserPaymentMethods was called with the correct user ID
        paymentServiceMock.Verify(provider => provider.GetUserPaymentMethods(It.IsAny<string>()), Times.Once);
    }


    //[Fact]
    //public async Task DeleteConfirmed_ShouldRedirectToListWhenDeleteIsSuccessful()
    //{
    //    // Arrange
    //    var userManagerProviderMock = new Mock<IUserManagerProvider>();
    //    var paymentServiceMock = new Mock<IPaymentService>();

    //    // Mock user setup
    //    var userEntity = new UserEntity();
    //    userManagerProviderMock.Setup(ump => ump.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(userEntity);

    //    // Create a mock UserManager using UserManagerMock from Microsoft.AspNetCore.Identity.UI
    //    var userManagerMock = new Mock<UserManager<UserEntity>>(
    //        Mock.Of<IUserStore<UserEntity>>(), null, null, null, null, null, null, null, null);

    //    var controller = new PaymentController(paymentServiceMock.Object, userManagerMock.Object, userManagerProviderMock.Object);

    //    // Mock successful deletion
    //    paymentServiceMock.Verify(provider => provider.DeletePaymentMethodAsync(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once);


    //    // Act
    //    var deleteResult = await controller.DeleteConfirmed(Guid.NewGuid());

    //    // Assert
    //    if (deleteResult is RedirectToActionResult redirectToActionResult)
    //    {
    //        // Success scenario - Check if it's a RedirectToActionResult
    //        Assert.Equal("List", redirectToActionResult.ActionName);
    //    }
    //    else if (deleteResult is NotFoundResult notFoundResult)
    //    {
    //        // Handle the case when user is null (NotFound result)
    //        Assert.IsType<NotFoundResult>(deleteResult);
    //    }
    //    else
    //    {
    //        // Handle unexpected result type
    //        Assert.True(false, $"Unexpected result type: {deleteResult.GetType()}");
    //    }

    //    // Ensure that DeletePaymentMethodAsync was called with the correct parameters
    //    paymentServiceMock.Verify(
    //        provider => provider.DeletePaymentMethodAsync(It.IsAny<Guid>(), It.IsAny<string>()),
    //        Times.Once,
    //        "DeletePaymentMethodAsync should have been called once.");
    //}




}
