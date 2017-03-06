﻿using System.Web.Mvc;
using Logs.Authentication.Contracts;
using Logs.Factories;
using Logs.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Logs.Web.Tests.AccountControllerTests
{
    [TestFixture]
    public class LogOffTests
    {
        [Test]
        public void TestLogOff_ShouldCallProviderSignOut()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            controller.LogOff();

            // Assert
            mockedProvider.Verify(p => p.SignOut(), Times.Once);
        }

        [Test]
        public void TestLogOff_ShouldReturnRedirectToAction()
        {
            // Arrange
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var controller = new AccountController(mockedProvider.Object, mockedFactory.Object);

            // Act
            var result = controller.LogOff();

            // Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
    }
}
