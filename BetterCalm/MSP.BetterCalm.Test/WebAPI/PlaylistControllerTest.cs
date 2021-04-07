using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class PlaylistControllerTest
    {
        private Mock<IPlaylistLogic> mockPlaylistService;
        private PlaylistController playlistController ;
        private List<Playlist> playlists;
        private Playlist playlist;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockPlaylistService=new Mock<IPlaylistLogic>(MockBehavior.Strict);
            playlistController = new PlaylistController(mockPlaylistService.Object);
            playlists = new List<Playlist>();
            playlist = new Playlist();
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
        public void TestGetPlaylistBySongName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistBySongName("John Lennon")).Returns(playlists);
            var result = playlistController.GetPlaylistBySongName("John Lennon");
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlists,playlistValue);
        }
        
        [TestMethod]
        public void TestCreatePlaylist()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            mockPlaylistService.Setup(m => m.AddPlaylist(playlistTest));
            playlistController.CreatePlaylist(playlistTest);
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistsValue = okResult.Value;
            Assert.AreEqual(playlists,playlistsValue);
        }
        
        [TestMethod]
        public void TestDeletePlaylist()
        {   
            mockPlaylistService.Setup(m => m.DeletePlaylist(playlist));
            var result = playlistController.DeletePlaylist(playlist);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Element removed",value);
        }
        
      }
}