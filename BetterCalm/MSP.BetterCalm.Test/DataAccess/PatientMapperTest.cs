using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientMapperTest
    {
        private DbContextOptions<ContextDB> options;
        public  DataBaseRepository<Patient, PatientDto> RepoPatients;
        public  Patient patientTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            ContextDB context = new ContextDB(this.options);
            RepoPatients = new DataBaseRepository<Patient, PatientDto>(new PatientMapper(), context.Patients, context);
            patientTest = new Patient()
            {
                Name = "Juan",
                LastName = "Poittevin",
                BirthDay = new DateTime(1993,7,15),
                Cellphone = "09524123",
                Email = "miemail@email.com",
                Password = "StrongHashedPass"
            };
            RepoPatients.Add(patientTest);
        }
        
        [TestMethod]
        public void DomainToDtoTest()
        {
            Patient patientTest = new Patient()
            {
                Name = "Jose"
            };
            RepoPatients.Add(patientTest);
            Patient actualPatient = RepoPatients.Find(x => x.Name == "Jose");
            Assert.AreEqual(patientTest, actualPatient);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Patient actualPatient = RepoPatients.Find(x => x.Name == "Juan");
            Assert.AreEqual(this.patientTest, actualPatient);
        }
     
        [TestMethod]
        public void UpdateTest()
        {
            Patient actualPatient = RepoPatients.Find(x => x.Name == "Juan");
            actualPatient.Name = "JuanUpdated";
            Patient updatedPatient = RepoPatients.Update(patientTest, actualPatient);
            Assert.AreEqual(actualPatient, updatedPatient);
        }
    }
}