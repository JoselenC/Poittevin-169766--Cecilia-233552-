using System.Linq;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PatientMapper: IMapper<Patient, PatientDto>
    {
        public PatientDto DomainToDto(Patient obj, ContextDB context)
        {
            PatientDto patientDto = context.Patients.FirstOrDefault(x => x.Name == obj.Name);
            if (patientDto is null)
                patientDto = new PatientDto()
                {
                    Name = obj.Name,
                    LastName = obj.LastName,
                    BirthDay = obj.BirthDay,
                    Cellphone = obj.Cellphone,
                    
                };
            return patientDto;
        }

        public Patient DtoToDomain(PatientDto obj, ContextDB context)
        {
            return new Patient()
            {
                Name = obj.Name,
                LastName = obj.LastName,
                BirthDay = obj.BirthDay,
                Cellphone = obj.Cellphone,
            };
        }

        public PatientDto UpdateDtoObject(PatientDto objToUpdate, Patient updatedObject, ContextDB context)
        {
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.LastName = updatedObject.LastName;
            objToUpdate.Cellphone = updatedObject.Cellphone;
            objToUpdate.BirthDay = updatedObject.BirthDay;
            return objToUpdate;
        }
    }
}