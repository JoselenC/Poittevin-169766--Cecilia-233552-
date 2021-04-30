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
        private Mock<IAudioService> mockAudioService;
        private PlaylistController playlistController ;
        private List<Playlist> playlists;
        private Playlist playlist;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockPlaylistService=new Mock<IPlaylistService>(MockBehavior.Strict);
            mockAudioService = new Mock<IAudioService>(MockBehavior.Strict);
            playlistController = new PlaylistController(mockPlaylistService.Object);
            playlists = new List<Playlist>();
            playlist = new Playlist(){ Id = 1};
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
        public void TestGetPlaylistByAudioName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistByAudioName("John Lennon")).Returns(playlists);
            var result = playlistController.GetPlaylistByAudioName("John Lennon");
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlists,playlistValue);
        }
        
        [TestMethod]
        public void TestGetPlaylistByInvalidAudioName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistByAudioName("John Lennon")).Throws(new KeyNotFoundException());
            var result = playlistController.GetPlaylistByAudioName("John Lennon") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestCreatePlaylist()
        {
            Playlist playlistTest = new Playlist()
            {
                Audios= new List<Audio>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            mockPlaylistService.Setup(m => m.AddPlaylist(playlistTest));
            mockAudioService.Setup(m => m.DeleteAudio(playlistTest.Audios));
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
            mockAudioService.Setup(m => m.DeleteAudio(playlist.Audios));
            var result=playlistController.CreatePlaylist(playlist) as ConflictObjectResult;
             Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestCreateInvalidDescriptionPlaylist()
        {
            List<Audio> Audios = new List<Audio>();
         
            mockPlaylistService.Setup(m => m.AddPlaylist(playlist)).Throws(new InvalidDescriptionLength());
            mockAudioService.Setup(m => m.DeleteAudio(playlist.Audios));
            var result=playlistController.CreatePlaylist(playlist) as ConflictObjectResult;
            Assert.IsNotNull(result);
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
        public void TestNoDeletePlaylist()
        {   
            mockPlaylistService.Setup(m => m.DeletePlaylist(playlist.Id)).Throws(new KeyNotFoundException());
            var result = playlistController.DeletePlaylist(playlist.Id) as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void AddAudioToPlaylistTest()
        {
            playlist.Audios = new List<Audio>();
            Audio audio = new Audio() {Id = 1, Name = "Let it be"};
            mockPlaylistService.Setup(m => m.AssociateAudioToPlaylist(1,1));
            mockPlaylistService.Setup(m => m.DeletePlaylist(1));
            mockPlaylistService.Setup(m => m.GetPlaylistById(1)).Returns(playlist);
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            playlistController.AssociateAudioToPlaylist(1,1);
            var result = playlistController.GetAll();
            var okResult = result as OkObjectResult;
            var playlistsValue = okResult.Value;
            Assert.AreEqual(playlists,playlistsValue);
        }
        
        [TestMethod]
        public void TestGetPlaylistByAudioId()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistById(1)).Returns(playlist);
            var result = playlistController.GetPlaylistById(1);
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlist,playlistValue);
        }
        
        [TestMethod]
        public void TestNoGetPlaylistByAudioId()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistById(1)).Throws(new KeyNotFoundException());
            var result = playlistController.GetPlaylistById(1) as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestUpdatePlaylist()
        {   
            mockPlaylistService.Setup(m => m.UpdatePlaylistById(1,playlist));
            var result = playlistController.UpdatePlaylist(1,playlist);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
        }
        
        [TestMethod]
        public void TestNoUpdatePlaylist()
        {   
            mockPlaylistService.Setup(m => m.UpdatePlaylistById(1,playlist)).Throws(new KeyNotFoundException());
            var result = playlistController.UpdatePlaylist(1,playlist) as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
      }
}