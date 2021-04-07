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
    public class SongControllerTest
    {
        private Mock<ISongLogic> mockSongService;
        private SongController songController ;
        private List<Song> songs;
        private Song song;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockSongService=new Mock<ISongLogic>(MockBehavior.Strict);
            songController = new SongController(mockSongService.Object);
            songs = new List<Song>();
            song = new Song();
        }
        
        [TestMethod]
        public void TestGetAllSongs()
        {
            mockSongService.Setup(m => m.GetSongs()).Returns(this.songs);
            var result = songController.GetAll();
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(this.songs,songsValue);
        }
        
        [TestMethod]
        public void TestGetSongByName()
        {
            mockSongService.Setup(m => m.GetSongsByName("Stand by me")).Returns(songs);
            var result = songController.GetSongByName("Stand by me");
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        public void TestGetSongByAuthorName()
        {
            mockSongService.Setup(m => m.GetSongsByAuthor("John Lennon")).Returns(songs);
            var result = songController.GetSongByAuthor("John Lennon");
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        public void TestCreateSong()
        {
            Song songToAdd = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.SetSong(songToAdd));
            songController.CreateSong(songToAdd);
            mockSongService.Setup(m => m.GetSongs()).Returns(songs);
            var result = songController.GetAll();
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        public void TestGetSongByCategoryNAme()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song songToAdd = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.SetSong(songToAdd));
            songController.CreateSong(songToAdd);
            mockSongService.Setup(m => m.GetSongsByCategoryName("Dormir")).Returns(songs);
            var result = songController.GetSongByCategoryName("Dormir");
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        public void TestGetSongByNAmeAndAuthor()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song songToAdd = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.SetSong(songToAdd));
            songController.CreateSong(songToAdd);
            mockSongService.Setup(m => m.GetSongByNameAndAuthor("Stand by me","John Lennon")).Returns(song);
            var result = songController.GetSongByAuthorAndName("Stand by me","John Lennon");
            var okResult = result as OkObjectResult;
            var songValue = okResult.Value;
            Assert.AreEqual(song,songValue);
        }
        
        [TestMethod]
        public void TestDeleteSong()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song songToAdd = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.SetSong(songToAdd));
            songController.CreateSong(songToAdd);
            mockSongService.Setup(m => m.DeleteSong(song));
            var result = songController.DeleteSong(song);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Element removed",value);
        }
        
        [TestMethod]
        public void TestDeleteSongByNameAndAuthor()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song songToAdd = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.SetSong(songToAdd));
            songController.CreateSong(songToAdd);
            mockSongService.Setup(m => m.DeleteSongByNameAndAuthor("Stand by me","John Lennon"));
            var result = songController.DeleteSongByNameAndAuthor("Stand by me","John Lennon");
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Element removed",value);
        }
        
        [TestMethod]
        public void TestUpdateSong()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song songToAdd = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.SetSong(songToAdd));
            mockSongService.Setup(m => m.GetSongByNameAndAuthor("Stand by me","John Lennon")).Returns(song);
            songController.CreateSong(songToAdd);
            mockSongService.Setup(m => m.UpdateSong(song,song));
            var result = songController.UpdateSong("Stand by me","John Lennon",song);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Element Updated",value);
        }
        
    }
}