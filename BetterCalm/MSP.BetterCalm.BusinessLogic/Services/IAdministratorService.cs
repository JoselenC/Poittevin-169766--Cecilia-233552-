using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IAdministratorService
    {
        List<Administrator> GetAdministrators();
        void AddAdministrator(Administrator admin);
    }
}