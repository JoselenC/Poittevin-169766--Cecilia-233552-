using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientDtoTest
    {
        [TestMethod]
        public void GetSetPatientId()
        {
            PatientDto patient = new PatientDto
            {
                PatientDtoId = 1
            };
            Assert.AreEqual(1, patient.PatientDtoId);
        }
        
        [TestMethod]
        public void GetSetCellphone()
        {
            PatientDto patient = new PatientDto
            {
                Cellphone = "09123981"
            };
            Assert.AreEqual("09123981", patient.Cellphone);
        }
        
        [TestMethod]
        public void GetSetBirthDay()
        {
            PatientDto patient = new PatientDto
            {
                BirthDay = new DateTime(1993, 7, 15)
            };
            Assert.AreEqual(new DateTime(1993,7,15), patient.BirthDay);
        }
        
        [TestMethod]
        public void GetSetUserId()
        {
            PatientDto patient = new PatientDto();
            patient.UserDtoId = 11;
            Assert.AreEqual(11, patient.UserDtoId);
        }
        
        [TestMethod]
        public void GetSetName()
        {
            PatientDto patient = new PatientDto
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", patient.Name);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            PatientDto patient = new PatientDto
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", patient.LastName);
        }
        
        [TestMethod]
        public void GetSetMeetingsDto()
        {
            ICollection<MeetingDto> meetings = new List<MeetingDto>()
            {
                new MeetingDto(){
                    Patient = new PatientDto(),
                    PatientId =  1,
                    Psychologist = new PsychologistDto(),
                    PsychologistId = 1
                }
            };
            PatientDto psychologist = new PatientDto()
            {
                Meetings = meetings
            };
            Assert.AreEqual(psychologist.Meetings, meetings);
        }
    }
}