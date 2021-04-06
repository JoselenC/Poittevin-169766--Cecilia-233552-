using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    public class PsychologistTest
    {

        [TestMethod]
        public void GetSetAddress()
        {
            Psychologist psychologist = new Psychologist
            {
                Address = "House 1234"
            };
            Assert.AreEqual("House 1234", psychologist.Address);
        }
        
        [TestMethod]
        public void GetSetName()
        {
            Psychologist psychologist = new Psychologist
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", psychologist.Name);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            Psychologist psychologist = new Psychologist
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", psychologist.LastName);
        }
        
        [TestMethod]
        public void GetSetEmail()
        {
            Psychologist psychologist = new Psychologist
            {
                Email = "my.email@gmail.com"
            };
            Assert.AreEqual("my.email@gmail.com", psychologist.Email);
        }
        
        [TestMethod]
        public void GetSetPassword()
        {
            Psychologist psychologist = new Psychologist
            {
                Password = "StrongHashedPass"
            };
            Assert.AreEqual("StrongHashedPass", psychologist.Password);
        }
    }
}