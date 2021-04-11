using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class AdministratorControllerTest
    {
        private Mock<IAdministratorService> mockAdministratorService;
        private AdministratorController administratorController ;
        private List<Administrator> administrators;
        private Administrator administrator;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockAdministratorService = new Mock<IAdministratorService>(MockBehavior.Strict);
            administratorController = new AdministratorController(mockAdministratorService.Object);
            administrators = new List<Administrator>();
            administrator = new Administrator()
            {
                Name = "Juan"
            };
            administrators.Add(administrator);
        }

        [TestMethod]
        public void TestGetAllAdministrators()
        {
            mockAdministratorService.Setup(x => x.GetAdministrators()).Returns(administrators);
            var result = administratorController.GetAll();
            var okResult = result as OkObjectResult;
            var realAdministrators = okResult.Value;
            Assert.AreEqual(realAdministrators, administrators);
        }
        
        [TestMethod]
        public void TestAddAdminstrator()
        {
            mockAdministratorService.Setup(x => x.AddAdministrator(administrator));
            var result = administratorController.AddAdministrator(administrator);
            var createdResult = result as CreatedResult;
            var realAdmin = createdResult.Value;
            Assert.AreEqual(realAdmin, administrator);
        }

    }
}