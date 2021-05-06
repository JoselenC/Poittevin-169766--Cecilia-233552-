using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
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
        private List<Problematic> problematics;
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
            problematics = new List<Problematic>()
            {
                new Problematic() {Name = "Prob1"},
                new Problematic() {Name = "Prob2"},
                new Problematic() {Name = "Prob3"}
            };
            psychologist = new Psychologist()
            {
                Name = "psychologist1",
                Problematics = problematics
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
            service.SetPatient(patient);
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
                Problematics = problematics
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
            Meeting actualMeeting = service.ScheduleNewMeeting(patient, problematics[0]);
            Assert.AreEqual(expectedMeeting, actualMeeting);
            psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyMeetingException))]
        public void TestScheduleNewMeetingAlreadyExistsMeeting()
        {
            Psychologist BusyPsychologist = new Psychologist()
            {
                Name = "BusyPerson",
                Meetings = new List<Meeting>()
                {
                    new Meeting()
                    {
                        DateTime = new DateTime(1993, 7, 15),
                        Patient = patient
                    },
                },
                Problematics = problematics
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
            meetingMock.Setup(
                x => x.Add(expectedMeeting)
            ).Throws(new InvalidOperationException());
            service.ScheduleNewMeeting(patient, problematics[0]);
        }
        
        [TestMethod]
        public void TestScheduleNewMeetingWithOlderPsychology()
        {
            Psychologist newBusyPsychologist = new Psychologist()
            {
                Name = "BusyPerson",
                Meetings = GetMeetingsForDays(1),
                CreationDate = DateTime.Today,
                Problematics = problematics
            };
            Psychologist oldBusyPsychologist = new Psychologist()
            {
                Name = "BusyPerson",
                Meetings = GetMeetingsForDays(1),
                CreationDate = DateTime.Today.AddDays(-2),
                Problematics = problematics
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
            Meeting actualMeeting = service.ScheduleNewMeeting(patient, problematics[0]);
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
                Problematics = problematics
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
            Meeting actualMeeting = service.ScheduleNewMeeting(patient, problematics[0]);
            Assert.AreEqual(expectedMeeting, actualMeeting);
            psychologistMock.VerifyAll();
        }

    }
}