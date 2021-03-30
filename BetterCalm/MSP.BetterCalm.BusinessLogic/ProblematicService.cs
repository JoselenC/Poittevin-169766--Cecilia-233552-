using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class ProblematicService
    {
        private ManagerRepository repository;

        public ProblematicService(ManagerRepository vRepository)
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
            catch (ValueNotFound)
            {
                throw new NoFindProblematicByName();
            }
        }

        public void SetProblematic(Problematic problematic)
        {
            repository.Problematics.Add(problematic);
        }
    }
}