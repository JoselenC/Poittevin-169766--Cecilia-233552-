using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class MeetingMapperTest
    {
        private DbContextOptions<ContextDB> options;
        private DataBaseRepository<Meeting, MeetingDto> RepoMeetings;
        private Meeting meetingTest;
        private Patient patient;
        private Psychologist psychologist;
        private ContextDB context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>()
                .EnableSensitiveDataLogging(true)
                .UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(options);
            RepoMeetings = new DataBaseRepository<Meeting, MeetingDto>(new MeetingMapper(), context.Meeting, context);

            Meeting meeting = new Meeting()
            {
                DateTime = new DateTime(2011, 07, 15),
                Patient = new Patient(){Name = "Patient1"},
                Psychologist = new Psychologist() {Name = "psyco1"}
            };
            meetingTest = RepoMeetings.Add(meeting);
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
                DateTime = new DateTime(2011,07,16),
            };
            meetingTest = RepoMeetings.Add(meetingTest);
            Meeting actualMeeting = RepoMeetings.Find(x => 
                x.Patient.Name == meetingTest.Patient.Name && 
                x.Psychologist.Name == meetingTest.Psychologist.Name &&
                x.DateTime == meetingTest.DateTime
                );
            Assert.AreEqual(meetingTest, actualMeeting);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Meeting actualMeeting = RepoMeetings.Find(x => 
                x.Patient.Name == meetingTest.Patient.Name && 
                x.Psychologist.Name == meetingTest.Psychologist.Name &&
                x.DateTime == meetingTest.DateTime
            );
            Assert.AreEqual(meetingTest, actualMeeting);
        }
     
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void UpdateTest()
        {
            RepoMeetings.Update(meetingTest, meetingTest);
        }
    }
}