using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
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
        public void TestGetPsychologistById()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "psychologist1",
                PsychologistId = 1
            };
            psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Returns(psychologist);
            service.GetPsychologistsById(psychologist.PsychologistId);
            psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundPsychologist))]
        public void TestGetPsychologistByIdNotFound()
        {

            psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Throws(new KeyNotFoundException());
            service.GetPsychologistsById(1);
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
            service.SetPsychologist(psychologist);
            psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestUpdatePsychologist()
        {
            Psychologist OldPsychologist = new Psychologist()
            {
                PsychologistId = 2,
                Name = "Psychologist1"
            };
            Psychologist NewPsychologist = new Psychologist()
            {
                PsychologistId = 2,
                Name = "Psychologist32"
            };
            psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Returns(OldPsychologist);
            psychologistMock.Setup(
                x => x.Update(OldPsychologist, NewPsychologist)
            ).Returns(NewPsychologist);
            Psychologist realUpdated = service.UpdatePsychologist(NewPsychologist, OldPsychologist.PsychologistId);
            Assert.AreEqual(NewPsychologist, realUpdated);
            psychologistMock.VerifyAll();
        }
        

        [TestMethod]
        public void TestDeletePsychologist()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "psychologist1",
                PsychologistId = 1
            };
            psychologistMock.Setup(
                x => x.Delete(psychologist)
            );
            psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Returns(psychologist);
            service.DeletePsychologistById(psychologist.PsychologistId);
            psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundPsychologist))]
        public void TestDeletePsychologistNotFound()
        {

            psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Throws(new KeyNotFoundException());
            service.DeletePsychologistById(1);
        }
    }
}