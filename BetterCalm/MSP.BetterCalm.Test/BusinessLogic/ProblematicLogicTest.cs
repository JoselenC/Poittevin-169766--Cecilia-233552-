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
    public class ProblematicLogicTest
    {
        private Mock<ManagerProblematicRepository> repoMock;
        private Mock<IRepository<Problematic>> problematicMock;
        
        public  Problematic problematicTest;

        private ProblematicLogic _logic;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerProblematicRepository>();
            problematicMock = new Mock<IRepository<Problematic>>();
            repoMock.Object.Problematics = problematicMock.Object;
            _logic = new ProblematicLogic(repoMock.Object);
        }

        [TestMethod]
        public void FindProblematicByName()
        {
            Problematic problematic1 = new Problematic { Name = "Estres"};
            problematicMock.Setup(
                x => x.Find(It.IsAny<Predicate<Problematic>>())
            ).Returns(problematic1);
            Problematic problematic2 = _logic.GetProblematicByName("Estres");
            Assert.AreEqual(problematic1, problematic2);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFindProblematicByName), "")]
        public void FindProblematicByNameNull()
        {
            problematicMock.Setup(
                x => x.Find(It.IsAny<Predicate<Problematic>>())
            ).Throws(new ValueNotFound());
            _logic.GetProblematicByName("");
        }

        [TestMethod]
        public void GetProblematics()
        {
            Problematic problematic = new Problematic { Name = "Estres" };
            List<Problematic> problematics = new List<Problematic>
            {
                problematic
            };
            problematicMock.Setup(
                x => x.Get()
            ).Returns(problematics);
            List<Problematic> problematics2 = _logic.GetProblematics();
            CollectionAssert.AreEqual(problematics, problematics2);
        }
    }
}