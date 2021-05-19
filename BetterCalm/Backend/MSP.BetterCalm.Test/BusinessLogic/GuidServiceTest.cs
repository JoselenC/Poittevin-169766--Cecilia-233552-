using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic;

namespace MSP.BetterCalm.Test
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