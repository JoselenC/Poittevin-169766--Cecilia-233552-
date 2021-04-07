using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PatientRepositoryTest
    {
        [TestMethod]
        public void PatientRepositoryCreationPatientsTypeTest()
        {
           
            PatientRepository patientRepository = new PatientRepository( new PatientMapper(),new ContextDB());
            Assert.IsInstanceOfType(patientRepository.Patientes, typeof(DataBaseRepository<Patient, PatientDto>));
        }
        
    }
}