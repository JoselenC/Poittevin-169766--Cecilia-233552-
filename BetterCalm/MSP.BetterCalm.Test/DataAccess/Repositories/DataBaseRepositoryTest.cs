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
        public DataBaseRepository<Category, CategoryDto> Categories;
        public DataBaseRepository<Song, SongDto> Songs;
        private DataBaseRepository<Problematic, ProblematicDto> Problematics;
        public List<Category> AllCategories;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(options); 
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper(), context.Categories, context);
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);
            AllCategories = new List<Category>();
            Category category = new Category {Name = "Dormir"};
            Categories.Add(category);
            AllCategories.Add(category);
            Songs=new DataBaseRepository<Song, SongDto>(new SongMapper(), context.Songs, context);
            Song song = new Song() {Name = "Let it be"};
            Songs.Add(song);
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
                Name = "Dormir",
            };
            Categories.Add(categoryTest);
            Categories.Delete(categoryTest);
        }

        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void DeleteTest()
        {
            Category category = new Category();
            category.Name = "Dormir";
            Categories.Add(category);
            Category testCategory = new Category()
            {
                Name = "Dormir"
            };
            Categories.Delete(testCategory);
            Category realCategory = Categories.Find(x => x.Name == testCategory.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
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
            Category category = new Category {Name = "Dormir"};
            Category actualCategory = Categories.Find(x => x.Name == "Dormir");
            Assert.AreEqual(category, actualCategory);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void NoFindTestt()
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
            Song song = new Song() {Name = "Let it be"};
            Song songToUdated = new Song()
            {
                Name = "Musica",
                Duration = 120,
                UrlImage = "urlImage",
                Categories = new List<Category>()
            };
            Songs.Update(song, songToUdated);

            Song realSongUpdated = Songs.Find(x => x.Name == "Musica");

            Assert.AreEqual(songToUdated, realSongUpdated);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void NoUpdateTest()
        {
            Song song = new Song() {Name = "Muscia2"};
            Song songToUdated = new Song()
            {
                Name = "Musica",
            };
            Songs.Update(song, songToUdated);
        }
      
    }
}