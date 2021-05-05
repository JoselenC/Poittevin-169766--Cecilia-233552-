using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class InvalidUrl:Exception
    {
        public InvalidUrl() :
            base("Invalid url format")
        { }
    }
}