using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AdministratorTest
    {

        [TestMethod]
        public void GetSetName()
        {
            Administrator administrator = new Administrator
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", administrator.Name);
        }
        
        [TestMethod]
        public void GetSetToken()
        {
            Administrator administrator = new Administrator
            {
                Token = "asfdjlkj1234"
            };
            Assert.AreEqual("asfdjlkj1234", administrator.Token);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            Administrator administrator = new Administrator
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", administrator.LastName);
        }
        
        [TestMethod]
        public void GetSetEmail()
        {
            Administrator administrator = new Administrator
            {
                Email = "my.email@gmail.com"
            };
            Assert.AreEqual("my.email@gmail.com", administrator.Email);
        }
        
        [TestMethod]
        public void GetSetPassword()
        {
            Administrator administrator = new Administrator
            {
                Password = "StrongHashedPass"
            };
            Assert.AreEqual("StrongHashedPass", administrator.Password);
        }
    }
}