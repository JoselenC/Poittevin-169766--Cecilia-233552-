using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    public class AdministratorServiceTest
    {
        private Mock<ManagerAdministratorRepository> repoMock;
        private Mock<IRepository<Administrator>> administratorMock;
        private IAdministratorService service;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerAdministratorRepository>();
            administratorMock = new Mock<IRepository<Administrator>>();
            repoMock.Object.Administrators = administratorMock.Object;
            service = new AdministratorService(repoMock.Object);
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
    }
}