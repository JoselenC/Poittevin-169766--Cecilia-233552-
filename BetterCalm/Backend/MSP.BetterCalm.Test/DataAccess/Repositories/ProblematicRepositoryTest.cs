using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PRoblematicRepositoryTest
    {
        [TestMethod]
        public void CategoryRepositoryCreationCategoriesTypeTest()
        {
           
            ProblematicRepository problematicRepository = new ProblematicRepository( new ProblematicMapper(),new ContextDB());
            Assert.IsInstanceOfType(problematicRepository.Problematics, typeof(DataBaseRepository<Problematic, ProblematicDto>));
        }
       

    }
}