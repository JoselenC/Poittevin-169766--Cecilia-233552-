using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
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

        public Administrator AddAdministrator(Administrator admin)
        {
            return repository.Administrators.Add(admin);
        }
        
        public void DeleteAdministratorById(int administratorId)
        {
            
            Administrator administrator = GetAdministratorsById(administratorId);
            repository.Administrators.Delete(administrator);

        }

        public Administrator GetAdministratorsById(int administratorId)
        {
            try
            {

                return repository.Administrators.Find(x => x.AdministratorId == administratorId);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundAdministrator();
            }
        }

        public Administrator UpdateAdministrator(Administrator newAdministrator, int administratorId)
        {
            Administrator oldAdministrator = GetAdministratorsById(administratorId);
            return repository.Administrators.Update(oldAdministrator, newAdministrator);
        }
    }
}