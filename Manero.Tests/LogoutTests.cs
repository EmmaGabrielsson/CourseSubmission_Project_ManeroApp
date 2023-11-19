using System.Security.Claims;
using System.Threading.Tasks;
using Manero.Controllers;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Manero.Tests
{
    public class LogoutTests
    {
        [Fact]
        public async Task Index_WhenUserIsSignedIn_Should_beLoggedOutAndRedirectedToHomeController()
        {
            // Arrange
            var userStoreMock = new Mock<IUserStore<UserEntity>>();
            var userManagerMock = new Mock<UserManager<UserEntity>>(userStoreMock.Object, null!, null!, null!, null!, null!, null!, null!, null!);

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var userClaimsPrincipalFactoryMock = new Mock<IUserClaimsPrincipalFactory<UserEntity>>();

            var httpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "testuser"),
                }, "mock")),
            };
            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContext);

            var signInManagerMock = new Mock<SignInManager<UserEntity>>(
                userManagerMock.Object,
                httpContextAccessorMock.Object,
                userClaimsPrincipalFactoryMock.Object,
                It.IsAny<IOptions<IdentityOptions>>(),
                It.IsAny<ILogger<SignInManager<UserEntity>>>(),
                It.IsAny<IAuthenticationSchemeProvider>(),
                It.IsAny<IUserConfirmation<UserEntity>>()
            );

            signInManagerMock.Setup(x => x.IsSignedIn(It.IsAny<ClaimsPrincipal>())).Returns(true);
            signInManagerMock.Setup(x => x.SignOutAsync()).Returns(Task.CompletedTask);

            var controller = new LogoutController(signInManagerMock.Object);

            // Act
            var result = await controller.Index() as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }
    }
}
