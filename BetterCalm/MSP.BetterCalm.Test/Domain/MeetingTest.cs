using System;
using System.Collections.Generic;
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
        public void GetSetDateTime()
        {
            DateTime datetime = new DateTime(1993, 7, 15);
            Meeting meeting = new Meeting()
            {
                DateTime = datetime
            };
            Assert.AreEqual(meeting.DateTime, datetime);
        }
    }
}