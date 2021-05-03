using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        private ContextDB context;
        private DataBaseRepository<Audio, AudioDto> RepoAudios;
        private Audio AudioTest;
        private Category category1;
        private Category category2;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB")
                .Options;
            context = new ContextDB(options);
            RepoAudios = new DataBaseRepository<Audio, AudioDto>(new AudioMapper(), context.Audios,context);
            DataBaseRepository<Category, CategoryDto> categRepo = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper(), context.Categories,
                    context);
            category1 = new Category() {Name = "Musica"};
            categRepo.Add(category1);
            category2 = new Category() {Name = "Dormir"};
            categRepo.Add(category2);
            
            AudioTest = new Audio() {
                Id = 1,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = "",
                Categories = new List<Category>(){category1}
            };
            RepoAudios.Add(AudioTest);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DomainToDtoTest()
        {
            RepoAudios.Add(AudioTest);
            Audio actualAudio = RepoAudios.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(AudioTest, actualAudio);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategory))]
        public void DomainToDtoWrongcategoryTest()
        {
            Audio AudioTest = new Audio()
            {
                Id = 0,
                Categories =  new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Category> Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Category Category"
                }
            };
            AudioTest.Categories = Categories;
            RepoAudios.Add(AudioTest);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Audio actualAudio = RepoAudios.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this.AudioTest, actualAudio);
        }
        
        [TestMethod]
        public void DtoToDomainWitAudioTest()
        {
            AudioTest = new Audio() {
                Id = 1,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = "",
                Categories = new List<Category>(){category1}
            };
            RepoAudios.Add(AudioTest);
            Audio actualAudio = RepoAudios.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this.AudioTest, actualAudio);
        }

        [TestMethod]
        public void DtoToDomainWitPlaylistest()
        {
            AudioTest = new Audio() {
                AssociatedToPlaylist = true,
                Id = 1,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = "",
                Categories = new List<Category>(){category1}
            };
            RepoAudios.Add(AudioTest);
            Audio actualAudio = RepoAudios.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this.AudioTest, actualAudio);
        }
        
        [TestMethod]
        public void UpdateTest()
        {
            Audio actualAudio = RepoAudios.Find(x => x.Name =="Stand by me");
            actualAudio.Name = "Help";
            Audio updatedAudio = RepoAudios.Update(AudioTest, actualAudio);
            Assert.AreEqual(actualAudio, updatedAudio);
        }
        
        [TestMethod]
        public void UpdateAudioWithCateogryTest()
        {
            Audio audio =new Audio() {
                Id = 1,
                Name = "Help",
                AuthorName = "The beatles",
                Duration = 121,
                UrlAudio = "",
                UrlImage = "",
                Categories = new List<Category>(){category2,category1}
            };
            RepoAudios.Add(audio);
            Audio actualAudio =new Audio() {
                Name = "ToUpdate",
                Categories = new List<Category>(){category2,category1}
            };
            actualAudio.Name = "Help";
            Audio updatedAudio = RepoAudios.Update(audio, actualAudio);
            Assert.AreEqual(actualAudio, updatedAudio);
        }
       
        [TestMethod]
        public void UpdateAudioWithDiffCateogryTest()
        {
            Audio actualAudio =new Audio() {
                Name = "Help",
                AuthorName = "The beatles",
                Duration = 121,
                UrlAudio = "",
                UrlImage = "",
                Categories = new List<Category>(){category2}
            };
            Audio updatedAudio = RepoAudios.Update(AudioTest, actualAudio);
            Assert.AreEqual(actualAudio, updatedAudio);
        }
    }
}