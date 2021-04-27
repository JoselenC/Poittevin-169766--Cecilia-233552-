using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
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
            return repository.Problematics.Find(x => x.IsSameProblematicName(name));
        }

    }
}