using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class CategoryControllerTest
    {

        private Mock<ICategoryService> mockCategoryService;
        private CategoryController categoryController ;
        private List<Category> categories;
        private Category category;
        
        [TestInitialize]
        public void InitializeTest()
        {
            mockCategoryService=new Mock<ICategoryService>(MockBehavior.Strict);
            categoryController = new CategoryController(mockCategoryService.Object);
            categories = new List<Category>();
            category = new Category();
        }
        
        [TestMethod]
        public void TestGetAllCategories()
        {
            mockCategoryService.Setup(m => m.GetCategories()).Returns(this.categories);
            var result = categoryController.GetAll();
            var okResult = result as OkObjectResult;
            var categoriesValue = okResult.Value;
            Assert.AreEqual(this.categories,categoriesValue);
        }
        
        [TestMethod]
        public void TestGetCategoryByName()
        {
            mockCategoryService.Setup(m => m.GetCategoryByName("Dormir")).Returns(this.category);
            var result = categoryController.GetCategoryByName("Dormir");
            var okResult = result as OkObjectResult;
            var categoryValue = okResult.Value;
            Assert.AreEqual(this.category,categoryValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetCategoryByName()
        {
            mockCategoryService.Setup(m => m.GetCategoryByName("Dormir")).Throws(new KeyNotFoundException());
            categoryController.GetCategoryByName("Dormir");
        }
        
        [TestMethod]
        public void TestGetCategoryById()
        {
            mockCategoryService.Setup(m => m.GetCategoryById(1)).Returns(this.category);
            var result = categoryController.GetCategoryById(1);
            var okResult = result as OkObjectResult;
            var categoryValue = okResult.Value;
            Assert.AreEqual(this.category,categoryValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId))]
        public void TestNoGetCategoryById()
        {
            mockCategoryService.Setup(m => m.GetCategoryById(1)).Throws(new NotFoundId());
            categoryController.GetCategoryById(1);
        }
    }
}