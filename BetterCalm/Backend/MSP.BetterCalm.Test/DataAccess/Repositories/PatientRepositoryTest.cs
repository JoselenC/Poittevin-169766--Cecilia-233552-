using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientRepositoryTest
    {
        [TestMethod]
        public void PatientRepositoryCreationPatientsTypeTest()
        {
           
            PatientRepository patientRepository = new PatientRepository( new PatientMapper(),new ContextDb());
            Assert.IsInstanceOfType(patientRepository.Patients, typeof(DataBaseRepository<Patient, PatientDto>));
        }
        
    }
}