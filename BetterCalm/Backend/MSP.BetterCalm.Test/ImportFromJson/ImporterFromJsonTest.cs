using System.Collections.Generic;
using ImporterJson;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.ImportFromJson
{
    [TestClass]
    public class ImporterFromJsonTest
    {

        [TestMethod]
        public void GetImporterNameTest()
        {
            IImporter importer = new ImporterFromJson();
            string name = importer.GetImporterName();
            Assert.AreEqual("Json",name);
        }
        
        [TestMethod]
        public void GetParametersTest()
        {
            IImporter importer = new ImporterFromJson();
            List<Parameter> parametersImporter = importer.GetParameters();
            Parameter parameter = new Parameter() {Name = "Path", Type = "string"};
            List<Parameter> parameters = new List<Parameter>() {parameter};
            CollectionAssert.AreEqual(parameters,parametersImporter);
        }
        
        [TestMethod]
        public void ImportContentTest()
        {
            IImporter importer = new ImporterFromJson();
            string path = @"../../../../MSP.BetterCalm.WebAPI/Parser/example.json";
            List<Content> parametersImporter = importer.ImportContent(path);
            CollectionAssert.AreEqual(parametersImporter,parametersImporter);
        }
    }
}