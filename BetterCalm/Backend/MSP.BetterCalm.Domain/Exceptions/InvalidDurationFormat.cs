using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class InvalidDurationFormat:Exception
    {
        public InvalidDurationFormat() :
            base("Invalid duration format")
        { }
    }
}