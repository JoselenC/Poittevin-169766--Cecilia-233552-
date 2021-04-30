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
    public class AudioMapperTest
    {
        private DbContextOptions<ContextDB> options;

        public  DataBaseRepository<Audio, AudioDto> Audios;
        public  Audio AudioTest;
        private ContextDB context;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(this.options);
            AudioMapper audioMapper = new AudioMapper();
            Audios = new DataBaseRepository<Audio, AudioDto>(audioMapper, context.Audios, context);
        
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
            Audio audioTest = new Audio()
            {
                Categories = new List<Category>() {new Category(){Id=1,Name = "Musica"},},
                Name = "Stand by me"
            };
            Audios.Add(audioTest);
            Audio audio = Audios.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(audioTest, audio);
        }

        [TestMethod]
        public void DomainToDtoTestCategoryNull()
        {
            Audio audioTest = new Audio()
            {
                Id=1,
                Categories = null,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Audios.Add(audioTest);
            Audio audio = Audios.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(audioTest, audio);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Audio audioTest = new Audio()
            {
                Id=1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Audios.Add(audioTest);
            Audio realAudio = Audios.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(audioTest, realAudio);
        }
        
        [TestMethod]
        public void DtoToDomainTestCategoryNull()
        {
            Audio audioTest = new Audio()
            {
                Id=1,
                Categories = null,
                Name = "a",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Audios.Add(audioTest);
            Audio realAudio = Audios.Find(x => x.Name == "a");
            Assert.AreEqual(audioTest, realAudio);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Audio audioTest = new Audio()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            AudioDto audioDtoTest = new AudioDto()
            {
                AudioDtoID = 1,
                PlaylistAudiosDto = new List<PlaylistAudioDto>(),
                Name = "Stand by me",
                AuthorName = "The beatles",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            AudioMapper audioMapper = new AudioMapper();
            ContextDB context = new ContextDB();
            context.Audios.Add(audioDtoTest);
            audioMapper.UpdateDtoObject(audioDtoTest, audioTest, context);
            Assert.AreEqual(context.Audios.Find(1),audioDtoTest);
        }

        [TestMethod]
        public void UpdateTestCategoryNull()
        {
            Audio audioTest = new Audio()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            AudioDto audioDtoTest = new AudioDto()
            {
                AudioDtoID = 1,
                PlaylistAudiosDto = new List<PlaylistAudioDto>(),
                Name = "Stand by me",
                AuthorName = "The beatles",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            AudioMapper audioMapper = new AudioMapper();
            ContextDB context = new ContextDB();
            context.Audios.Add(audioDtoTest);
            audioMapper.UpdateDtoObject(audioDtoTest, audioTest, context);
            Assert.AreEqual(context.Audios.Find(1),audioDtoTest);
        }
    }
}