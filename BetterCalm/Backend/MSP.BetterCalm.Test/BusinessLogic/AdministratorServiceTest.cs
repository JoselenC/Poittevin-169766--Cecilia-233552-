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
    public class AdministratorServiceTest
    {
        private Mock<ManagerAdministratorRepository> _repoMock;
        private Mock<IRepository<Administrator>> _administratorMock;
        private Mock<IGuidService> _guidServiceMock;
        private IAdministratorService _service;
        

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _repoMock = new Mock<ManagerAdministratorRepository>();
            _administratorMock = new Mock<IRepository<Administrator>>();
            _guidServiceMock = new Mock<IGuidService>();
            _repoMock.Object.Administrators = _administratorMock.Object;
            _service = new AdministratorService(_repoMock.Object, _guidServiceMock.Object);
        }

        [TestMethod]
        public void TestGetAll()
        {
            Administrator administrator = new Administrator()
            {
                Name = "Administrator1"
            };
            List<Administrator> administrators = new List<Administrator>
            {
                administrator
            };
            _administratorMock.Setup(
                x => x.Get()
            ).Returns(administrators);
            List<Administrator> actualAdministrators = _service.GetAdministrators();
            CollectionAssert.AreEqual(administrators, actualAdministrators);
            _administratorMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestAddPatient()
        {
            Administrator admin = new Administrator()
            {
                Name = "Patient1"
            };
            _administratorMock.Setup(
                x => x.Add(admin)
            );
            _service.AddAdministrator(admin);
            _administratorMock.VerifyAll();
        }
        
        
        [TestMethod]
        public void TestGetAdministratorById()
        {
            Administrator administrator = new Administrator()
            {
                Name = "administrator1",
                AdministratorId = 1
            };
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(administrator);
            _service.GetAdministratorsById(administrator.AdministratorId);
            _administratorMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundAdministrator))]
        public void TestGetAdministratorByIdNotFound()
        {

            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Throws(new KeyNotFoundException());
            _service.GetAdministratorsById(1);
        }

        [TestMethod]
        public void TestUpdateAdministrator()
        {
            Administrator oldAdministrator = new Administrator()
            {
                AdministratorId = 2,
                Name = "Administrator1"
            };
            Administrator newAdministrator = new Administrator()
            {
                AdministratorId = 2,
                Name = "Administrator32"
            };
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(oldAdministrator);
            _administratorMock.Setup(
                x => x.Update(oldAdministrator, newAdministrator)
            ).Returns(newAdministrator);
            Administrator realUpdated = _service.UpdateAdministrator(newAdministrator, oldAdministrator.AdministratorId);
            Assert.AreEqual(newAdministrator, realUpdated);
            _administratorMock.VerifyAll();
        }
        

        [TestMethod]
        public void TestDeleteAdministrator()
        {
            Administrator administrator = new Administrator()
            {
                Name = "administrator1",
                AdministratorId = 1
            };
            _administratorMock.Setup(
                x => x.Delete(administrator)
            );
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(administrator);
            _service.DeleteAdministratorById(administrator.AdministratorId);
            _administratorMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundAdministrator))]
        public void TestDeleteAdministratorNotFound()
        {
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Throws(new KeyNotFoundException());
            _service.DeleteAdministratorById(1);
        }

        [TestMethod]
        public void TestLoginAdministrator()
        {
            string email = "me@email.com";
            string password = "strongPass";
            Administrator administrator = new Administrator()
            {
                AdministratorId = 2,
                Name = "Administrator1",
                Email = email,
                Password = password
            };
            string expectedToken = "b46cacd9-2871-41fc-85ad-c62f888bdf3d";
            Guid token = new Guid(expectedToken);
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(administrator);
            _guidServiceMock.Setup(x => x.NewGuid()).Returns(token);
            string realToken = _service.Login(email, password);
            Assert.AreEqual(expectedToken, realToken);
            _administratorMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundAdminLoginError))]
        public void TestLoginAdministratorError()
        {
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Throws(new KeyNotFoundException());
            _service.Login("email", "password");
        }
        

        [TestMethod]
        public void TestGetAdminByToken()
        {
            string email = "me@email.com";
            string password = "strongPass";
            Administrator administrator = new Administrator()
            {
                AdministratorId = 2,
                Name = "Administrator1",
                Email = email,
                Password = password
            };
            string expectedToken = "b46cacd9-2871-41fc-85ad-c62f888bdf3d";
            Guid token = new Guid(expectedToken);
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(administrator);
            Administrator actualAdministrator = _service.GetAdministratorByToken(token.ToString());
            Assert.AreEqual(administrator, actualAdministrator);
            _administratorMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundAdministrator))]
        public void TestGetAdminByTokenError()
        {
            _administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Throws(new KeyNotFoundException());
            _service.GetAdministratorByToken("token");
        }
    }
}