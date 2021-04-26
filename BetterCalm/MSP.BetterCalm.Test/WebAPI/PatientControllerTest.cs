using System;
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

        [TestMethod]
        public void TestAddPatient()
        {
            mockPatientService.Setup(x => x.AddPatient(patient));
            var result = patientController.AddPatient(patient);
            var createdResult = result as CreatedResult;
            var realPatients = createdResult.Value;
            Assert.AreEqual(realPatients, patient);
        }
        
        [TestMethod]
        public void TestScheduleMeeting()
        {
            Problematic problematic = new Problematic()
            {
                Name = "prob"
            };
            Psychologist psychologist = new Psychologist()
            {
                Name = "psyco1"
            };
            Meeting expectedMeeting = new Meeting()
            {
                DateTime = DateTime.Today,
                Patient = patient,
                Psychologist = psychologist
            };
            mockPatientService.Setup(
                x => x.ScheduleNewMeeting(patient, problematic)
                ).Returns(expectedMeeting);

            var result = patientController.ScheduleMeeting(patient, problematic);
            var createdResult = result as CreatedResult;
            var realMeeting = createdResult.Value;
            Assert.AreEqual(expectedMeeting, realMeeting);
        }
    }
}