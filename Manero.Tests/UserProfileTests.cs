using Manero.Services;
using Manero.ViewModels;
using Manero.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Manero.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task UpdateUserProfile_ShouldUpdateUserData()
        {
            // Arrange
            var userManagerMock = MockUserManager<UserEntity>();
            var hostingEnvironmentMock = new Mock<IWebHostEnvironment>();

            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var pathToProject = Path.Combine(currentDirectory, "..", "..", "..", "..", "Manero");

            var webRootPath = Path.Combine(pathToProject, "wwwroot");
            hostingEnvironmentMock.Setup(h => h.WebRootPath).Returns(webRootPath);

            var userService = new UserService(userManagerMock.Object, hostingEnvironmentMock.Object);

            var userClaimsPrincipal = new ClaimsPrincipal();

            var formFileMock = new Mock<IFormFile>();

            formFileMock.Setup(f => f.FileName).Returns("annette-hill.jpg");
            formFileMock.Setup(f => f.Length).Returns(1024);
            formFileMock.Setup(f => f.ContentType).Returns("image/jpeg");

            var viewModel = new MyProfileEditViewModel
            {
                Email = "Testmail@example.com",
                Location = "TestLocation",
                PhoneNumber = "1234567890",
                Name = "TestFirstName testLastName",
                ProfileImage = formFileMock?.Object
            };

            userManagerMock.Setup(um => um.GetUserAsync(userClaimsPrincipal))
                .ReturnsAsync(new UserEntity());

            userManagerMock.Setup(um => um.UpdateAsync(It.IsAny<UserEntity>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var successfulUpdateResult = await userService.UpdateUserProfile(viewModel, userClaimsPrincipal);
            var invalidUpdateResult = await userService.UpdateUserProfile(viewModel, null!);
            var userAfterUpdate = await userManagerMock.Object.GetUserAsync(userClaimsPrincipal);

            // Assert
            userManagerMock.Verify(um => um.GetUserAsync(userClaimsPrincipal), Times.AtLeast(1));
            Assert.True(successfulUpdateResult, "Expected successful update");
            userManagerMock.Verify(um => um.UpdateAsync(It.IsAny<UserEntity>()), Times.Once);
            Assert.True(successfulUpdateResult, "Expected successful update");
            Assert.False(invalidUpdateResult, "Expected invalid update");
            Assert.IsType<UserEntity>(userAfterUpdate);
            Assert.NotNull(userManagerMock);
            Assert.NotNull(hostingEnvironmentMock);
            Assert.Equal(viewModel.Name, userAfterUpdate.FirstName + " " + userAfterUpdate.LastName);
            Assert.Equal(viewModel.Email, userAfterUpdate.Email);
            Assert.Equal(viewModel.PhoneNumber, userAfterUpdate.PhoneNumber);
            Assert.Equal(viewModel.Location, userAfterUpdate.Location);
            userManagerMock.Verify(um => um.UpdateAsync(It.IsAny<UserEntity>()), Times.Once);
        }

        private static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            return new Mock<UserManager<TUser>>(store.Object, null!, null!, null!, null!, null!, null!, null!, null!);
        }
    }
}

