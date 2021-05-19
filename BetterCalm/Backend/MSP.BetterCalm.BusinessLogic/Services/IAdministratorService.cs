using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IAdministratorService
    {
        List<Administrator> GetAdministrators();
        Administrator AddAdministrator(Administrator admin);
        
        public void DeleteAdministratorById(int administratorId);
        public Administrator GetAdministratorsById(int administratorId);

        public Administrator UpdateAdministrator(Administrator newAdministrator, int administratorId);
        string Login(string email, string password);
        Administrator GetAdministratorByToken(string toString);
    }
}