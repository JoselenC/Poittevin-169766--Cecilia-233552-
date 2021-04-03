using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class ProblematicMapper: IMapper<Problematic, ProblematicDto>

    {
        public ProblematicDto DomainToDto(Problematic obj,DbSet<ProblematicDto> problematicSet)
        {
            ProblematicDto problematicDto = problematicSet.FirstOrDefault(x => x.Name == obj.Name);
            if (problematicDto is null)
                problematicDto = new ProblematicDto()
                {
                    Name = obj.Name,
                };
            return problematicDto;
        }

        public Problematic DtoToDomain(ProblematicDto obj,DbSet<ProblematicDto> problematicSet)
        {
            return new Problematic()
            {
                Name = obj.Name
            };
        }

        public void UpdateDtoObject(ProblematicDto objToUpdate, Problematic updatedObject, DbSet<ProblematicDto> entity)
        {
            throw new NotImplementedException();
        }

    }
}