using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        [TestMethod]
        public void CategoryRepositoryCreationCategoriesTypeTest()
        {
           
            CategoryRepository categoryRepository = new CategoryRepository( new CategoryMapper(),new ContextDb());
            Assert.IsInstanceOfType(categoryRepository.Categories, typeof(DataBaseRepository<Category, CategoryDto>));
        }
       

    }
}