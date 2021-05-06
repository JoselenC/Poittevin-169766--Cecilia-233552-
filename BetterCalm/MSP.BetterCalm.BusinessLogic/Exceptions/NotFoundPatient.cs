using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundPatient:Exception
    {
        public NotFoundPatient() :
            base("No Patient found")
        { }
    }
}