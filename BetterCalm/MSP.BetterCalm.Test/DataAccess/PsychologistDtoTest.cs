using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

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
        public void GetSetUserId()
        {
            PsychologistDto psychologist = new PsychologistDto
            {
                UserDtoId = 11
            };
            Assert.AreEqual(11, psychologist.UserDtoId);
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
    }
}