using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class AdministratorService : IAdministratorService
    {
        private ManagerAdministratorRepository repository;

        public AdministratorService(ManagerAdministratorRepository vRepository)
        {
            repository = vRepository;
        }

        public List<Administrator> GetAdministrators()
        {
            return repository.Administrators.Get();
        }
    }
}