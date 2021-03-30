using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryServiceTest
    {
        private ManagerRepository repo;
        private CategoryService service;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            repo = new ManagerRepository();
            service = new CategoryService(repo);
            repo.Categories = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper());
            CleanData();
        }
        
        [TestCleanup]
        public void CleanData()
        {
            foreach (Category category in repo.Categories.Get())
            {
                repo.Categories.Delete(category);
            }
        }
        
        [TestMethod]
        public void FindCategoryByName()
        {
            Category category1 = new Category { Name = "Yoga"};
            service.SetCategory(category1);
            Category category3 = service.GetCategoryByName("Yoga");
            Assert.AreEqual(category1, category3);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindCategoryByName), "")]
        public void FindCategoryByNameNull()
        { 
            Category category1 = new Category { Name = "Yoga"};
            service.SetCategory(category1);
            Category category3 = service.GetCategoryByName("Musica");
        }

        [TestMethod]
        public void GetCategories()
        {
            Category category = new Category { Name = "dormir" };
            List<Category> categories = new List<Category>
            {
                category
            };
            service.SetCategory(category);
            List<Category> categories2 = service.GetCategories();
            CollectionAssert.AreEqual(categories, categories2);
        }


    }
}