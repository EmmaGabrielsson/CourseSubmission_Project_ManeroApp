using Manero.Controllers;
using Manero.Models.Entities;
using Manero.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Manero.Tests
{
    public class LoginTests
    {
        [Fact]
        public async Task Index_Post_ValidModel_ReturnsRedirectToActionResult()
        {
            // Arrange
            var userStoreMock = new Mock<IUserStore<UserEntity>>();
            var userManagerMock = new Mock<UserManager<UserEntity>>(userStoreMock.Object, null!, null!, null!, null!, null!, null!, null!, null!);

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var userClaimsPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<UserEntity>>();
            var signInManagerMock = new Mock<SignInManager<UserEntity>>(
                userManagerMock.Object,
                httpContextAccessorMock.Object,
                userClaimsPrincipalFactoryMock.Object,
                It.IsAny<IOptions<IdentityOptions>>(),
                It.IsAny<ILogger<SignInManager<UserEntity>>>(),
                It.IsAny<IAuthenticationSchemeProvider>(),
                It.IsAny<IUserConfirmation<UserEntity>>()
            );

            var controller = new LoginController(signInManagerMock.Object, userManagerMock.Object);

            var viewModel = new LoginViewModel
            {
                Email = "test@example.com",
                Password = "Test@123",
                RememberMe = false
            };

            userManagerMock.Setup(x => x.FindByEmailAsync(viewModel.Email)).ReturnsAsync(new UserEntity());
            signInManagerMock.Setup(x => x.PasswordSignInAsync(It.IsAny<UserEntity>(), viewModel.Password, viewModel.RememberMe, false))
                            .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            // Act
            var result = await controller.Index(viewModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }
    }
}
