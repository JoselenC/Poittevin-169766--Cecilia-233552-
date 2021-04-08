using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PsychologistService : IPsychologistService
    {
        private ManagerPsychologistRepository repository;

        public PsychologistService(ManagerPsychologistRepository vRepository)
        {
            repository = vRepository;
        }

        public List<Psychologist> GetPsychologists()
        {
            return repository.Psychologists.Get();
        }

    }
}