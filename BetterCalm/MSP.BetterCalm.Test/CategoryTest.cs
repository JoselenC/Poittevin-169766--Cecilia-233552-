using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void GetCategoryName()
        {
            string categoryName = "Dormir";
            Category category = new Category();
            category.Name = "Dormir";
            string getCategoryName = category.Name;
            Assert.AreEqual(categoryName, getCategoryName);
        }
        
        [TestMethod]
        public void EqualsCategory()
        {
            Category category = new Category();
            category.Name="Dormir";
            Category categoryToCompare = new Category();
            categoryToCompare.Name="Dormir";
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
        public void NotEqualsCategoryName()
        {
            Category category = new Category();
            category.Name="Dormir";
            Category categoryToCompare = new Category();
            categoryToCompare.Name="Yoga";
            Assert.AreNotEqual(category, categoryToCompare);
        }
        
        [TestMethod]
        public void NotEqualsCategoryType()
        {
            Category category = new Category();
            category.Name="Dormir";
            Assert.AreNotEqual(category, "");
        }
        
    }
}