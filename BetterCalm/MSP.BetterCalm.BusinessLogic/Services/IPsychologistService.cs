using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IPsychologistService
    {
        List<Psychologist> GetPsychologists();
        void SetPsychologist(Psychologist psychologist);
    }
}