using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class ProblematicMapper: IMapper<Problematic, ProblematicDto>

    {
        public ProblematicDto DomainToDto(Problematic obj, ContextDB context)
        {
            Microsoft.EntityFrameworkCore.DbSet<ProblematicDto> problematicSet = context.Set<ProblematicDto>();
            ProblematicDto problematicDto = problematicSet.FirstOrDefault(x => x.Name == obj.Name);
            if (problematicDto is null)
                problematicDto = new ProblematicDto()
                {
                    Name = obj.Name,
                };
            return problematicDto;
        }

        public Problematic DtoToDomain(ProblematicDto obj, ContextDB context)
        {
            return new Problematic()
            {
                Name = obj.Name
            };
        }

        public void UpdateDtoObject<T, D>(T objToUpdate, D updatedObject, ContextDB context) where T : class
        {
            throw new NotImplementedException();
        }
    }
}