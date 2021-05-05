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
        private  DataBaseRepository<Patient, PatientDto> repoPatients;
        private DataBaseRepository<Meeting, MeetingDto> repoMeetings;
        private DataBaseRepository<Problematic, ProblematicDto> repoProb;

        private  Patient patientTest;
        private ContextDB context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase("BetterCalmDB").Options;
            context = new ContextDB(options);
            repoPatients = new DataBaseRepository<Patient, PatientDto>(new PatientMapper(), context.Patients, context);
            repoMeetings = new DataBaseRepository<Meeting, MeetingDto>(new MeetingMapper(), context.Meeting, context);
            repoProb = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);

            patientTest = new Patient()
            {
                Name = "Juan",
                LastName = "Poittevin",
                BirthDay = new DateTime(1993,7,15),
                Cellphone = "09524123"
            };
            List<Problematic> problematics = new List<Problematic>()
            {
                new Problematic() {Name = "Prob1"},
                new Problematic() {Name = "Prob2"},
                new Problematic() {Name = "Prob3"}
            };
            problematics[0] = repoProb.Add(problematics[0]);
            problematics[1] = repoProb.Add(problematics[1]);
            problematics[2] = repoProb.Add(problematics[2]);
            Meeting meeting = new Meeting()
            {
                DateTime = new DateTime(2011, 07, 15),
                Patient = patientTest,
                Psychologist = new Psychologist() {Name = "psyco1", Problematics = problematics}
            };
            patientTest.Meetings = new List<Meeting>(){meeting};
            repoMeetings.Add(meeting);
            patientTest = repoPatients.Add(patientTest);
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
            patientTest = repoPatients.Add(patientTest);
            Patient actualPatient = repoPatients.Find(x => x.Name == "Jose");
            Assert.AreEqual(patientTest, actualPatient);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Patient actualPatient = repoPatients.Find(x => x.Name == "Juan");
            Assert.AreEqual( patientTest, actualPatient);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Patient actualPatient = repoPatients.Find(x => x.Name == "Juan");
            actualPatient.Name = "JuanUpdated";
            Patient updatedPatient = repoPatients.Update(patientTest, actualPatient);
            Assert.AreEqual(actualPatient, updatedPatient);
        }
    }
}