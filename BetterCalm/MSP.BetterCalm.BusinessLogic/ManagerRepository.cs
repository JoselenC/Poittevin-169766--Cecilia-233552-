using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class ManagerRepository
    {
        public IRepository<Category> Categories;
        public IRepository<Problematic> Problematics;

    }
}