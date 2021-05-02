using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;

namespace MSP.BetterCalm.Test.WebAPI
{
    public class LoginControllerTest
    {
        private Mock<IAdministratorService> mockAdministratorService;
        private LoginController loginController ;
        private List<Administrator> administrators;
        private Administrator administrator;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockAdministratorService = new Mock<IAdministratorService>(MockBehavior.Strict);
            loginController = new LoginController(mockAdministratorService.Object);
            administrators = new List<Administrator>();
            administrator = new Administrator()
            {
                Name = "Juan",
                Email = "me@email.com",
                Password = "strongPass"
            };
            administrators.Add(administrator);
        }

        [TestMethod]
        public void TestLoginSuccess()
        {
            mockAdministratorService.Setup(
                x => x.LoginAdministrator()
                ).Returns("LogedToken");
            var result = loginController.GetAll();
            var okResult = result as OkObjectResult;
            var realToken = okResult.Value;
            Assert.AreEqual(realToken, "LogedToken");
        }
    }
}