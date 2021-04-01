using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryServiceTest
    {
        private Mock<ManagerRepository> repoMock;
        private Mock<IRepository<Category>> categoriesMock;
        private ManagerRepository repo;
        private CategoryService service;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerRepository>();
            categoriesMock = new Mock<IRepository<Category>>();
            repoMock.Object.Categories = categoriesMock.Object;
            service = new CategoryService(repoMock.Object);
        }
        
        
        [TestMethod]
        public void FindCategoryByName()
        {
            Category category1 = new Category { Name = "Yoga"};
            categoriesMock.Setup(
                x => x.Find(It.IsAny<Predicate<Category>>())
            ).Returns(category1);
            Category category3 = service.GetCategoryByName("Yoga");
            Assert.AreEqual(category1, category3);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindCategoryByName), "")]
        public void FindCategoryByNameNull()
        {
            categoriesMock.Setup(
                x => x.Find(It.IsAny<Predicate<Category>>())
            ).Throws( new ValueNotFound());
            service.GetCategoryByName("Musica");
        }

        [TestMethod]
        public void GetCategories()
        {
            Category category = new Category { Name = "dormir" };
            List<Category> categories = new List<Category>
            {
                category
            };
            categoriesMock.Setup(
                x => x.Get()
            ).Returns(categories);
            List<Category> categories2 = service.GetCategories();
            CollectionAssert.AreEqual(categories, categories2);
        }


    }
}