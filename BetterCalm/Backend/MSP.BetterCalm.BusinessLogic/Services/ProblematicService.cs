using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class ProblematicService : IProblematicService
    {
        private ManagerProblematicRepository repository;

        public ProblematicService(ManagerProblematicRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Problematic> GetProblematics()
        {
            return repository.Problematics.Get();
        }

        public Problematic GetProblematicByName(string name)
        {
            try
            {
                return repository.Problematics.Find(x => x.IsSameProblematicName(name));
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundProblematic();
            }
        }

        public Problematic GetProblematicById(int id)
        {
            try
            {
                return repository.Problematics.FindById(id);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }

    }
}