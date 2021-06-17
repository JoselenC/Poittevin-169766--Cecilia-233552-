using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class LoginDtoTest
    {
        [TestMethod]
        public void GetSetEmail()
        {
            string email = "admin@admin.com";
            LoginDto login = new LoginDto();
            login.email = "admin@admin.com";
            Assert.AreEqual(login.email, email);
        }
        
        [TestMethod]
        public void GetSetPassword()
        {
            string email = "pass";
            LoginDto login = new LoginDto();
            login.password = "pass";
            Assert.AreEqual(login.password, email);
        }
        
        [TestMethod]
        public void GetSetToken()
        {
            string token = "token";
            LoginDto login = new LoginDto();
            login.token = "token";
            Assert.AreEqual(login.token, token);
        }
    }
}