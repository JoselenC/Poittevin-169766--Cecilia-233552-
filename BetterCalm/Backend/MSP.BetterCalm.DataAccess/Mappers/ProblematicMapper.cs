using System;
using System.Linq;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Mappers
{
    public class ProblematicMapper: IMapper<Problematic, ProblematicDto>

    {
        public ProblematicDto DomainToDto(Problematic obj,ContextDb context)
        {
            ProblematicDto problematicDto = context.Problematics.FirstOrDefault(x => x.Name == obj.Name);
            if (problematicDto is null)
                problematicDto = new ProblematicDto()
                {
                    Name = obj.Name,
                };
            return problematicDto;
        }

        public Problematic DtoToDomain(ProblematicDto obj,ContextDb context)
        {
            return new Problematic()
            {
                Id=obj.ProblematicDtoId,
                Name = obj.Name
            };
        }

        public Problematic GetById(ContextDb context, int id)
        {
            ProblematicDto problematicDto = context.Problematics
                .FirstOrDefault(m => m.ProblematicDtoId == id);
            if (problematicDto != null)
              return DtoToDomain(problematicDto,context);
            return null;
        }

        public ProblematicDto UpdateDtoObject(ProblematicDto objToUpdate, Problematic updatedObject, ContextDb context)
        {
            throw new NotImplementedException();
        }
    }
}