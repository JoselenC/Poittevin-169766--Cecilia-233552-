using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.Importer.Models;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Controllers
{
    [TestClass]
    public class ImportControllerTest
    {
        private Mock<IImportService> mockImportService;
        private ImportController importController ;
        private Mock<ManagerContentRepository> _repoMock;
        private Mock<IRepository<Content>> _contentsMock;
        private ContentService _contentservice;
        [TestInitialize]
        public void InitializeTest()
        {
            mockImportService=new Mock<IImportService>(MockBehavior.Strict);
            importController = new ImportController(mockImportService.Object);
            _repoMock = new Mock<ManagerContentRepository>(MockBehavior.Strict);
            _contentsMock = new Mock<IRepository<Content>>(MockBehavior.Strict);
            _repoMock.Object.Contents =  _contentsMock.Object;
            _contentservice = new ContentService(_repoMock.Object);
        }
        
        [TestMethod]
        public void TestGetParametersTest()
        {
            List<Parameter> importers = new List<Parameter>() {new Parameter(){Name="Path", Type="string"}};
            mockImportService.Setup(m => m.GetParameters()).Returns(importers);
            var result = importController.GetParameters();
            var okResult = result as OkObjectResult;
            var parametersValue = okResult.Value;
            Assert.AreEqual(parametersValue,importers);
        }
        
        [TestMethod]
        public void TestGetNamesTest()
        {
            List<string> importers = new List<string>() {"Json", "Xml"};
            mockImportService.Setup(m => m.GetImportersName()).Returns(importers);
            var result = importController.GetNames();
            var okResult = result as OkObjectResult;
            var parametersValue = okResult.Value;
            Assert.AreEqual(parametersValue,importers);
        }
        
        [TestMethod]
        public void ImportContentsTest()
        {
            List<Parameter> importers = new List<Parameter>() {new Parameter(){Name="Path", Type="string"}};
            mockImportService.Setup(m => m.GetParameters()).Returns(importers);
            Import import = new Import()
            {
                Name = "Json",
                Parameters = new List<Parameter>() {new Parameter() {Name = "Path", Type = "string"}},
                Path = "../MSP.BetterCalm.WebAPI/Parser/"
            };
            ImportDto importDto = new ImportDto()
            {
                Name = "Json",
                Path = "../MSP.BetterCalm.WebAPI/Parser/"
            };
            Content content1 = new Content() {Name = "Stand by me"};
            List<Content> contents = new List<Content>() {content1};
            mockImportService.Setup(m => m.ImportContent(import)).Returns("");
            
        }
    }
}