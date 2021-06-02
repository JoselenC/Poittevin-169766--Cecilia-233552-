using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class AdministratorService : IAdministratorService
    {
        private ManagerAdministratorRepository _repository;
        private IGuidService _guidService;

        public AdministratorService(ManagerAdministratorRepository vRepository, IGuidService vGuid)
        {
            _repository = vRepository;
            _guidService = vGuid;
        }

        public List<Administrator> GetAdministrators()
        {
            return _repository.Administrators.Get();
        }

        public Administrator AddAdministrator(Administrator admin)
        {
            return _repository.Administrators.Add(admin);
        }
        
        public void DeleteAdministratorById(int administratorId)
        {
            
            Administrator administrator = GetAdministratorsById(administratorId);
            _repository.Administrators.Delete(administrator);

        }

        public Administrator GetAdministratorsById(int administratorId)
        {
            try
            {

                return _repository.Administrators.Find(x => x.AdministratorId == administratorId);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundAdministrator();
            }
        }

        public Administrator UpdateAdministrator(Administrator newAdministrator, int administratorId)
        {
            Administrator oldAdministrator = GetAdministratorsById(administratorId);
            return _repository.Administrators.Update(oldAdministrator, newAdministrator);
        }

        public string Login(string email, string password)
        {
            try
            {
                Administrator administrator = _repository.Administrators.Find(
                    x => x.Email == email && x.Password == password);
                administrator.Token = _guidService.NewGuid().ToString();
                UpdateAdministrator(administrator, administrator.AdministratorId);
                return administrator.Token;
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundAdminLoginError();
            }
        }

        public Administrator GetAdministratorByToken(string token)
        {
            try
            {
                return _repository.Administrators.Find(x => x.Token == token);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundAdministrator();
            }
        }
    }
}