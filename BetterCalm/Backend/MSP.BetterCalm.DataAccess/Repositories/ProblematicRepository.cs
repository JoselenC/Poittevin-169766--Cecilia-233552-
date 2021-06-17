using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class ProblematicRepository:ManagerProblematicRepository
    {
        public ProblematicRepository(IMapper<Problematic, ProblematicDto> mapper, ContextDb context)
        {
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(mapper, context.Problematics, context);
        }

    }
}