using System.Collections.Generic;
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
       
        public  DataBaseRepository<Category, CategoryDto> Categories;
        public  Category categoryTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper());
            CleanData();
            categoryTest = new Category()
            {
                Name = "Dormir",
            };
            Categories.Add(categoryTest);
            
        }

        [TestCleanup]
        public void CleanData()
        {
            foreach (Category category in Categories.Get())
            {
                Categories.Delete(category);
            }
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Category categoryTest = new Category()
            {
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
        
        
    }
}