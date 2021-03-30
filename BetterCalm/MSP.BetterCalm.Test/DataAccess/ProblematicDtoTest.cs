using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ProblematicDtoTest
    {
        [TestMethod]
        public void SetGetProblematicDtoId()
        {
            ProblematicDto problematicDto = new ProblematicDto();
            problematicDto.ProblematicDtoID = 1;
            Assert.AreEqual(1, problematicDto.ProblematicDtoID);
        }

        [TestMethod]
        public void SetGetProblematicName()
        {
            ProblematicDto problematicDto = new ProblematicDto();
            problematicDto.Name = "food";
            Assert.AreEqual("food", problematicDto.Name);
        }
        
    }
}