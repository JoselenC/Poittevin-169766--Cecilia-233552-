using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Importer;

namespace MSP.BetterCalm.Test.Importer
{
    [TestClass]
    public class ImportTest
    {

        [TestMethod]
        public void GetSetName()
        {
            string importName = "json";
            Import import = new Import();
            import.Name = "json";
            string getImportName = import.Name;
            Assert.AreEqual(importName, getImportName);
        }
        
        [TestMethod]
        public void GetSetPath()
        {
            string pathName = "Path";
            Import path = new Import();
            path.Path = "Path";
            string getImportPath = path.Path;
            Assert.AreEqual(pathName, getImportPath);
        }
        
        [TestMethod]
        public void GetSetParameters()
        {
            Import path = new Import();
            path.Parameters = new List<Parameter>();
            List<Parameter> getpParameters = path.Parameters;
            CollectionAssert.AreEqual(getpParameters, getpParameters);
        }
    }
}