using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
   [TestClass]
    public class DataBaseRepositoryTest
    {
        private DbContextOptions<ContextDb> options;
        private ContextDb context;
        private DataBaseRepository<Category, CategoryDto> Categories;
        private DataBaseRepository<Content, ContentDto> Songs;
        private DataBaseRepository<Problematic, ProblematicDto> Problematics;
        private List<Category> AllCategories;
        private Category category;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDb>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDb(options); 
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper(), context.Categories, context);
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);
            AllCategories = new List<Category>();
            category = new Category { Id=1,Name = "Dormir"};
            category = Categories.Add(category);
            AllCategories.Add(category);
            Songs=new DataBaseRepository<Content, ContentDto>(new ContentMapper(), context.Contents, context);
            Content content = new Content() { Id=1, Name = "Let it be"};
            Songs.Add(content);
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
        public void UpdateTest()
        {
            Content content = new Content() {Id=1,Name = "Let it be"};
            Content contentToUdated = new Content()
            {
                Id=1,
                Name = "Musica",
                Duration = 120,
                UrlImage = "",
                Categories = new List<Category>()
            };
            Songs.Update(content, contentToUdated);

            Content realContentUpdated = Songs.Find(x => x.Name == "Musica");

            Assert.AreEqual(contentToUdated, realContentUpdated);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoUpdateTest()
        {
            Content content = new Content() {Id=19,Name = "Muscia2"};
            Content contentToUdated = new Content()
            {
                Id=18,
                Name = "Musica",
            };
            Songs.Update(content, contentToUdated);
        }
        
        [TestMethod]
        public void FindByIdTest()
        {
            Content realContentUpdated =  Songs.FindById(1);
            Assert.IsNotNull(realContentUpdated);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindByIdTest()
        {
            Content realContentUpdated =  Songs.FindById(33);
            Assert.IsNotNull(realContentUpdated);
        }
      
    }
}