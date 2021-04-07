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
    public class PatientControllerTest
    {
        private Mock<IPatientService> mockPatientService;
        private PatientController patientController ;
        private List<Patient> patients;
        private Patient patient;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockPatientService = new Mock<IPatientService>(MockBehavior.Strict);
            patientController = new PatientController(mockPatientService.Object);
            patients = new List<Patient>();
            patient = new Patient()
            {
                Name = "Juan"
            };
            patients.Add(patient);
        }

        [TestMethod]
        public void TestGetAllPatients()
        {
            mockPatientService.Setup(x => x.GetPatients()).Returns(patients);
            var result = patientController.GetAll();
            var okResult = result as OkObjectResult;
            var realPatients = okResult.Value;
            Assert.AreEqual(realPatients, patients);
        }
    }
}