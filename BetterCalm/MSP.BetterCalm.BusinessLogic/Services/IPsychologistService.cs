using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IPsychologistService
    {
        public List<Psychologist> GetPsychologists();
        public Psychologist SetPsychologist(Psychologist psychologist);
        public void DeletePsychologistById(int psychologistId);
        Psychologist GetPsychologistsById(int psychologistId);
        
    }
}