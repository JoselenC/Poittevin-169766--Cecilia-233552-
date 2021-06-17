using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PRoblematicRepositoryTest
    {
        [TestMethod]
        public void CategoryRepositoryCreationCategoriesTypeTest()
        {
           
            ProblematicRepository problematicRepository = new ProblematicRepository( new ProblematicMapper(),new ContextDb());
            Assert.IsInstanceOfType(problematicRepository.Problematics, typeof(DataBaseRepository<Problematic, ProblematicDto>));
        }
       

    }
}