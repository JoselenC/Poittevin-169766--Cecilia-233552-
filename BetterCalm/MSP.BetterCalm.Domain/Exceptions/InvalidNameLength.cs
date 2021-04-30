using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class InvalidNameLength: Exception
    {
        public InvalidNameLength() :
            base("Invalid empty name")
        { }
    }
}