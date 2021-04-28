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
    public class CategoryMapperTest
    {
        private DbContextOptions<ContextDB> options;
        private ContextDB context;
        public  DataBaseRepository<Category, CategoryDto> Categories;
        public  Category categoryTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(this.options); 
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper(), context.Categories, context);
            categoryTest = new Category()
            {
                Id=1,
                Name = "Dormir",
            };
            Categories.Add(categoryTest);
            
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Category categoryTest = new Category()
            {
                Id=2,
                Name = "Yoga"
            };
            Categories.Add(categoryTest);
            Category realCategory = Categories.Find(x => x.Name == "Yoga");
            Assert.AreEqual(categoryTest, realCategory);
            
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Category realCategory = Categories.Find(x => x.Name == "Dormir");
            Assert.AreEqual(categoryTest, realCategory);
        }
        
        [TestMethod]
        public void GetById()
        {
            Category realCategory = Categories.FindById(1);
            Assert.AreEqual(categoryTest, realCategory);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void GetByIdNull()
        {
            Categories.FindById(2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void UpdateTest()
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            categoryMapper.UpdateDtoObject(new CategoryDto(), new Category(),new ContextDB());
        }
        
        
    }
}