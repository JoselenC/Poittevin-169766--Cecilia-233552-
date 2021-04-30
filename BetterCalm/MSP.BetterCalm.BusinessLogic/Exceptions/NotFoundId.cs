using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundId:Exception
    {
        public NotFoundId() :
            base("The specified id does not exist in the database")
        { }
    }
}