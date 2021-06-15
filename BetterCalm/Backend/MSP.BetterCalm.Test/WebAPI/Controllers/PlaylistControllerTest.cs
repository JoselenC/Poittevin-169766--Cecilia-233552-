using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class PlaylistControllerTest
    {
        private Mock<IPlaylistService> mockPlaylistService;
        private Mock<IContentService> mockContentService;
        private PlaylistController playlistController ;
        private List<Playlist> playlists;
        private Playlist playlist;
        private PlaylistDto playlistDto;
        private ContentDto _contentDto;
        [TestInitialize]
        public void InitializeTest()
        {
            mockPlaylistService=new Mock<IPlaylistService>(MockBehavior.Strict);
            mockContentService = new Mock<IContentService>(MockBehavior.Strict);
            playlistController = new PlaylistController(mockPlaylistService.Object);
            playlists = new List<Playlist>();
            playlist = new Playlist(){ Id = 1,Name="playlist",Description = "", 
                Contents = new List<Content>(), UrlImage = "", Categories = new List<Category>()};
            playlistDto = new PlaylistDto()
            {
                Id = 1,Name="playlist",Description = "", 
                Contents = new List<Content>(), UrlImage = "", Categories = new List<Category>()
            };
            _contentDto = new ContentDto()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "120s",
                UrlArchive = "",
                UrlImage = "",
                Type="audio",
            };
        }
        
        [TestMethod]
        public void TestGetAllPlaylists()
        {
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(this.playlists);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(this.playlists,playlistValue);
        }
        
        [TestMethod]
        public void TestGetPlaylistByName()
        {
            mockPlaylistService.Setup(m => m.GetPlaylistByName("Stand by me")).Returns(playlists);
            var result = playlistController.GetPlaylistByName("Stand by me");
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlists,playlistValue);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistByCategoryName("John Lennon")).Returns(playlists);
            var result = playlistController.GetPlaylistByCategoryName("John Lennon");
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlists,playlistValue);
        }
        
        [TestMethod]
        public void TestGetPlaylistByContentName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistByContentName("John Lennon")).Returns(playlists);
            var result = playlistController.GetPlaylistByContentName("John Lennon");
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlists,playlistValue);
        }
        
        [TestMethod]
        public void TestCreatePlaylist()
        {
            Playlist playlistTest = new Playlist()
            {
                Contents= new List<Content>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                Contents= new List<Content>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            mockPlaylistService.Setup(m => m.SetPlaylist(playlistTest)).Returns(playlistTest);
            playlistController.CreatePlaylist(playlistTestDto);
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistsValue = okResult.Value;
            Assert.AreEqual(playlists,playlistsValue);
        }
        
        [TestMethod]
        public void TestDeletePlaylist()
        {   
            mockPlaylistService.Setup(m => m.DeletePlaylist(playlist.Id));
            var result = playlistController.DeletePlaylist(playlist.Id);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Element removed",value);
        }

        [TestMethod]
        public void AddContentToPlaylistTest()
        {
            playlist.Contents = new List<Content>();
            Content content = new Content() {Id = 1, Name = "Let it be"};
            mockPlaylistService.Setup(m => m.AssociateContentToPlaylist(1,1)).Returns(playlist);
            mockPlaylistService.Setup(m => m.DeletePlaylist(1));
            mockPlaylistService.Setup(m => m.GetPlaylistById(1)).Returns(playlist);
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            playlistController.AssociateContentToPlaylist(1,1);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistsValue = okResult.Value;
            Assert.AreEqual(playlists,playlistsValue);
        }
        
        [TestMethod]
        public void AddNewContentToPlaylistTest()
        {
            playlist.Contents = new List<Content>();
            Content content = new Content() { Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                UrlImage = ""};
            mockPlaylistService.Setup(m => m.AddNewContentToPlaylist(content,1)).Returns(content);
            mockPlaylistService.Setup(m => m.DeletePlaylist(1));
            mockPlaylistService.Setup(m => m.GetPlaylistById(1)).Returns(playlist);
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            playlistController.AddNewContentToPlaylist(_contentDto,1);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistsValue = okResult.Value;
            Assert.AreEqual(playlists,playlistsValue);
        }
        [TestMethod]
        public void TestGetPlaylistByContentId()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistById(1)).Returns(playlist);
            var result = playlistController.GetPlaylistById(1);
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlist,playlistValue);
        }

        [TestMethod]
        public void TestUpdatePlaylist()
        {   
            mockPlaylistService.Setup(m => m.UpdatePlaylistById(1,playlist));
            var result = playlistController.UpdatePlaylist(1,playlistDto);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
        }
    }
}