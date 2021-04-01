using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ProblematicServiceTest
    {
        private Mock<ManagerRepository> repoMock;
        private Mock<IRepository<Problematic>> problematicMock;
        
        public  Problematic problematicTest;

        private ProblematicService service;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerRepository>();
            problematicMock = new Mock<IRepository<Problematic>>();
            repoMock.Object.Problematics = problematicMock.Object;
            service = new ProblematicService(repoMock.Object);
        }

        [TestMethod]
        public void FindProblematicByName()
        {
            Problematic problematic1 = new Problematic { Name = "Estres"};
            problematicMock.Setup(
                x => x.Find(It.IsAny<Predicate<Problematic>>())
            ).Returns(problematic1);
            Problematic problematic2 = service.GetProblematicByName("Estres");
            Assert.AreEqual(problematic1, problematic2);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindProblematicByName), "")]
        public void FindProblematicByNameNull()
        {
            problematicMock.Setup(
                x => x.Find(It.IsAny<Predicate<Problematic>>())
            ).Throws(new ValueNotFound());
            service.GetProblematicByName("");
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
            problematicMock.Setup(
                x => x.Get()
            ).Returns(problematics);
            List<Problematic> problematics2 = service.GetProblematics();
            CollectionAssert.AreEqual(problematics, problematics2);
        }
        
    }
}