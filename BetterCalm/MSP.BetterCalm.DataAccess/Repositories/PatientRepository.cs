using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PatientRepository: ManagerPatientRepository
    {
        public PatientRepository(IMapper<Patient, PatientDto> mapper, ContextDB context)
        {
            Patients = new DataBaseRepository<Patient, PatientDto>(mapper, context.Patients, context);
        }
    }
}