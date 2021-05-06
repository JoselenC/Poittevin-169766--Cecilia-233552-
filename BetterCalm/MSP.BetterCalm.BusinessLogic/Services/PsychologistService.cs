using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
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
        public Psychologist GetPsychologistsById(int psychologistId)
        {
            try
            {

                return repository.Psychologists.Find(x => x.PsychologistId == psychologistId);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundPsychologist();
            }
        }
        public Psychologist SetPsychologist(Psychologist psychologist)
        {
            return repository.Psychologists.Add(psychologist);
        }

        public void DeletePsychologistById(int psychologistId)
        {
            
            Psychologist psychologist = GetPsychologistsById(psychologistId);
            repository.Psychologists.Delete(psychologist);

        }

        public Psychologist UpdatePsychologist(Psychologist newPsychologist, int psychologistId)
        {
            Psychologist oldPsychologist = GetPsychologistsById(psychologistId);
            return repository.Psychologists.Update(oldPsychologist, newPsychologist);
        }
    }
}