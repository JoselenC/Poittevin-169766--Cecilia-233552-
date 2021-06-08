using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class LoginControllerTest
    {
        private Mock<IAdministratorService> mockAdministratorService;
        private LoginController loginController;
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
            LoginDto loginDto = new LoginDto()
            {
                email = "me@email.com",
                password = "strongPass",
                token = "LoggedToken"
            };
            mockAdministratorService.Setup(
                x => x.Login(loginDto.email, loginDto.password)
            ).Returns("LoggedToken");
            var result = loginController.Login(loginDto);
            var okResult = result as OkObjectResult;
            var realLoginDto = okResult.Value;
            Assert.AreEqual(realLoginDto, loginDto);
        }
    }
}