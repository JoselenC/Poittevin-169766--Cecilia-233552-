using System.Linq;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PsychologistMapper: IMapper<Psychologist, PsychologistDto>
    {
        public PsychologistDto DomainToDto(Psychologist obj, ContextDB context)
        {
            PsychologistDto psychologistDto = context.Psychologists.FirstOrDefault(x => x.Name == obj.Name);
            if (psychologistDto is null)
                psychologistDto = new PsychologistDto()
                {
                    Name = obj.Name,
                    LastName = obj.LastName,
                    Address = obj.Address,
                    WorksOnline = obj.WorksOnline
                    
                };
            return psychologistDto;
        }

        public Psychologist DtoToDomain(PsychologistDto obj, ContextDB context)
        {
            return new Psychologist()
            {
                Name = obj.Name,
                LastName = obj.LastName,
                Address = obj.Address,
                WorksOnline = obj.WorksOnline
            };
        }

        public Psychologist GetById(ContextDB context, int id)
        {
            throw new System.NotImplementedException();
        }

        public PsychologistDto UpdateDtoObject(PsychologistDto objToUpdate, Psychologist updatedObject, ContextDB context)
        {
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.LastName = updatedObject.LastName;
            objToUpdate.Address = updatedObject.Address;
            objToUpdate.WorksOnline = updatedObject.WorksOnline;
            return objToUpdate;
        }
    }
}