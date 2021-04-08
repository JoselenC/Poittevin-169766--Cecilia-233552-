using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AdministratorDtoTest
    {
        [TestMethod]
        public void GetSetAdministratorId()
        {
            AdministratorDto administrator = new AdministratorDto
            {
                AdministratorDtoId = 1
            };
            Assert.AreEqual(1, administrator.AdministratorDtoId);
        }

        [TestMethod]
        public void GetSetUserId()
        {
            AdministratorDto administrator = new AdministratorDto();
            administrator.UserDtoId = 11;
            Assert.AreEqual(11, administrator.UserDtoId);
        }
        
        [TestMethod]
        public void GetSetName()
        {
            AdministratorDto administrator = new AdministratorDto
            {
                Name = "Pedro"
            };
            Assert.AreEqual("Pedro", administrator.Name);
        }
        
        [TestMethod]
        public void GetSetLastName()
        {
            AdministratorDto administrator = new AdministratorDto
            {
                LastName = "Rodriguez"
            };
            Assert.AreEqual("Rodriguez", administrator.LastName);
        }
        
        [TestMethod]
        public void GetSetEmail()
        {
            AdministratorDto administrator = new AdministratorDto
            {
                Email = "my.email@gmail.com"
            };
            Assert.AreEqual("my.email@gmail.com", administrator.Email);
        }
        
        [TestMethod]
        public void GetSetPassword()
        {
            AdministratorDto administrator = new AdministratorDto
            {
                Password = "StrongHashedPass"
            };
            Assert.AreEqual("StrongHashedPass", administrator.Password);
        }
    }
}