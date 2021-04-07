using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PatientRepository: ManagerPatientRepository
    {
        public PatientRepository(IMapper<Patient, PatientDto> mapper, ContextDB context)
        {
            Patientes = new DataBaseRepository<Patient, PatientDto>(mapper, context.Patients, context);
        }
    }
}