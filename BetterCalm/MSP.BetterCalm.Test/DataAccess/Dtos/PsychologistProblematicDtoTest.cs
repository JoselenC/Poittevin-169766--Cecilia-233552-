using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PsychologistProblematicDtoTest
    {
        [TestMethod]
        public void GetSetPsychologistDtoId()
        {
            PsychologistProblematicDto psychologistProblematic = new PsychologistProblematicDto
            {
                PsychologistId = 1
            };
            Assert.AreEqual(1, psychologistProblematic.PsychologistId);
        }
        
        [TestMethod]
        public void GetSetProblematicId()
        {
            PsychologistProblematicDto psychologistProblematic = new PsychologistProblematicDto
            {
                ProblematicId = 12
            };
            Assert.AreEqual(12, psychologistProblematic.ProblematicId);
        }
        
        [TestMethod]
        public void GetSetProblematic()
        {
            ProblematicDto problematic = new ProblematicDto()
            {
                Name = "test"
            };
            PsychologistProblematicDto psychologistProblematic = new PsychologistProblematicDto
            {
                Problematic = problematic
            };
            Assert.AreEqual(problematic, psychologistProblematic.Problematic);
        }
        
        [TestMethod]
        public void GetSetPsychologist()
        {
            PsychologistDto psychologist = new PsychologistDto();
            PsychologistProblematicDto psychologistProblematic = new PsychologistProblematicDto
            {
                Psychologist = psychologist
            };
            Assert.AreEqual(psychologist, psychologistProblematic.Psychologist);
        }
    }
}