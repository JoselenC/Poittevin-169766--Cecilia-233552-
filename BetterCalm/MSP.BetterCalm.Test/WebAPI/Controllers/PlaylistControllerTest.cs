using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;

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
        private PlaylistDto playlistDto;
        private AudioDto _audioDto;
        [TestInitialize]
        public void InitializeTest()
        {
            mockPlaylistService=new Mock<IPlaylistService>(MockBehavior.Strict);
            mockAudioService = new Mock<IAudioService>(MockBehavior.Strict);
            playlistController = new PlaylistController(mockPlaylistService.Object);
            playlists = new List<Playlist>();
            playlist = new Playlist(){ Id = 1,Name="playlist",Description = "", 
                Audios = new List<Audio>(), UrlImage = "", Categories = new List<Category>()};
            playlistDto = new PlaylistDto()
            {
                Id = 1,Name="playlist",Description = "", 
                Audios = new List<Audio>(), UrlImage = "", Categories = new List<Category>()
            };
            _audioDto = new AudioDto()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "120s",
                UrlAudio = "",
                UrlImage = ""
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
        public void TestGetPlaylistByAudioName()
        {   
            mockPlaylistService.Setup(m => m.GetPlaylistByAudioName("John Lennon")).Returns(playlists);
            var result = playlistController.GetPlaylistByAudioName("John Lennon");
            var okResult = result as OkObjectResult;
            var playlistValue = okResult.Value;
            Assert.AreEqual(playlists,playlistValue);
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
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                Audios= new List<Audio>(),
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
        public void AddNewAudioToPlaylistTest()
        {
            playlist.Audios = new List<Audio>();
            Audio audio = new Audio() { Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""};
            mockPlaylistService.Setup(m => m.AddNewAudioToPlaylist(audio,1)).Returns(audio);
            mockPlaylistService.Setup(m => m.DeletePlaylist(1));
            mockPlaylistService.Setup(m => m.GetPlaylistById(1)).Returns(playlist);
            mockPlaylistService.Setup(m => m.GetPlaylist()).Returns(playlists);
            playlistController.AddNewAudioToPlaylist(_audioDto,1);
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
        public void TestUpdatePlaylist()
        {   
            mockPlaylistService.Setup(m => m.UpdatePlaylistById(1,playlist));
            var result = playlistController.UpdatePlaylist(1,playlistDto);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
        }
    }
}