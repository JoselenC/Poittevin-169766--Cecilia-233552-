using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AdministratorRepositoryTest
    {
        [TestMethod]
        public void AdministratorRepositoryCreationAdministratorsTypeTest()
        {
           
            AdministratorRepository administratorRepository = new AdministratorRepository( new AdministratorMapper(),new ContextDb());
            Assert.IsInstanceOfType(administratorRepository.Administrators, typeof(DataBaseRepository<Administrator, AdministratorDto>));
        }
    }
}