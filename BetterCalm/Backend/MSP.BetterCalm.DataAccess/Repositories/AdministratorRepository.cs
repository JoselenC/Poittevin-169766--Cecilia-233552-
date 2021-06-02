using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class AdministratorRepository: ManagerAdministratorRepository
    {
        public AdministratorRepository(IMapper<Administrator, AdministratorDto> mapper, ContextDb context)
        {
            Administrators = new DataBaseRepository<Administrator, AdministratorDto>(mapper, context.Administrators, context);
        }
    }
}