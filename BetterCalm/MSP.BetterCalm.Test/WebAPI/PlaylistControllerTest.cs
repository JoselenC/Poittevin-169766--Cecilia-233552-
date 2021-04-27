using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class PlaylistControllerTest
    {
        private Mock<IPlaylistService> mockPlaylistService;
        private Mock<ISongService> mocksongService;
        private PlaylistController playlistController ;
        private List<Playlist> playlists;
        private Playlist playlist;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockPlaylistService=new Mock<IPlaylistService>(MockBehavior.Strict);
            mocksongService = new Mock<ISongService>(MockBehavior.Strict);
            playlistController = new PlaylistController(mockPlaylistService.Object,mocksongService.Object);
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
        public void TestGetPlaylistByInvalidName()
        {
            mockPlaylistService.Setup(m => m.GetPlaylistByName("Stand by me")).Throws(new KeyNotFoundException());
            var result = playlistController.GetPlaylistByName("Stand by me") as NotFoundObjectResult;
            Assert.IsNotNull(result);
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
        public void TestGetPlaylistByInvalidCategoryName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistByCategoryName("John Lennon")).Throws(new KeyNotFoundException());
            var result = playlistController.GetPlaylistByCategoryName("John Lennon") as NotFoundObjectResult;
            Assert.IsNotNull(result);
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
        public void TestGetPlaylistByInvalidSongName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistBySongName("John Lennon")).Throws(new KeyNotFoundException());
            var result = playlistController.GetPlaylistBySongName("John Lennon") as NotFoundObjectResult;
            Assert.IsNotNull(result);
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
            mocksongService.Setup(m => m.DeleteSongs(playlistTest.Songs));
            playlistController.CreatePlaylist(playlistTest);
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistsValue = okResult.Value;
            Assert.AreEqual(playlists,playlistsValue);
        }
        
        [TestMethod]
        public void TestCreateInvalidNamePlaylist()
        {
            mockPlaylistService.Setup(m => m.AddPlaylist(playlist)).Throws(new InvalidNameLength());
            mocksongService.Setup(m => m.DeleteSongs(playlist.Songs));
            var result=playlistController.CreatePlaylist(playlist) as ConflictObjectResult;
             Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestCreateInvalidDescriptionPlaylist()
        {
            List<Song> songs = new List<Song>();
         
            mockPlaylistService.Setup(m => m.AddPlaylist(playlist)).Throws(new InvalidDescriptionLength());
            mocksongService.Setup(m => m.DeleteSongs(playlist.Songs));
            var result=playlistController.CreatePlaylist(playlist) as ConflictObjectResult;
            Assert.IsNotNull(result);
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
        
        [TestMethod]
        public void TestNoDeletePlaylist()
        {   
            mockPlaylistService.Setup(m => m.DeletePlaylist(playlist)).Throws(new KeyNotFoundException());
            var result = playlistController.DeletePlaylist(playlist) as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void AddSongToPlaylistTest()
        {
            playlist.Songs = new List<Song>();
            mockPlaylistService.Setup(m => m.UpdatePlaylist(playlist,playlist));
            mockPlaylistService.Setup(m => m.GetPlaylistByName("playlist")).Returns(playlists);
            playlistController.AddSongToPlaylist(new Song(){Name="Let it be"},"playlist");
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistsValue = okResult.Value;
            Assert.AreEqual(playlists,playlistsValue);
        }
      }
}