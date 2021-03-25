using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.Equals(category, categoryToCompare);
        }
    }
}