using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskManagement.Web.Controllers;
using TaskManagement.Web.Models;

namespace TaskManagement.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly HomeController _homeController = new HomeController();

        [TestMethod]
        public void TestIndex()
        {
            //Arrange
            string viewName = "Index";

            //Act
            ViewResult result = _homeController.Index() as ViewResult;

            //Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TestPrivacy()
        {
            //Arrange
            string viewName = "Privacy";

            //Act
            ViewResult result = _homeController.Privacy() as ViewResult;

            //Assert
            Assert.AreEqual(viewName, result.ViewName);
        }

        [TestMethod]
        public void TestError()
        {
            //Arrange
            ErrorViewModel viewModel = new ErrorViewModel {
                RequestId = "test"
            };
            var request = new Mock<HttpRequest>();
            var httpContext = Mock.Of<HttpContext>(x => x.Request == request.Object);
            _homeController.ControllerContext.HttpContext = httpContext;

            //Act
            ViewResult result = _homeController.Error() as ViewResult;

            //Assert
            Assert.AreEqual(null, result.ContentType);
        }
    }
}
