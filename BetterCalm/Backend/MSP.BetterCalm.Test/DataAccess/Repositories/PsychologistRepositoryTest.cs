using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PsychologistRepositoryTest
    {
        [TestMethod]
        public void PsychologistRepositoryCreationPsychologistsTypeTest()
        {
           
            PsychologistRepository psychologistRepository = new PsychologistRepository( new PsychologistMapper(),new ContextDb());
            Assert.IsInstanceOfType(psychologistRepository.Psychologists, typeof(DataBaseRepository<Psychologist, PsychologistDto>));
        }
    }
}