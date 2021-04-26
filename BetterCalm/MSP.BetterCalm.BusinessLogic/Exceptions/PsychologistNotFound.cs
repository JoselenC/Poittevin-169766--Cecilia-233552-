using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class PsychologistNotFound: Exception
    {
        public PsychologistNotFound() :
                    base("Psychologist not found")
        { }
    }
}