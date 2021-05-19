using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class AdministratorRepository: ManagerAdministratorRepository
    {
        public AdministratorRepository(IMapper<Administrator, AdministratorDto> mapper, ContextDB context)
        {
            Administrators = new DataBaseRepository<Administrator, AdministratorDto>(mapper, context.Administrators, context);
        }
    }
}