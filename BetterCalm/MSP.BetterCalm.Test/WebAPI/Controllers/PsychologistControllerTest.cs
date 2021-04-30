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
    public class PsychologistControllerTest
    {
        private Mock<IPsychologistService> mockPsychologistService;
        private PsychologistController psychologistController ;
        private List<Psychologist> psychologists;
        private Psychologist psychologist;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockPsychologistService = new Mock<IPsychologistService>(MockBehavior.Strict);
            psychologistController = new PsychologistController(mockPsychologistService.Object);
            psychologists = new List<Psychologist>();
            psychologist = new Psychologist()
            {
                PsychologistId = 1,
                Name = "Psyco1"
            };
            psychologists.Add(psychologist);
        }

        [TestMethod]
        public void TestGetAllPsychologists()
        {
            mockPsychologistService.Setup(x => x.GetPsychologists()).Returns(psychologists);
            var result = psychologistController.GetAll();
            var okResult = result as OkObjectResult;
            var realPsychologists = okResult.Value;
            Assert.AreEqual(realPsychologists, psychologists);
        }
        
        [TestMethod]
        public void TestGetPsychologistsById()
        {
            mockPsychologistService.Setup(
                x => x.GetPsychologistsById(1)
            ).Returns(psychologist);
            var result = psychologistController.GetPsychologistById(1);
            var okResult = result as OkObjectResult;
            var realPsychologist = okResult.Value;
            Assert.AreEqual(realPsychologist, psychologist);
        }
        
        [TestMethod]
        public void TestAddPsychologist()
        {
            mockPsychologistService.Setup(x => x.SetPsychologist(psychologist));
            var result = psychologistController.AddPsychologist(psychologist);
            var createdResult = result as CreatedResult;
            var realPsycho = createdResult.Value;
            Assert.AreEqual(realPsycho, psychologist);
        }
        
                
        [TestMethod]
        public void TestDeletePsychologist()
        {
            mockPsychologistService.Setup(x => x.DeletePsychologistById(psychologist.PsychologistId));
            var result = psychologistController.DeletePsychologistById(psychologist.PsychologistId);
            var createdResult = result as OkObjectResult;
            var realPsycho = createdResult.Value;
            Assert.AreEqual("Entity removed", realPsycho);
        }
    }
}