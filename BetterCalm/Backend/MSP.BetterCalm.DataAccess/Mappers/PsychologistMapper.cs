using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PsychologistMapper: IMapper<Psychologist, PsychologistDto>
    {
        public PsychologistDto DomainToDto(Psychologist obj, ContextDB context)
        {
            PsychologistDto psychologistDto = context.Psychologists.FirstOrDefault(
                x => x.PsychologistDtoId == obj.PsychologistId
                );
            if (psychologistDto == null)
                psychologistDto = new PsychologistDto() 
                {
                    CreationDate = obj.CreationDate,
                    Name = obj.Name,
                    LastName = obj.LastName,
                    Address = obj.Address,
                    WorksOnline = obj.WorksOnline
                };
            List<PsychologistProblematicDto> problematics = new List<PsychologistProblematicDto>();
            if(obj.Problematics != null){
                foreach (Problematic objProblematic in obj.Problematics)
                {
                    ProblematicDto problematic = context.Problematics.FirstOrDefault(x => x.Name == objProblematic.Name);
                    if (problematic is null)
                        throw new InvalidProblematic();

                    PsychologistProblematicDto psychologistProblematicDto = new PsychologistProblematicDto()
                    {
                        Psychologist = psychologistDto,
                        Problematic = problematic
                    };
                    problematics.Add(psychologistProblematicDto);
                }
                psychologistDto.Problematics = problematics;
            }
            return psychologistDto;
        }

        public Psychologist DtoToDomain(PsychologistDto obj, ContextDB context)
        {
            Psychologist psychologist = new Psychologist()
            {
                CreationDate =  obj.CreationDate,
                PsychologistId = obj.PsychologistDtoId,
                Name = obj.Name,
                LastName = obj.LastName,
                Address = obj.Address,
                WorksOnline = obj.WorksOnline
            };
            context.Entry(obj).Collection("Problematics").Load();
            List<Problematic> problematics = new List<Problematic>();
            if (obj.Problematics != null)
            {
                foreach (PsychologistProblematicDto psychologistProblematicDto in obj.Problematics)
                {
                    context.Entry(psychologistProblematicDto).Reference("Problematic").Load();
                    problematics.Add(
                        new Problematic()
                        {
                            Id = psychologistProblematicDto.Problematic.ProblematicDtoID,
                            Name = psychologistProblematicDto.Problematic.Name
                        }
                    );
                }
                psychologist.Problematics = problematics;
            }
            context.Entry(obj).Collection("Meetings").Load();
            List<Meeting> meetings = new List<Meeting>();
            if (obj.Meetings != null)
            {
                foreach (MeetingDto meeting in obj.Meetings)
                {
                    context.Entry(meeting).Reference("Patient").Load();
                    meetings.Add(
                        new Meeting()
                        {
                            Patient = new Patient()
                            {
                                Id = meeting.PatientId,
                                Name = meeting.Patient.Name
                            },
                            DateTime = meeting.DateTime
                        }
                    );
                }
                psychologist.Meetings = meetings;
            }
            return psychologist;
        }

        public Psychologist GetById(ContextDB context, int id)
        {
            throw new System.NotImplementedException();
        }

        public PsychologistDto UpdateDtoObject(PsychologistDto objToUpdate, Psychologist updatedObject, ContextDB context)
        {
            objToUpdate.Name = updatedObject.Name ?? objToUpdate.Name;
            objToUpdate.LastName = updatedObject.LastName ?? objToUpdate.LastName;
            objToUpdate.Address = updatedObject.Address ?? objToUpdate.Address;
            objToUpdate.WorksOnline = updatedObject.WorksOnline;

            List<PsychologistProblematicDto> problematics = new List<PsychologistProblematicDto>();
            if (!(updatedObject.Problematics is null))
            {
                foreach (Problematic objProblematic in updatedObject.Problematics)
                {
                    ProblematicDto problematic = context.Problematics.FirstOrDefault(x => x.Name == objProblematic.Name);
                    if (problematic is null)
                        throw new ArgumentException("Problematics creation is not allowed");
                    PsychologistProblematicDto psychologistProblematicDto = context.PsychologistProblematic.FirstOrDefault(
                        x => x.ProblematicId == problematic.ProblematicDtoID &&
                             x.PsychologistId == objToUpdate.PsychologistDtoId
                    );
                    if (psychologistProblematicDto is null)
                    {
                        psychologistProblematicDto = new PsychologistProblematicDto()
                        {
                            Psychologist = objToUpdate,
                            Problematic = problematic
                        };
                    }
                    problematics.Add(psychologistProblematicDto);
                }  
            }
            objToUpdate.Problematics = problematics;
            return objToUpdate;
        }
    }
}