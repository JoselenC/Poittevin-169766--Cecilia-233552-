using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientServiceTest
    {
        private Mock<ManagerPatientRepository> repoMock;
        private Mock<IRepository<Patient>> patientMock;
        private PatientService service;
        
        private Mock<ManagerPsychologistRepository> psyRepoMock;
        private Mock<IRepository<Psychologist>> psychologistMock;
        
        private Mock<IRepository<Meeting>> meetingMock;
        private Mock<ManagerMeetingRepository> meetingRepoMock;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerPatientRepository>();
            patientMock = new Mock<IRepository<Patient>>();
            repoMock.Object.Patients = patientMock.Object;
            
            psyRepoMock = new Mock<ManagerPsychologistRepository>();
            psychologistMock = new Mock<IRepository<Psychologist>>();
            psyRepoMock.Object.Psychologists = psychologistMock.Object;
            
            meetingRepoMock = new Mock<ManagerMeetingRepository>();
            meetingMock = new Mock<IRepository<Meeting>>();
            meetingRepoMock.Object.Meetings = meetingMock.Object;
            
            service = new PatientService(repoMock.Object, psyRepoMock.Object, meetingRepoMock.Object);

        }

        [TestMethod]
        public void TestGetAll()
        {
            Patient patient = new Patient()
            {
                Name = "Patient1"
            };
            List<Patient> patients = new List<Patient>
            {
                patient
            };
            patientMock.Setup(
                x => x.Get()
            ).Returns(patients);
            List<Patient> actualPatients = service.GetPatients();
            CollectionAssert.AreEqual(patients, actualPatients);
            patientMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestAddPatient()
        {
            Patient patient = new Patient()
            {
                Name = "Patient1"
            };
            patientMock.Setup(
                x => x.Add(patient)
            );
            service.SetPatient(patient);
            patientMock.VerifyAll();
        }
        
        
        [TestMethod]
        public void TestScheduleNewMeeting()
        {
            Patient patient = new Patient()
            {
                Name = "Patient1"
            };
            Psychologist psychologist = new Psychologist()
            {
                Name = "psychologist1"
            };
            Problematic problematic = new Problematic()
            {
                Name = "problem1"
            };
            Meeting expectedMeeting = new Meeting()
            {
                DateTime = DateTime.Today,
                Patient = patient,
                Psychologist = psychologist
            };
            psychologistMock.Setup(
                x => 
                    x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Returns(psychologist);
            Meeting actualMeeting = service.ScheduleNewMeeting(patient, problematic);
            Assert.AreEqual(expectedMeeting, actualMeeting);
            psychologistMock.VerifyAll();
        }

    }
}