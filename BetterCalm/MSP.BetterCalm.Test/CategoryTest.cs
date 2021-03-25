using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void GetCategory()
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
        public void EqualsCategoryNull()
        {
            Category category = new Category();
            category.Name="Dormir";
            Category categoryToCompare = null;
            Assert.AreNotEqual(category, categoryToCompare);
        }
        
        [TestMethod]
        public void EqualsCategoryType()
        {
            Category category = new Category();
            category.Name="Dormir";
            Assert.AreNotEqual(category, "");
        }
    }
}