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
            string getCategoryName = category.Name;
            Assert.Equals(categoryName, getCategoryName);
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
            Assert.AreEqual(category, null);
        }
        
        [TestMethod]
        public void EqualsCategoryType()
        {
            Category category = new Category();
            category.Name="Dormir";
            Assert.AreEqual(category, "");
        }
    }
}