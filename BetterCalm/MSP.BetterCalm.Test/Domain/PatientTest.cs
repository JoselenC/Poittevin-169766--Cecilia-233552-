using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientTest
    {

        [TestMethod]
        public void GetSetCellphone()
        {
            Patient patient = new Patient
            {
                Cellphone = "09123981"
            };
            Assert.AreEqual("09123981", patient.Cellphone);
        }
        
        [TestMethod]
        public void GetSetBirthDay()
        {
            Patient patient = new Patient
            {
                BirthDay = new DateTime(1993, 7, 15)
            };
            Assert.AreEqual(new DateTime(1993,7,15), patient.BirthDay);
        }
        
        [TestMethod]
        public void GetSetName()
        {
            Patient patient = new Patient
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", patient.Name);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            Patient patient = new Patient
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", patient.LastName);
        }
        
        [TestMethod]
        public void GetSetEmail()
        {
            Patient patient = new Patient
            {
                Email = "my.email@gmail.com"
            };
            Assert.AreEqual("my.email@gmail.com", patient.Email);
        }
        
        [TestMethod]
        public void GetSetPassword()
        {
            Patient patient = new Patient
            {
                Password = "StrongHashedPass"
            };
            Assert.AreEqual("StrongHashedPass", patient.Password);
        }
    }
}