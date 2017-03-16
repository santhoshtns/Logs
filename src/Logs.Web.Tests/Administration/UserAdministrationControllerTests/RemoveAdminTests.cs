﻿using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Services.Contracts;
using Logs.Web.Areas.Administration.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.Administration.UserAdministrationControllerTests
{
    [TestFixture]
    public class RemoveAdminTests
    {
        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 1)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 2)]
        public void TestRemoveAdmin_ShouldCallAuthProviderAddToRole(string userId, int page)
        {
            // Arrange
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();

            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthenticationProvider.Object);

            // Act
            controller.RemoveAdmin(userId, page);

            // Assert
            mockedAuthenticationProvider.Verify(p => p.RemoveFromRole(userId, It.IsAny<string>()), Times.Once);
        }

        [TestCase("d547a40d-c45f-4c43-99de-0bfe9199ff95", 1)]
        [TestCase("99ae8dd3-1067-4141-9675-62e94bb6caaa", 2)]
        public void TestRemoveAdmin_ShouldReturnRedirectToActionWithCorrectPage(string userId, int page)
        {
            // Arrange
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();

            var controller = new UserAdministrationController(mockedUserService.Object, mockedAuthenticationProvider.Object);

            // Act
            var result = controller.RemoveAdmin(userId, page) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(page, result.RouteValues[nameof(page)]);
        }
    }
}
