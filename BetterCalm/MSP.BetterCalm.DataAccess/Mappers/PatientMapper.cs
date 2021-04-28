using System.Collections.Generic;
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
                    PatientDtoId = obj.PatientId,
                    Name = obj.Name,
                    LastName = obj.LastName,
                    BirthDay = obj.BirthDay,
                    Cellphone = obj.Cellphone,
                    
                };
            return patientDto;
        }

        public Patient DtoToDomain(PatientDto obj, ContextDB context)
        {
            PsychologistMapper psychologistMapper = new PsychologistMapper();
            List<MeetingDto> meetings = context.Meeting.ToList().FindAll(x => x.Patient == obj);
            List<Meeting> domainMeetings = new List<Meeting>();
            foreach (MeetingDto meeting in meetings)
            {
                domainMeetings.Add(
                    new Meeting()
                    {
                        DateTime = meeting.DateTime,
                        Psychologist = psychologistMapper.DtoToDomain(meeting.Psychologist, context)
                    }
                    );
            }
            return new Patient()
            {
                PatientId = obj.PatientDtoId,
                Name = obj.Name,
                LastName = obj.LastName,
                BirthDay = obj.BirthDay,
                Cellphone = obj.Cellphone,
                Meetings = domainMeetings
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