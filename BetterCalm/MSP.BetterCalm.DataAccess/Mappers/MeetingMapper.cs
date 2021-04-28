using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class MeetingMapper: IMapper<Meeting, MeetingDto>
    {
        public MeetingDto DomainToDto(Meeting obj, ContextDB context)
        {
            PatientMapper patientMapper = new PatientMapper();
            PsychologistMapper psychologistMapper = new PsychologistMapper();
            int patientId = 0;
            int psychologistId = 0;
            
            PatientDto patientDto = context.Patients.Find(obj.Patient.PatientId);
            if (patientDto is null)
                patientDto = patientMapper.DomainToDto(obj.Patient, context);
            else
                context.Entry(patientDto).State = EntityState.Modified;
            PsychologistDto psychologistDto = context.Psychologists.Find(obj.Psychologist.PsychologistId);
            if (psychologistDto is null)
                psychologistDto = psychologistMapper.DomainToDto(obj.Psychologist, context);
            else
                context.Entry(psychologistDto).State = EntityState.Modified;
            
            return new MeetingDto()
            {
                DateTime = obj.DateTime,
                Patient = patientDto,
                Psychologist = psychologistDto,
            };
        }

        private Patient DtoToDomainPatientWithoutMeetings(PatientDto patientDto)
        {
            if (!(patientDto is null)){
                return new Patient()
                {
                    Name = patientDto.Name,
                    LastName = patientDto.LastName,
                    BirthDay = patientDto.BirthDay,
                    Cellphone = patientDto.Cellphone,
                    PatientId = patientDto.PatientDtoId
                };
            }
            return null;
        }
        
        private Psychologist DtoToDomainpPsychologistWithoutMeetings(PsychologistDto psyDto)
        {
            if(!(psyDto is null)){
                List<Problematic> problematics = new List<Problematic>();
                if (!(psyDto.Problematics is null))
                {
                    foreach (PsychologistProblematicDto psychologistProblematicDto in psyDto.Problematics)
                    {
                        problematics.Add(new Problematic()
                        {
                            Name = psychologistProblematicDto.Problematic.Name
                        });
                    }
                }
                return new Psychologist()
                {
                    Name = psyDto.Name,
                    LastName = psyDto.LastName,
                    PsychologistId = psyDto.PsychologistDtoId,
                    Address = psyDto.Address,
                    Problematics = problematics
                };
            }
            return null;
        }

        public Meeting DtoToDomain(MeetingDto obj, ContextDB context)
        {
            context.Entry(obj).Reference("Patient").Load();
            context.Entry(obj).Reference("Psychologist").Load();
            return new Meeting()
            {
                DateTime = obj.DateTime,
                Patient = DtoToDomainPatientWithoutMeetings(obj.Patient),
                Psychologist = DtoToDomainpPsychologistWithoutMeetings(obj.Psychologist)
            };
        }

        public Meeting GetById(ContextDB context, int id)
        {
            throw new System.NotImplementedException();
        }

        public MeetingDto UpdateDtoObject(MeetingDto objToUpdate, Meeting updatedObject, ContextDB context)
        {
            throw new System.NotImplementedException();
        }
    }
}