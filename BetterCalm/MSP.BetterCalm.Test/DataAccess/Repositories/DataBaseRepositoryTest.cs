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
    public class DataBaseRepositoryTest
    {
        private DbContextOptions<ContextDB> options;
        private ContextDB context;
        private DataBaseRepository<Category, CategoryDto> Categories;
        private DataBaseRepository<Audio, AudioDto> Songs;
        private DataBaseRepository<Problematic, ProblematicDto> Problematics;
        private List<Category> AllCategories;
        private Category category;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(options); 
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper(), context.Categories, context);
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);
            AllCategories = new List<Category>();
            category = new Category { Id=1,Name = "Dormir"};
            category = Categories.Add(category);
            AllCategories.Add(category);
            Songs=new DataBaseRepository<Audio, AudioDto>(new AudioMapper(), context.Audios, context);
            Audio audio = new Audio() { Id=1, Name = "Let it be"};
            Songs.Add(audio);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void AddSuccessCaseTest()
        {
            Category categoryTest = new Category()
            {
                Id = 1,
                Name = "Dormir",
            };
            Categories.Add(categoryTest);
            Categories.Delete(categoryTest);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void DeleteTest()
        {
            Category category = new Category();
            category.Name = "Dormir";
            Categories.Add(category);
            Category testCategory = new Category()
            {
                Name = "Dormir"
            };
            Categories.Delete(category);
            Category realCategory = Categories.Find(x => x.Name == testCategory.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoDeleteTest()
        {
            Category testCategory = new Category()
            {
                Name = "NoExistenteCategoria"
            };
            Categories.Delete(testCategory);
        }

        [TestMethod]
        public void FindTest()
        {
            Category actualCategory = Categories.Find(x => x.Id == category.Id);
            Assert.AreEqual(category, actualCategory);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindTest()
        {
            Categories.Find(x => x.Name == "Musica");
        }

        [TestMethod]
        public void GetTest()
        {
            List<Category> realAllCategories = Categories.Get();
            realAllCategories.Sort((x, y) => x.Name.CompareTo(y.Name));
            AllCategories.Sort((x, y) => x.Name.CompareTo(y.Name));
            CollectionAssert.AreEqual(AllCategories, realAllCategories);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void SetTest()
        {
            Categories.Set(AllCategories);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Audio audio = new Audio() {Id=1,Name = "Let it be"};
            Audio audioToUdated = new Audio()
            {
                Id=1,
                Name = "Musica",
                Duration = 120,
                UrlImage = "",
                Categories = new List<Category>()
            };
            Songs.Update(audio, audioToUdated);

            Audio realAudioUpdated = Songs.Find(x => x.Name == "Musica");

            Assert.AreEqual(audioToUdated, realAudioUpdated);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoUpdateTest()
        {
            Audio audio = new Audio() {Id=19,Name = "Muscia2"};
            Audio audioToUdated = new Audio()
            {
                Id=18,
                Name = "Musica",
            };
            Songs.Update(audio, audioToUdated);
        }
        
        [TestMethod]
        public void FindByIdTest()
        {
            Audio realAudioUpdated =  Songs.FindById(1);
            Assert.IsNotNull(realAudioUpdated);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindByIdTest()
        {
            Audio realAudioUpdated =  Songs.FindById(33);
            Assert.IsNotNull(realAudioUpdated);
        }
      
    }
}