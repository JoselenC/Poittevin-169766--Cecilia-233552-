using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class MeetingDtoTest
    {
        
        [TestMethod]
        public void GetSetMeetingAddress()
        {
            MeetingDto meeting = new MeetingDto()
            {
                Address = "My house 1234"
            };
            Assert.AreEqual("My house 1234", meeting.Address);
        }
        
        [TestMethod]
        public void GetSetPsychologistId()
        {
            MeetingDto meeting = new MeetingDto()
            {
                PsychologistId = 1
            };
            Assert.AreEqual(1, meeting.PsychologistId);
        }
        
        [TestMethod]
        public void GetSetPatientId()
        {
            MeetingDto meeting = new MeetingDto
            {
                PatientId = 12
            };
            Assert.AreEqual(12, meeting.PatientId);
        }
        
        [TestMethod]
        public void GetSetPatient()
        {
            PatientDto patient = new PatientDto()
            {
                Name = "test"
            };
            MeetingDto meeting = new MeetingDto
            {
                Patient = patient
            };
            Assert.AreEqual(patient, meeting.Patient);
        }
        
        [TestMethod]
        public void GetSetPsychologist()
        {
            PsychologistDto psychologist = new PsychologistDto();
            MeetingDto meeting = new MeetingDto
            {
                Psychologist = psychologist
            };
            Assert.AreEqual(psychologist, meeting.Psychologist);
        }

        [TestMethod]
        public void GetSetDateTime()
        {
            DateTime dateTime = new DateTime(1993, 7, 15);
            MeetingDto meeting = new MeetingDto()
            {
                DateTime = dateTime
            };
            Assert.AreEqual(dateTime, meeting.DateTime);
        }
        
    }
}