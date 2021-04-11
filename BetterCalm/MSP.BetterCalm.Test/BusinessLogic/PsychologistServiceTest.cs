using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PsychologistServiceTest
    {
        
        private Mock<ManagerPsychologistRepository> repoMock;
        private Mock<IRepository<Psychologist>> psychologistMock;
        private PsychologistService service;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerPsychologistRepository>();
            psychologistMock = new Mock<IRepository<Psychologist>>();
            repoMock.Object.Psychologists = psychologistMock.Object;
            service = new PsychologistService(repoMock.Object);
        }

        [TestMethod]
        public void TestGetAll()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "Psychologist1"
            };
            List<Psychologist> psychologists = new List<Psychologist>
            {
                psychologist
            };
            psychologistMock.Setup(
                x => x.Get()
            ).Returns(psychologists);
            List<Psychologist> actualPsychologists = service.GetPsychologists();
            CollectionAssert.AreEqual(psychologists, actualPsychologists);
            psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestAddPsychologist()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "psychologist1"
            };
            psychologistMock.Setup(
                x => x.Add(psychologist)
            );
            service.AddPsychologist(psychologist);
            psychologistMock.VerifyAll();
        }

        
    }
}