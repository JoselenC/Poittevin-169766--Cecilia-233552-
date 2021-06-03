using System.Collections.Generic;
using ImporterXml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.ImportFromXml
{
    [TestClass]
    public class ImporterFromXmlTest
    {

        [TestMethod]
        public void GetImporterNameTest()
        {
            IImporter importer = new ImporterFromXml();
            string name = importer.GetImporterName();
            Assert.AreEqual("Xml",name);
        }
        
        [TestMethod]
        public void GetParametersTest()
        {
            IImporter importer = new ImporterFromXml();
            List<Parameter> parametersImporter = importer.GetParameters();
            Parameter parameter = new Parameter() {Name = "Path", Type = "string"};
            List<Parameter> parameters = new List<Parameter>() {parameter};
            CollectionAssert.AreEqual(parameters,parametersImporter);
        }
        
        [TestMethod]
        public void ImportContentTest()
        {
            IImporter importer = new ImporterFromXml();
            string path = @"../../../../MSP.BetterCalm.WebAPI/Parser/example.Xml";
            List<Content> parametersImporter = importer.ImportContent(path);
            CollectionAssert.AreEqual(parametersImporter,parametersImporter);
        }
    }
}