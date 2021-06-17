using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class ImportDtoTest
    {
        [TestMethod]
        public void GetSetName()
        {
            string importName = "json";
            ImportDto import = new ImportDto();
            import.Name = "json";
            string getImportName = import.Name;
            Assert.AreEqual(importName, getImportName);
        }
        
        [TestMethod]
        public void GetSetPath()
        {
            string pathName = "Path";
            ImportDto path = new ImportDto();
            path.Path = "Path";
            string getImportPath = path.Path;
            Assert.AreEqual(pathName, getImportPath);
        }
    }
}