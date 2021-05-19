using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class ProblematicControllerTest
    {

        private Mock<IProblematicService> mockProblematicService;
        private ProblematicController problematicController ;
        private List<Problematic> problematics;
        private Problematic problematic;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockProblematicService=new Mock<IProblematicService>(MockBehavior.Strict);
            problematicController = new ProblematicController(mockProblematicService.Object);
            problematics = new List<Problematic>();
            problematic = new Problematic();
        }
        
        [TestMethod]
        public void TestGetAllProblematics()
        {
            mockProblematicService.Setup(m => m.GetProblematics()).Returns(this.problematics);
            var result = problematicController.GetAll();
            var okResult = result as OkObjectResult;
            var problematicsValue = okResult.Value;
            Assert.AreEqual(this.problematics,problematicsValue);
        }
        
        [TestMethod]
        public void TestGetProblematicByName()
        {
            
            mockProblematicService.Setup(m => m.GetProblematicByName("Estres")).Returns(this.problematic);
            var result = problematicController.GetProblematicByName("Estres");
            var okResult = result as OkObjectResult;
            var problematicValue = okResult.Value;
            Assert.AreEqual(this.problematic,problematicValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundProblematic))]
        public void TestNoGetProblematicByName()
        {
            mockProblematicService.Setup(m => m.GetProblematicByName("Estres")).Throws(new NotFoundProblematic());
            problematicController.GetProblematicByName("Estres");
        }
        
        [TestMethod]
        public void TestGetProblematicById()
        {
            
            mockProblematicService.Setup(m => m.GetProblematicById(1)).Returns(this.problematic);
            var result = problematicController.GetProblematicById(1);
            var okResult = result as OkObjectResult;
            var problematicValue = okResult.Value;
            Assert.AreEqual(this.problematic,problematicValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId))]
        public void TestNoGetProblematicById()
        {
            mockProblematicService.Setup(m => m.GetProblematicById(1)).Throws(new NotFoundId());
            problematicController.GetProblematicById(1);
        }
    }
}