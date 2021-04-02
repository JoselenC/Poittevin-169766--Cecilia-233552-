using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class ProblematicRepository :ManagerRepository
    {
        public ProblematicRepository(IMapper<Problematic, ProblematicDto> mapper, ContextDB context)
        {
            this.Problematics = new DataBaseRepository<Problematic, ProblematicDto>(mapper, context.Problematics, context);
        }

    }
}