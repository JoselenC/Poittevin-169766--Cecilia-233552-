using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class PsychologistAlreadyExistException: Exception
    {
        public PsychologistAlreadyExistException() :
            base("Psychologist already exists")
        { }
    }
}