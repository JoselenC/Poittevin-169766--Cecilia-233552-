using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class ProblematicRepository:ManagerProblematicRepository
    {
        public ProblematicRepository(IMapper<Problematic, ProblematicDto> mapper, ContextDB context)
        {
            Problematics = new DataBaseRepository<Problematic, ProblematicDto>(mapper, context.Problematics, context);
        }

    }
}