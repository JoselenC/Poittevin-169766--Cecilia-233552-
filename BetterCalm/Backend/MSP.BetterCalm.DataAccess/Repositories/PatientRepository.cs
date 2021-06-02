using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class PatientRepository: ManagerPatientRepository
    {
        public PatientRepository(IMapper<Patient, PatientDto> mapper, ContextDb context)
        {
            Patients = new DataBaseRepository<Patient, PatientDto>(mapper, context.Patients, context);
        }
    }
}