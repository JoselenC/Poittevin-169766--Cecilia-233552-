using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AdministratorRepositoryTest
    {
        [TestMethod]
        public void AdministratorRepositoryCreationAdministratorsTypeTest()
        {
           
            AdministratorRepository administratorRepository = new AdministratorRepository( new AdministratorMapper(),new ContextDB());
            Assert.IsInstanceOfType(administratorRepository.Administrators, typeof(DataBaseRepository<Administrator, AdministratorDto>));
        }
    }
}