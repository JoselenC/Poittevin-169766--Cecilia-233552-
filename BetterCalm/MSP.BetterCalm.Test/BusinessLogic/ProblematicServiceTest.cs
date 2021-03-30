using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ProblematicServiceTest
    {
        public  DataBaseRepository<Problematic, ProblematicDto> Problematics;
        public  Problematic problematicTest;

        private ManagerRepository repo;
        private ProblematicService service;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            repo = new ManagerRepository();
            service = new ProblematicService(repo);
            repo.Problematics = new DataBaseRepository<Problematic, ProblematicDto>(new ProblematicMapper());
            CleanData();
        }

        [TestCleanup]
        public void CleanData()
        {
            foreach (Problematic problematic in repo.Problematics.Get())
            {
                repo.Problematics.Delete(problematic);
            }
        }
        
        [TestMethod]
        public void FindProblematicByName()
        {
            Problematic problematic1 = new Problematic { Name = "Estres"};
            service.SetProblematic(problematic1);
            Problematic problematic2 = service.GetProblematicByName("Estres");
            Assert.AreEqual(problematic1, problematic2);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindProblematicByName), "")]
        public void FindProblematicByNameNull()
        { 
            Problematic problematic1 = new Problematic { Name = "Estres"};
            Problematic problematic2 = new Problematic { Name = "Tristesa"};
            List<Problematic> categoryList = new List<Problematic>();
            service.SetProblematic(problematic1);
            service.SetProblematic(problematic2);
            Problematic problematic3 = service.GetProblematicByName("");
            Assert.IsNull(problematic3);
        }

        [TestMethod]
        public void GetAllProblematics()
        {
            Problematic problematic = new Problematic { Name = "estres" };
            List<Problematic> problematics = new List<Problematic>
            {
                problematic
            };
            service.SetProblematic(problematic);
            List<Problematic> problematics2 = service.GetProblematics();
            CollectionAssert.AreEqual(problematics, problematics2);
        }
        
    }
}