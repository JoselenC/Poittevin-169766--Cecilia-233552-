using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
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
        private ContextDB context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(this.options);
            SongMapper songMapper = new SongMapper();
            Songs = new DataBaseRepository<Song, SongDto>(songMapper, context.Songs, context);
        
        }
        
        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategory), "")]
        public void DomainToDtoTest()
        {
            Song songTest = new Song()
            {
                Categories = new List<Category>()
                {
                    new Category(){Id=1,Name = "Musica"},
                },
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
            public void DomainToDtoTestCategoryNull()
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
                Songs.Add(songTest);
                Song song = Songs.Find(x => x.Name == "Stand by me");
                Assert.AreEqual(songTest, song);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Song songTest = new Song()
            {
                Id=0,
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
                Id=0,
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
                PlaylistSongsDto = new List<PlaylistSongDto>(),
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
        public void UpdateTestDiffCategory()
        {
            Song songTest = new Song()
            {
                Categories = new List<Category>()
                {
                    new Category(){Name = "Dormir"},
                    new Category(){Name = "Musica"}
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            SongDto songDtoTest = new SongDto()
            {
                SongDtoID = 1,
                PlaylistSongsDto = new List<PlaylistSongDto>(),
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
                PlaylistSongsDto = new List<PlaylistSongDto>(),
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