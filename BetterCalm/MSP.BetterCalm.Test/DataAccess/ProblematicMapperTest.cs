using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass()]
    public class ProblematicMapperTest
    {
        private DbContextOptions<ContextDB> options;

        public  DataBaseRepository<Problematic, ProblematicDto> Problematics;
        public  Problematic problematicTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            ContextDB context = new ContextDB(this.options);
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper(), context.Problematics, context);
            CleanData();
            problematicTest = new Problematic()
            {
                Name = "Dormir",
            };
            Problematics.Add(problematicTest);
        }

        [TestCleanup]
        public void CleanData()
        {
            foreach (Problematic problematic in Problematics.Get())
            {
                Problematics.Delete(problematic);
            }
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Problematic problematicTest = new Problematic()
            {
                Name = "Estres"
            };
            Problematics.Add(problematicTest);
            Problematic realProblematic = Problematics.Find(x => x.Name == "Estres");
            Assert.AreEqual(problematicTest, realProblematic);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Problematic realProblematic = Problematics.Find(x => x.Name == "Dormir");
            Assert.AreEqual(problematicTest, realProblematic);
        }
     
    }
}