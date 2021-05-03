using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class ProblematicMapper: IMapper<Problematic, ProblematicDto>

    {
        public ProblematicDto DomainToDto(Problematic obj,ContextDB context)
        {
            ProblematicDto problematicDto = context.Problematics.FirstOrDefault(x => x.Name == obj.Name);
            if (problematicDto is null)
                problematicDto = new ProblematicDto()
                {
                    Name = obj.Name,
                };
            return problematicDto;
        }

        public Problematic DtoToDomain(ProblematicDto obj,ContextDB context)
        {
            return new Problematic()
            {
                Id=obj.ProblematicDtoID,
                Name = obj.Name
            };
        }

        public Problematic GetById(ContextDB context, int id)
        {
            ProblematicDto problematicDto = context.Problematics
                .FirstOrDefault(m => m.ProblematicDtoID == id);
            if (problematicDto != null)
              return DtoToDomain(problematicDto,context);
            return null;
        }

        public ProblematicDto UpdateDtoObject(ProblematicDto objToUpdate, Problematic updatedObject, ContextDB context)
        {
            throw new NotImplementedException();
        }
    }
}