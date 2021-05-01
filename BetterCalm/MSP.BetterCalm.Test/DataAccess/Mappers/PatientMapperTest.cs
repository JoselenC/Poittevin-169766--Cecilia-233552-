using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientMapperTest
    {
        private DbContextOptions<ContextDB> options;
        private  DataBaseRepository<Patient, PatientDto> RepoPatients;
        private DataBaseRepository<Meeting, MeetingDto> RepoMeetings;
        private  Patient patientTest;
        private ContextDB context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(this.options);
            RepoPatients = new DataBaseRepository<Patient, PatientDto>(new PatientMapper(), context.Patients, context);
            RepoMeetings = new DataBaseRepository<Meeting, MeetingDto>(new MeetingMapper(), context.Meeting, context);
            patientTest = new Patient()
            {
                Name = "Juan",
                LastName = "Poittevin",
                BirthDay = new DateTime(1993,7,15),
                Cellphone = "09524123"
            };
            Meeting meeting = new Meeting()
            {
                DateTime = new DateTime(2011, 07, 15),
                Patient = patientTest,
                Psychologist = new Psychologist() {Name = "psyco1"}
            };
            patientTest.Meetings = new List<Meeting>(){meeting};
            RepoMeetings.Add(meeting);
            patientTest = RepoPatients.Add(patientTest);
        }
        
        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Patient patientTest = new Patient()
            {
                Name = "Jose",
                LastName = "Perez",
                Cellphone="092319124",
                BirthDay = new DateTime(1993,07,12),
            };
            patientTest = RepoPatients.Add(patientTest);
            Patient actualPatient = RepoPatients.Find(x => x.Name == "Jose");
            Assert.AreEqual(patientTest, actualPatient);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Patient actualPatient = RepoPatients.Find(x => x.Name == "Juan");
            Assert.AreEqual( patientTest, actualPatient);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Patient actualPatient = RepoPatients.Find(x => x.Name == "Juan");
            actualPatient.Name = "JuanUpdated";
            Patient updatedPatient = RepoPatients.Update(patientTest, actualPatient);
            Assert.AreEqual(actualPatient, updatedPatient);
        }
    }
}