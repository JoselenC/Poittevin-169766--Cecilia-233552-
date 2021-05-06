using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AdministratorMapperTest
    {
        private DbContextOptions<ContextDB> options;
        public  DataBaseRepository<Administrator, AdministratorDto> RepoAdministrators;
        public  Administrator administratorTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            ContextDB context = new ContextDB(this.options);
            RepoAdministrators = new DataBaseRepository<Administrator, AdministratorDto>(new AdministratorMapper(), context.Administrators, context);
            administratorTest = new Administrator()
            {
                Name = "Juan",
                LastName = "Poittevin",
                Email = "email@test.com",
                Password = "pass21"
            };
            RepoAdministrators.Add(administratorTest);
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Administrator administratorTest = new Administrator()
            {
                Name = "Jose"
            };
            RepoAdministrators.Add(administratorTest);
            Administrator actualAdministrator = RepoAdministrators.Find(x => x.Name == "Jose");
            Assert.AreEqual(administratorTest, actualAdministrator);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Administrator actualAdministrator = RepoAdministrators.Find(x => x.Name == "Juan");
            Assert.AreEqual(this.administratorTest, actualAdministrator);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Administrator actualAdministrator = RepoAdministrators.Find(x => x.Name == "Juan");
            actualAdministrator.Name = "JuanUpdated";
            Administrator updatedAdministrator = RepoAdministrators.Update(administratorTest, actualAdministrator);
            Assert.AreEqual(actualAdministrator, updatedAdministrator);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "")]
        public void GetByIdTest()
        {
            RepoAdministrators.FindById(1);
        }
    }
}