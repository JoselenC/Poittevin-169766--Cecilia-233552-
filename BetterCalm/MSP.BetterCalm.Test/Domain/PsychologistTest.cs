using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
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
        public void GetSetWorksOnline()
        {
            Psychologist psychologist = new Psychologist
            {
                WorksOnline = true
            };
            Assert.IsTrue(psychologist.WorksOnline);
        }
    }
}