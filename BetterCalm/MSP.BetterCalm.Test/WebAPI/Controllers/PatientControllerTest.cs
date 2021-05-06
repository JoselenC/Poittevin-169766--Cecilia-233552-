using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class PatientControllerTest
    {
        private Mock<IPatientService> mockPatientService;
        private PatientController patientController ;
        private List<Patient> patients;
        private Patient patient;
        private List<Problematic> problematics;
        
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
            Problematic problematic = new Problematic()
            {
                Name = "prob1"
            };
            Problematic problematic2 = new Problematic()
            {
                Name = "prob2"
            };
            Problematic problematic3= new Problematic()
            {
                Name = "prob3"
            };
            problematics = new List<Problematic>() { problematic, problematic2, problematic3 };
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
            mockPatientService.Setup(x => x.SetPatient(patient)).Returns(patient);
            var result = patientController.AddPatient(patient);
            var createdResult = result as CreatedResult;
            var realPatients = createdResult.Value;
            Assert.AreEqual(realPatients, patient);
        }
        
        [TestMethod]
        public void TestGetPatientsById()
        {
            mockPatientService.Setup(
                x => x.GetPatientsById(1)
            ).Returns(patient);
            var result = patientController.GetPatientById(1);
            var okResult = result as OkObjectResult;
            var realPatient = okResult.Value;
            Assert.AreEqual(realPatient, patient);
            mockPatientService.VerifyAll();

        }
        
        [TestMethod]
        public void TestScheduleMeeting()
        {
            
            Psychologist psychologist = new Psychologist()
            {
                Name = "psyco1",
                Problematics = problematics
            };
            ScheduleMeetingDto scheduleMeetingDto = new ScheduleMeetingDto()
            {
                Patient = patient,
                Problematic = problematics[0]
            };
            Meeting expectedMeeting = new Meeting()
            {
                DateTime = DateTime.Today,
                Patient = patient,
                Psychologist = psychologist,
            };
            mockPatientService.Setup(
                x => x.ScheduleNewMeeting(patient, problematics[0])
                ).Returns(expectedMeeting);

            var result = patientController.ScheduleMeeting(scheduleMeetingDto);
            var createdResult = result as CreatedResult;
            var realMeeting = createdResult.Value;
            Assert.AreEqual(expectedMeeting, realMeeting);
        }
        
                        
        [TestMethod]
        public void TestDeletePatient()
        {
            mockPatientService.Setup(x => x.DeletePatientById(patient.Id));
            var result = patientController.DeletePatientById(patient.Id);
            var createdResult = result as OkObjectResult;
            var realPsycho = createdResult.Value;
            Assert.AreEqual("Entity removed", realPsycho);
            mockPatientService.VerifyAll();
        }
        
        [TestMethod]
        public void TestUpdatePatientById()
        {
            mockPatientService.Setup(
                x => x.UpdatePatient(patient, patient.Id)
            ).Returns(patient);
            var result = patientController.UpdatePatient(patient, patient.Id);
            var createdResult = result as OkObjectResult;
            var realPsycho = createdResult.Value;
            Assert.AreEqual(realPsycho, patient);
        }
    }
}