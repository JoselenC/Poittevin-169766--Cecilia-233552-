﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class SongMapperTest
    {
        private DbContextOptions<ContextDB> options;

        public  DataBaseRepository<Song, SongDto> Songs;
        public  Song songTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            ContextDB context = new ContextDB(this.options);
            SongMapper songMapper = new SongMapper();
            Songs = new DataBaseRepository<Song, SongDto>(songMapper, context.Songs, context);
        
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Song songTest = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Songs.Add(songTest);
            Song song = Songs.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(songTest, song);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Song songTest = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Songs.Add(songTest);
            Song realSong = Songs.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(songTest, realSong);
        }
        
        [TestMethod]
        public void DtoToDomainTestCategoryNull()
        {
            Song songTest = new Song()
            {
                Categories = null,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Songs.Add(songTest);
            Song realSong = Songs.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(songTest, realSong);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Song songTest = new Song()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            SongDto songDtoTest = new SongDto()
            {
                SongDtoID = 1,
                Categories = new List<CategoryDto>(),
                Name = "Stand by me",
                AuthorName = "The beatles",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            SongMapper songMapper = new SongMapper();
            ContextDB context = new ContextDB();
            context.Songs.Add(songDtoTest);
            songMapper.UpdateDtoObject(songDtoTest, songTest, context);
            Assert.AreEqual(context.Songs.Find(1),songDtoTest);
        }
        
        [TestMethod]
        public void UpdateTestCategoryNull()
        {
            Song songTest = new Song()
            {
                Categories = null,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            SongDto songDtoTest = new SongDto()
            {
                SongDtoID = 1,
                Categories = new List<CategoryDto>(),
                Name = "Stand by me",
                AuthorName = "The beatles",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            SongMapper songMapper = new SongMapper();
            ContextDB context = new ContextDB();
            context.Songs.Add(songDtoTest);
            songMapper.UpdateDtoObject(songDtoTest, songTest, context);
            Assert.AreEqual(context.Songs.Find(1),songDtoTest);
        }
    }
}