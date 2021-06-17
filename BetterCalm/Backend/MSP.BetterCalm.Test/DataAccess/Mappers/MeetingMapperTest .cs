using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class MeetingMapperTest
    {
        private DbContextOptions<ContextDb> options;
        private DataBaseRepository<Meeting, MeetingDto> repoMeetings;
        private DataBaseRepository<Problematic, ProblematicDto> repoProb;
        private Meeting meetingTest;
        private Patient patient;
        private Psychologist psychologist;
        private ContextDb context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDb>()
                .EnableSensitiveDataLogging(true)
                .UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDb(options);
            repoMeetings = new DataBaseRepository<Meeting, MeetingDto>(new MeetingMapper(), context.Meeting, context);
            repoProb = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);
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
                Duration = 1,
                Cost = 12,
                Patient = new Patient(){Name = "Patient1"},
                Psychologist = new Psychologist() {Name = "psyco1", Problematics = problematics}
            };
            meetingTest = repoMeetings.Add(meeting);
            patient = meetingTest.Patient;
            psychologist = meetingTest.Psychologist;
        }
        
        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Meeting meetingTest = new Meeting()
            {
                Patient = patient,
                Psychologist = psychologist,
                Duration = 1,
                Cost = 12,
                DateTime = new DateTime(2011,07,16),
            };
            meetingTest = repoMeetings.Add(meetingTest);
            Meeting actualMeeting = repoMeetings.Find(x => 
                x.Patient.Name == meetingTest.Patient.Name && 
                x.Psychologist.Name == meetingTest.Psychologist.Name &&
                x.DateTime == meetingTest.DateTime
                );
            Assert.AreEqual(meetingTest, actualMeeting);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Meeting actualMeeting = repoMeetings.Find(x => 
                x.Patient.Name == meetingTest.Patient.Name && 
                x.Psychologist.Name == meetingTest.Psychologist.Name &&
                x.DateTime == meetingTest.DateTime
            );
            Assert.AreEqual(meetingTest, actualMeeting);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Meeting actualMeeting = repoMeetings.Find(
                x => x.Patient.Id == meetingTest.Patient.Id &&
                     x.Psychologist.PsychologistId == meetingTest.Psychologist.PsychologistId
                );
            actualMeeting.Address = "new Address";
            Meeting updatedMeeting = repoMeetings.Update(meetingTest, actualMeeting);
            Assert.AreEqual(actualMeeting, updatedMeeting);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void GetByIdTest()
        {
            repoMeetings.FindById(1);
        }
    }
}