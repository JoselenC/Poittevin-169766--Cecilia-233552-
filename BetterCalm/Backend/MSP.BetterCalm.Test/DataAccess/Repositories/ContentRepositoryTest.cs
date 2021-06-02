using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ContentRepositoryTest
    {
        [TestMethod]
        public void ContentRepositoryCreationCategoriesTypeTest()
        {
            ContentRepository ContentRepository = new ContentRepository(new ContentMapper(),new ContextDb());
            Assert.IsInstanceOfType(ContentRepository.Contents, typeof(DataBaseRepository<Content, ContentDto>));
        }
    }
}