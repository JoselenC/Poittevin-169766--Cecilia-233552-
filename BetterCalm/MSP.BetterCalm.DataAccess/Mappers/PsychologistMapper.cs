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
                x => x.Name == obj.Name &&
                     x.LastName == obj.LastName &&
                     x.Address == obj.Address &&
                     x.WorksOnline == obj.WorksOnline
                );
            if (psychologistDto == null)
                psychologistDto = new PsychologistDto() 
                {
                    Name = obj.Name,
                    LastName = obj.LastName,
                    Address = obj.Address,
                    WorksOnline = obj.WorksOnline,
                };
            List<PsychologistProblematicDto> problematics = new List<PsychologistProblematicDto>();
            if(obj.Problematics != null){
                foreach (Problematic objProblematic in obj.Problematics)
                {
                    ProblematicDto problematic = context.Problematics.FirstOrDefault(x => x.Name == objProblematic.Name);
                    if (problematic is null)
                        throw new ArgumentException("Problematics creation is not allowed");

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
                PsychologistId = obj.PsychologistDtoId,
                Name = obj.Name,
                LastName = obj.LastName,
                Address = obj.Address,
                WorksOnline = obj.WorksOnline
            };
            List<Problematic> problematics = new List<Problematic>();
            if (obj.Problematics != null)
            {
                foreach (PsychologistProblematicDto psychologistProblematicDto in obj.Problematics)
                {
                    problematics.Add(
                        new Problematic()
                        {
                            Name = psychologistProblematicDto.Problematic.Name
                        }
                    );
                }
                psychologist.Problematics = problematics;
            }
            return psychologist;
        }

        public PsychologistDto UpdateDtoObject(PsychologistDto objToUpdate, Psychologist updatedObject, ContextDB context)
        {

            objToUpdate.Name = updatedObject.Name;
            objToUpdate.LastName = updatedObject.LastName;
            objToUpdate.Address = updatedObject.Address;
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
                        problematics.Add(psychologistProblematicDto);
                    }
                }  
            }
            objToUpdate.Problematics = problematics;
            return objToUpdate;
        }
    }
}