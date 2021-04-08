using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientServiceTest
    {
        private Mock<ManagerPatientRepository> repoMock;
        private Mock<IRepository<Patient>> patientMock;
        private PatientService service;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerPatientRepository>();
            patientMock = new Mock<IRepository<Patient>>();
            repoMock.Object.Patientes = patientMock.Object;
            service = new PatientService(repoMock.Object);
        }

        [TestMethod]
        public void TestGetAll()
        {
            Patient patient = new Patient()
            {
                Name = "Patient1"
            };
            List<Patient> patients = new List<Patient>
            {
                patient
            };
            patientMock.Setup(
                x => x.Get()
            ).Returns(patients);
            List<Patient> actualPatients = service.GetPatients();
            CollectionAssert.AreEqual(patients, actualPatients);
            patientMock.VerifyAll();
        }
        
        [TestMethod]
        public void TestAddPatient()
        {
            Patient patient = new Patient()
            {
                Name = "Patient1"
            };
            patientMock.Setup(
                x => x.Add(patient)
            );
            service.AddPatient(patient);
            patientMock.VerifyAll();
        }

    }
}