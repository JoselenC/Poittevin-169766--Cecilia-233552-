using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class ProblematicMapper: IMapper<Problematic, ProblematicDto>

    {
        private ContextDB context;
        private DbSet<ProblematicDto> problematicSet;

        public ProblematicMapper(DbSet<ProblematicDto> problematicSet)
        {
            this.problematicSet = problematicSet;
        }

        public ProblematicDto DomainToDto(Problematic obj)
        {
            ProblematicDto problematicDto = problematicSet.FirstOrDefault(x => x.Name == obj.Name);
            if (problematicDto is null)
                problematicDto = new ProblematicDto()
                {
                    Name = obj.Name,
                };
            return problematicDto;
        }

        public Problematic DtoToDomain(ProblematicDto obj)
        {
            return new Problematic()
            {
                Name = obj.Name
            };
        }

        public void UpdateDtoObject<T, D>(T objToUpdate, D updatedObject) where T : class
        {
            throw new NotImplementedException();
        }
    }
}