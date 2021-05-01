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

        private Patient patient;
        private Problematic problematic;
        private Psychologist psychologist;

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
            
            patient = new Patient()
            {
                Name = "Patient1"
            };
            problematic = new Problematic()
            {
                Name = "problem1"
            };
            psychologist = new Psychologist()
            {
                Name = "psychologist1",
                Problematics = new List<Problematic>(){problematic}
            };

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
            service.AddPatient(patient);
            patientMock.VerifyAll();
        }

        private List<Meeting> GetMeetingsForDays(int amountDays)
        {
            List<Meeting> meetings = new List<Meeting>();

            for (int i = 0; i < amountDays; i++)
            {
                List<Meeting> fullDayMeetings = new List<Meeting>()
                {
                    new Meeting(){DateTime = new DateTime(1993,7,19).AddDays(i)},
                    new Meeting(){DateTime = new DateTime(1993,7,19).AddDays(i)},
                    new Meeting(){DateTime = new DateTime(1993,7,19).AddDays(i)},
                    new Meeting(){DateTime = new DateTime(1993,7,19).AddDays(i)},
                    new Meeting(){DateTime = new DateTime(1993,7,19).AddDays(i)},
                };
                meetings.AddRange(fullDayMeetings);
            }

            return meetings;
        }
        
        [TestMethod]
        public void TestScheduleNewMeetingOnNextWeek()
        {
            Psychologist BusyPsychologist = new Psychologist()
            {
                Name = "BusyPerson",
                Meetings = GetMeetingsForDays(1),
                Problematics = new List<Problematic>(){problematic}
            };
            DateTime nextDayMeeting = BusyPsychologist.GetDayForNextMeetingOnWeek(DateTime.Today);
            Meeting expectedMeeting = new Meeting()
            {
                DateTime =nextDayMeeting,
                Patient = patient,
                Psychologist = BusyPsychologist
            };
            psychologistMock.Setup(
                x => 
                    x.Get()
            ).Returns(new List<Psychologist>(){BusyPsychologist});
            Meeting actualMeeting = service.ScheduleNewMeeting(patient, problematic);
            Assert.AreEqual(expectedMeeting, actualMeeting);
            psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestScheduleNewMeetingWithOlderPsychology()
        {
            Psychologist newBusyPsychologist = new Psychologist()
            {
                Name = "BusyPerson",
                Meetings = GetMeetingsForDays(1),
                CreationDate = DateTime.Today,
                Problematics = new List<Problematic>(){problematic}
            };
            Psychologist oldBusyPsychologist = new Psychologist()
            {
                Name = "BusyPerson",
                Meetings = GetMeetingsForDays(1),
                CreationDate = DateTime.Today.AddDays(-2),
                Problematics = new List<Problematic>(){problematic}
            };
            DateTime nextDayMeeting = oldBusyPsychologist.GetDayForNextMeetingOnWeek(DateTime.Today);
            Meeting expectedMeeting = new Meeting()
            {
                DateTime =nextDayMeeting,
                Patient = patient,
                Psychologist = oldBusyPsychologist
            };
            psychologistMock.Setup(
                x => 
                    x.Get()
            ).Returns(new List<Psychologist>(){newBusyPsychologist, oldBusyPsychologist});
            Meeting actualMeeting = service.ScheduleNewMeeting(patient, problematic);
            Assert.AreEqual(expectedMeeting, actualMeeting);
            psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestScheduleNewMeetingOn2NextWeeks()
        {
            Psychologist BusyPsychologist = new Psychologist()
            {
                Name = "BusyPerson",
                Meetings = GetMeetingsForDays(14),
                Problematics = new List<Problematic>(){problematic}
            };
            DateTime nextDayMeeting = BusyPsychologist.GetDayForNextMeetingOnWeek(DateTime.Today);
            Meeting expectedMeeting = new Meeting()
            {
                DateTime =nextDayMeeting,
                Patient = patient,
                Psychologist = BusyPsychologist
            };
            psychologistMock.Setup(
                x => 
                    x.Get()
            ).Returns(new List<Psychologist>(){BusyPsychologist});
            Meeting actualMeeting = service.ScheduleNewMeeting(patient, problematic);
            Assert.AreEqual(expectedMeeting, actualMeeting);
            psychologistMock.VerifyAll();
        }

    }
}