using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundPsychologist : Exception
    {
        public NotFoundPsychologist() :
            base("No Psychologist found")
        {
        }
    }
}