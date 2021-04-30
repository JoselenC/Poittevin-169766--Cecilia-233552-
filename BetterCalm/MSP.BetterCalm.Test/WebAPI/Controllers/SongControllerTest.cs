﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class SongControllerTest
    {
        private Mock<ISongService> mockSongService;
        private SongController songController ;
        private List<Song> songs;
        private Song song;
        private BetterCalm.WebAPI.Dtos.SongDto songDto;
            
        [TestInitialize]
        public void InitializeTest()
        {
            mockSongService=new Mock<ISongService>(MockBehavior.Strict);
            songController = new SongController(mockSongService.Object);
            songs = new List<Song>();
            song = new Song()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""
            };
            songDto = new BetterCalm.WebAPI.Dtos.SongDto()
            {
                Id = 0,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlAudio = "",
                UrlImage = ""
            };
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
            var result = songController.GetSongsByName("Stand by me");
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetSongByName()
        {
            mockSongService.Setup(m => m.GetSongsByName("Stand by me")).Throws(new KeyNotFoundException());
            var result = songController.GetSongsByName("Stand by me") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestGetSongByAuthorName()
        {
            mockSongService.Setup(m => m.GetSongsByAuthor("John Lennon")).Returns(songs);
            var result = songController.GetSongsByAuthor("John Lennon");
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetSongByAuthorName()
        {
            mockSongService.Setup(m => m.GetSongsByAuthor("John Lennon")).Throws(new KeyNotFoundException());
            var result = songController.GetSongsByAuthor("John Lennon")as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestCreateSong()
        {
            BetterCalm.WebAPI.Dtos.SongDto songToAdd = new BetterCalm.WebAPI.Dtos.SongDto()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "12s",
                UrlAudio = "",
                UrlImage = ""
            };
            Song song = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.AddSong(song));
            songController.CreateSong(songToAdd);
            mockSongService.Setup(m => m.GetSongs()).Returns(songs);
            var result = songController.GetAll();
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength))]
        public void TestNoCreateSongEmptyName()
        {
            Song song = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.AddSong(song)).Throws(new InvalidNameLength());
            songController.CreateSong(songDto);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisSong))]
        public void TestNoCreateSong()
        {
            Song song = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.AddSong(song)).Throws(new AlreadyExistThisSong());
            songController.CreateSong(songDto);
        }
        
        [TestMethod]
        public void TestGetSongByCategoryNAme()
        {
            Song songToAdd = new Song()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.AddSong(songToAdd));
            songController.CreateSong(songDto);
            mockSongService.Setup(m => m.GetSongsByCategoryName("Dormir")).Returns(songs);
            var result = songController.GetSongsByCategoryName("Dormir");
            var okResult = result as OkObjectResult;
            var songsValue = okResult.Value;
            Assert.AreEqual(songs,songsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetSongByCategoryNAme()
        {
            mockSongService.Setup(m => m.GetSongsByCategoryName("Dormir")).Throws(new KeyNotFoundException());
            var result = songController.GetSongsByCategoryName("Dormir") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestDeleteSong()
        {
            Song songToAdd = new Song()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.AddSong(songToAdd));
            songController.CreateSong(songDto);
            mockSongService.Setup(m => m.DeleteSong(song.Id));
            var result = songController.DeleteSong(song.Id);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Song removed",value);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoDeleteSong()
        {
            Song song = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockSongService.Setup(m => m.DeleteSong(song.Id)).Throws(new KeyNotFoundException());
            songController.DeleteSong(song.Id);
        }
        
        [TestMethod]
        public void TestGetSongById()
        {
            mockSongService.Setup(m => m.GetSongById(1)).Returns(this.song);
            var result = songController.GetSongById(1);
            var okResult = result as OkObjectResult;
            var categoryValue = okResult.Value;
            Assert.AreEqual(songDto,categoryValue);
        }
        
       
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetSongById()
        {
            mockSongService.Setup(m => m.GetSongById(1)).Throws(new KeyNotFoundException());
            var result = songController.GetSongById(1) as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestUpdateSong()
        {
            mockSongService.Setup(m => m.UpdateSongById(1, song));
            var result = songController.UpdateSong(1,song);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoUpdateSong()
        {
            mockSongService.Setup(m => m.UpdateSongById(1, song)).Throws(new KeyNotFoundException());
            var result = songController.UpdateSong(1,song) as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
    }
}