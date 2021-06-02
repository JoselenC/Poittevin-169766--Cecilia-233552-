using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class MeetingTest
    {
        [TestMethod]
        public void GetSetPatient()
        {
            Patient patient = new Patient()
            {
                Name = "Test1"
            };
            Meeting meeting = new Meeting()
            {
                Patient = patient
            };
            Assert.AreEqual(meeting.Patient, patient);
        }
        
        [TestMethod]
        public void GetSetPsychologist()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "Test1"
            };
            Meeting meeting = new Meeting()
            {
                Psychologist = psychologist
            };
            Assert.AreEqual(meeting.Psychologist, psychologist);
        }
        
        [TestMethod]
        public void GetSetMeetingAddress()
        {
            Meeting meeting = new Meeting()
            {
                Address = "Mi casa 1234"
            };
            Assert.AreEqual("Mi casa 1234", meeting.Address);
        }

        [TestMethod]
        public void GetSetDateTime()
        {
            DateTime datetime = new DateTime(1993, 7, 15);
            Meeting meeting = new Meeting()
            {
                DateTime = datetime
            };
            Assert.AreEqual(meeting.DateTime, datetime);
        }
        
        [TestMethod]
        public void HashCodeAddressTest()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "Test1"
            };
            DateTime datetime = new DateTime(1993, 7, 15);
            Patient patient = new Patient()
            {
                Name = "Test1"
            };
            Meeting meeting = new Meeting()
            {
                Psychologist = psychologist,
                DateTime = datetime,
                Patient =patient
            };
            Assert.AreEqual(meeting.GetHashCode(), meeting.GetHashCode());
        }
        
        [TestMethod]
        public void EqualsNull()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "Test1"
            };
            DateTime datetime = new DateTime(1993, 7, 15);
            Patient patient = new Patient()
            {
                Name = "Test1"
            };
            Meeting meeting = new Meeting()
            {
                Psychologist = psychologist,
                DateTime = datetime,
                Patient =patient
            };
            Assert.IsFalse( meeting.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "Test1"
            };
            DateTime datetime = new DateTime(1993, 7, 15);
            Patient patient = new Patient()
            {
                Name = "Test1"
            };
            Meeting meeting = new Meeting()
            {
                Psychologist = psychologist,
                DateTime = datetime,
                Patient =patient
            };
            Assert.IsFalse( meeting.Equals(new Content()));
        }
        
        [TestMethod]
        public void EqualsTest()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "Test1"
            };
            DateTime datetime = new DateTime(1993, 7, 15);
            Patient patient = new Patient()
            {
                Name = "Test1"
            };
            Meeting meeting = new Meeting()
            {
                Psychologist = psychologist,
                DateTime = datetime,
                Patient =patient
            };
            Assert.IsTrue( meeting.Equals(meeting));
        }
    }
}