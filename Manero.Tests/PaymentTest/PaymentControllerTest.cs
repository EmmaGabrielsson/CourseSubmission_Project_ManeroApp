using Manero.Contexts;
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Claims;

namespace Manero.Tests.PaymentTest;

public class PaymentControllerTest : IDisposable
{
    private readonly DbContextOptions<DataContext> _dbContextOptions;

    public PaymentControllerTest()
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
        var paymentServiceMock = new Mock<IPaymentService>();
        paymentServiceMock.Setup(provider => provider.GetUserPaymentMethods(It.IsAny<string>()))
                          .Returns(new List<PaymentMethodEntity>()); // No payment methods

        var userEntity = new UserEntity();
        var userStoreMock = new Mock<IUserStore<UserEntity>>();

        var userManagerMock = new Mock<UserManager<UserEntity>>(userStoreMock.Object, null!, null!, null!, null!, null!, null!, null!, null!);
        userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(userEntity);

        var controller = new PaymentController(paymentServiceMock.Object, userManagerMock.Object);

        // Act
        var result = controller.List();

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Add", redirectToActionResult.ActionName);

        // Verify that GetUserPaymentMethods was called with the correct user ID
        paymentServiceMock.Verify(provider => provider.GetUserPaymentMethods(It.IsAny<string>()), Times.Once);
    }


    [Fact]
    public void List_ShouldRedirectToListWhenUserHasPaymentMethod()
    {
        // Arrange
        var userEntity = new UserEntity();
        // Mock user setup
        var userStoreMock = new Mock<IUserStore<UserEntity>>();

        var userManagerMock = new Mock<UserManager<UserEntity>>(userStoreMock.Object, null!, null!, null!, null!, null!, null!, null!, null!);
        userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(userEntity);

        var paymentServiceMock = new Mock<IPaymentService>();
        paymentServiceMock.Setup(provider => provider.GetUserPaymentMethods(It.IsAny<string>()))
                          .Returns(new List<PaymentMethodEntity> { new PaymentMethodEntity() }); // User has a payment method

        var controller = new PaymentController(paymentServiceMock.Object, userManagerMock.Object);

        // Act
        var result = controller.List();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.NotNull(viewResult.Model);

        // Verify that GetUserPaymentMethods was called with the correct user ID
        paymentServiceMock.Verify(provider => provider.GetUserPaymentMethods(It.IsAny<string>()), Times.Once);
    }


}
