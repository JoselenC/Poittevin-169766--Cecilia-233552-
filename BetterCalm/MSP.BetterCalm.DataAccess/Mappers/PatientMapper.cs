using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PatientMapper: IMapper<Patient, PatientDto>
    {
        public PatientDto DomainToDto(Patient obj, ContextDB context)
        {
            PatientDto patientDto = context.Patients.FirstOrDefault(x => 
                    x.Name == obj.Name && 
                    x.LastName == obj.LastName &&
                    x.Cellphone == obj.Cellphone &&
                    x.BirthDay == obj.BirthDay
            );
            if (patientDto is null)
                patientDto = new PatientDto()
                {
                    PatientDtoId = obj.Id,
                    Name = obj.Name,
                    LastName = obj.LastName,
                    BirthDay = obj.BirthDay,
                    Cellphone = obj.Cellphone,
                    
                };
            return patientDto;
        }

        public Patient DtoToDomain(PatientDto obj, ContextDB context)
        {
            ProblematicMapper problematicMapper = new ProblematicMapper();
            context.Entry(obj).Collection("Meetings").Load();
            List<Meeting> domainMeetings = new List<Meeting>();
            foreach (MeetingDto meeting in obj.Meetings)
            {
                context.Entry(meeting).Reference("Psychologist").Load();
                List<Problematic> problematics = new List<Problematic>();
                
                context.Entry(meeting.Psychologist).Collection("Problematics").Load();
                foreach (var problematic in meeting.Psychologist.Problematics)
                {
                    problematics.Add(problematicMapper.DtoToDomain(problematic.Problematic, context));
                }


                domainMeetings.Add(
                    new Meeting()
                    {
                        DateTime = meeting.DateTime,
                        Psychologist = new Psychologist()
                        {
                            Name = meeting.Psychologist.Name,
                            LastName = meeting.Psychologist.LastName,
                            CreationDate = meeting.Psychologist.CreationDate,
                            WorksOnline = meeting.Psychologist.WorksOnline,
                            Problematics = problematics
                        }
                    }
                );
            }
            return new Patient()
            {
                Id = obj.PatientDtoId,
                Name = obj.Name,
                LastName = obj.LastName,
                BirthDay = obj.BirthDay,
                Cellphone = obj.Cellphone,
                Meetings = domainMeetings
            };
        }

        public Patient GetById(ContextDB context, int id)
        {
            throw new System.NotImplementedException();
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