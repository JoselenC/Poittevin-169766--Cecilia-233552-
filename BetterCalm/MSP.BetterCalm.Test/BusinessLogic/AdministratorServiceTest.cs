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
    public class AdministratorServiceTest
    {
        private Mock<ManagerAdministratorRepository> repoMock;
        private Mock<IRepository<Administrator>> administratorMock;
        private Mock<IGuidService> guidServiceMock;
        private IAdministratorService service;
        

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerAdministratorRepository>();
            administratorMock = new Mock<IRepository<Administrator>>();
            guidServiceMock = new Mock<IGuidService>();
            repoMock.Object.Administrators = administratorMock.Object;
            service = new AdministratorService(repoMock.Object, guidServiceMock.Object);
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
            administratorMock.Setup(
                x => x.Get()
            ).Returns(administrators);
            List<Administrator> actualAdministrators = service.GetAdministrators();
            CollectionAssert.AreEqual(administrators, actualAdministrators);
            administratorMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestAddPatient()
        {
            Administrator admin = new Administrator()
            {
                Name = "Patient1"
            };
            administratorMock.Setup(
                x => x.Add(admin)
            );
            service.AddAdministrator(admin);
            administratorMock.VerifyAll();
        }
        
        
        [TestMethod]
        public void TestGetAdministratorById()
        {
            Administrator administrator = new Administrator()
            {
                Name = "administrator1",
                AdministratorId = 1
            };
            administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(administrator);
            service.GetAdministratorsById(administrator.AdministratorId);
            administratorMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundAdministrator))]
        public void TestGetAdministratorByIdNotFound()
        {

            administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Throws(new KeyNotFoundException());
            service.GetAdministratorsById(1);
        }

        [TestMethod]
        public void TestUpdateAdministrator()
        {
            Administrator OldAdministrator = new Administrator()
            {
                AdministratorId = 2,
                Name = "Administrator1"
            };
            Administrator NewAdministrator = new Administrator()
            {
                AdministratorId = 2,
                Name = "Administrator32"
            };
            administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(OldAdministrator);
            administratorMock.Setup(
                x => x.Update(OldAdministrator, NewAdministrator)
            ).Returns(NewAdministrator);
            Administrator realUpdated = service.UpdateAdministrator(NewAdministrator, OldAdministrator.AdministratorId);
            Assert.AreEqual(NewAdministrator, realUpdated);
            administratorMock.VerifyAll();
        }
        

        [TestMethod]
        public void TestDeleteAdministrator()
        {
            Administrator administrator = new Administrator()
            {
                Name = "administrator1",
                AdministratorId = 1
            };
            administratorMock.Setup(
                x => x.Delete(administrator)
            );
            administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(administrator);
            service.DeleteAdministratorById(administrator.AdministratorId);
            administratorMock.VerifyAll();
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundAdministrator))]
        public void TestDeleteAdministratorNotFound()
        {
            administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Throws(new KeyNotFoundException());
            service.DeleteAdministratorById(1);
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
            administratorMock.Setup(
                x => x.Find(It.IsAny<Predicate<Administrator>>())
            ).Returns(administrator);
            guidServiceMock.Setup(x => x.NewGuid()).Returns(token);
            string realToken = service.Login(email, password);
            Assert.AreEqual(expectedToken, realToken);
            administratorMock.VerifyAll();
        }
    }
}