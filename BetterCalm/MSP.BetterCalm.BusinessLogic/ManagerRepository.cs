using System;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class ManagerRepository : IManagerRepository
    {
        public IRepository<Category> Categories;
        public IRepository<Problematic> Problematics;
        
    }
}