using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void GetSetCategoryName()
        {
            string categoryName = "Dormir";
            Category category = new Category();
            category.Name = "Dormir";
            string getCategoryName = category.Name;
            Assert.AreEqual(categoryName, getCategoryName);
        }
        
        [TestMethod]
        public void GetSetCategoryId()
        {
            int categoryId = 1;
            Category category = new Category();
            category.Id = 1;
            int getCategoryId = category.Id;
            Assert.AreEqual(categoryId, getCategoryId);
        }
        
        [TestMethod]
        public void EqualsCategory()
        {
            Category category = new Category();
            category.Id=1;
            Category categoryToCompare = new Category();
            categoryToCompare.Id=1;
            Assert.AreEqual(category, categoryToCompare);
        }
        
        [TestMethod]
        public void NotEqualsCategoryNull()
        {
            Category category = new Category();
            category.Name="Dormir";
            Assert.AreNotEqual(category, null);
        }
        
        [TestMethod]
        public void CategoryNull()
        {
            Category category=null;
            Assert.IsNull(category);
        }
        
        [TestMethod]
        public void NotCategoryNull()
        {
            Category category=new Category();
            Assert.IsNotNull(category);
        }
        
        [TestMethod]
        public void NotEqualsCategoryId()
        {
            Category category = new Category();
            category.Id=1;
            Category categoryToCompare = new Category();
            categoryToCompare.Id=2;
            Assert.AreNotEqual(category, categoryToCompare);
        }
        
        [TestMethod]
        public void NotEqualsCategoryType()
        {
            Category category = new Category();
            category.Name="Dormir";
            Assert.AreNotEqual(category, "");
        }

        [TestMethod]
        public void IsSameCategoryName()
        {
            Category category = new Category();
            category.Name = "Yoga";
            string categoryName = "Yoga";
            Assert.IsTrue(category.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void IsDifferentCategoryName()
        {
            Category category = new Category();
            category.Name = "Yoga";
            string categoryName = "Musica";
            Assert.IsFalse(category.IsSameCategoryName(categoryName));
        }
    }
}