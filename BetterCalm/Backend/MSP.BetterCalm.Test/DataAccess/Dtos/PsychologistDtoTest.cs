using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PsychologistDtoTest
    {
        [TestMethod]
        public void GetSetSongId()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                PsychologistDtoId = 1
            };
            Assert.AreEqual(1, psychologist.PsychologistDtoId);
        }
        
        [TestMethod]
        public void GetSetAddress()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                Address = "House 1234"
            };
            Assert.AreEqual("House 1234", psychologist.Address);
        }
        
        [TestMethod]
        public void GetSetRate()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                Rate = Rates.Cheap
            };
            Assert.AreEqual(Rates.Cheap, psychologist.Rate);
        }
        
        [TestMethod]
        public void GetSetUserId()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                UserDtoId = 11
            };
            Assert.AreEqual(11, psychologist.UserDtoId);
        }
        
        [TestMethod]
        public void GetSetCreationDate()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                CreationDate = new DateTime(1990,1,1)
            };
            Assert.AreEqual(new DateTime(1990,1,1), psychologist.CreationDate);
        }
        
        [TestMethod]
        public void GetSetName()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", psychologist.Name);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", psychologist.LastName);
        }
        
        [TestMethod]
        public void GetSetWorksOnline()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                WorksOnline = true
            };
            Assert.IsTrue(psychologist.WorksOnline);
        }
                
        [TestMethod]
        public void GetSetPsychologistProblematicsDto()
        {
            ICollection<PsychologistProblematicDto> psychologistProblematicDtosproblematics = new List<PsychologistProblematicDto>()
            {
                new PsychologistProblematicDto(){
                    Problematic = new ProblematicDto(),
                    ProblematicId = 1,
                    Psychologist = new PsychologistDto(),
                    PsychologistId = 1
                }
            };
            PsychologistDto psychologist = new PsychologistDto()
            {
                Problematics = psychologistProblematicDtosproblematics
            };
            Assert.AreEqual(psychologist.Problematics, psychologistProblematicDtosproblematics);
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
            PsychologistDto psychologist = new PsychologistDto()
            {
                Meetings = meetings
            };
            Assert.AreEqual(psychologist.Meetings, meetings);
        }
    }
}