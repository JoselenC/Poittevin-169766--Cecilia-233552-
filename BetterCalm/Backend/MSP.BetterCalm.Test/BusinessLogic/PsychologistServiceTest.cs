using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test.BusinessLogic
{
    [TestClass]
    public class PsychologistServiceTest
    {
        
        private Mock<ManagerPsychologistRepository> _repoMock;
        private Mock<IRepository<Psychologist>> _psychologistMock;
        private PsychologistService _service;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _repoMock = new Mock<ManagerPsychologistRepository>();
            _psychologistMock = new Mock<IRepository<Psychologist>>();
            _repoMock.Object.Psychologists = _psychologistMock.Object;
            _service = new PsychologistService(_repoMock.Object);
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
            _psychologistMock.Setup(
                x => x.Get()
            ).Returns(psychologists);
            List<Psychologist> actualPsychologists = _service.GetPsychologists();
            CollectionAssert.AreEqual(psychologists, actualPsychologists);
            _psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestGetPsychologistById()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "psychologist1",
                PsychologistId = 1
            };
            _psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Returns(psychologist);
            _service.GetPsychologistsById(psychologist.PsychologistId);
            _psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundPsychologist))]
        public void TestGetPsychologistByIdNotFound()
        {

            _psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Throws(new KeyNotFoundException());
            _service.GetPsychologistsById(1);
        }
        
        [TestMethod]
        public void TestAddPsychologist()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "psychologist1"
            };
            _psychologistMock.Setup(
                x => x.Add(psychologist)
            ).Returns(psychologist);
            Psychologist createdPsychologist = _service.SetPsychologist(psychologist);
            Assert.AreEqual(psychologist, createdPsychologist);
            _psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestUpdatePsychologist()
        {
            Psychologist oldPsychologist = new Psychologist()
            {
                PsychologistId = 2,
                Name = "Psychologist1"
            };
            Psychologist newPsychologist = new Psychologist()
            {
                PsychologistId = 2,
                Name = "Psychologist32"
            };
            _psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Returns(oldPsychologist);
            _psychologistMock.Setup(
                x => x.Update(oldPsychologist, newPsychologist)
            ).Returns(newPsychologist);
            Psychologist realUpdated = _service.UpdatePsychologist(newPsychologist, oldPsychologist.PsychologistId);
            Assert.AreEqual(newPsychologist, realUpdated);
            _psychologistMock.VerifyAll();
        }
        

        [TestMethod]
        public void TestDeletePsychologist()
        {
            Psychologist psychologist = new Psychologist()
            {
                Name = "psychologist1",
                PsychologistId = 1
            };
            _psychologistMock.Setup(
                x => x.Delete(psychologist)
            );
            _psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Returns(psychologist);
            _service.DeletePsychologistById(psychologist.PsychologistId);
            _psychologistMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundPsychologist))]
        public void TestDeletePsychologistNotFound()
        {

            _psychologistMock.Setup(
                x => x.Find(It.IsAny<Predicate<Psychologist>>())
            ).Throws(new KeyNotFoundException());
            _service.DeletePsychologistById(1);
        }
    }
}