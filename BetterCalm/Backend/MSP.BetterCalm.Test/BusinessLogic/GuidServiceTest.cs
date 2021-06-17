using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Services;

namespace MSP.BetterCalm.Test.BusinessLogic
{
    [TestClass]
    public class GuidServiceTest
    {
        [TestMethod]
        public void CreationTest()
        {
            GuidService guid = new GuidService();
            Assert.IsInstanceOfType(guid.NewGuid(), typeof(Guid));
        }
        
    }
}