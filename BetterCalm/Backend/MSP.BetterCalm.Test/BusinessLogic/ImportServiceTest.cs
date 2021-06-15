using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer;

namespace MSP.BetterCalm.Test.BusinessLogic
{
    [TestClass]
    public class ImportServiceTest
    {
        
        private Mock<ManagerContentRepository> _repoMock;
        private Mock<ManagerPlaylistRepository> _repoPlaylitMock;
        private Mock<IRepository<Content>> _contentsMock;
        private Mock<IRepository<Playlist>> _playlistMock;
        private ContentService _contentservice;
        private ImportService _importService;
        private PlaylistService _playlistService;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _repoMock = new Mock<ManagerContentRepository>();
            _repoPlaylitMock = new Mock<ManagerPlaylistRepository>();
            _playlistMock= new Mock<IRepository<Playlist>>();
            _contentsMock = new Mock<IRepository<Content>>();
            _repoMock.Object.Contents =  _contentsMock.Object;
            _repoPlaylitMock.Object.Playlists = _playlistMock.Object;
            _playlistService = new PlaylistService(_repoPlaylitMock.Object, _repoMock.Object);
            _contentservice = new ContentService(_repoMock.Object);
            _importService = new ImportService(_contentservice,_playlistService);
        }
        
        [TestMethod]
        public void GetImportersNameTest()
        {
            List<string> importersNames= _importService.GetImportersName();
           List<string> importers = new List<string>() {"Json", "Xml"};
           CollectionAssert.AreEqual(importers,importersNames);
        }
        
        [TestMethod]
        public void GetParametersTest()
        {
            List<Parameter> importersNames= _importService.GetParameters();
            List<Parameter> importers = new List<Parameter>() {new Parameter(){Name="Path", Type="string"}};
            CollectionAssert.AreEqual(importers,importersNames);
        }

        [TestMethod]
        public void ImportContentTest()
        {
            Import import = new Import()
            {
                Name = "Json",
                Parameters = new List<Parameter>() {new Parameter() {Name = "Path", Type = "string"}},
                Path = "../MSP.BetterCalm.WebAPI/Parser/"
            };
            _importService.ImportContent(import);
            
        }
    }
}