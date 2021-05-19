using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        [TestMethod]
        public void CategoryRepositoryCreationCategoriesTypeTest()
        {
           
            CategoryRepository categoryRepository = new CategoryRepository( new CategoryMapper(),new ContextDB());
            Assert.IsInstanceOfType(categoryRepository.Categories, typeof(DataBaseRepository<Category, CategoryDto>));
        }
       

    }
}