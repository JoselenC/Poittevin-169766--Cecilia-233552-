using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class InvalidCategory:Exception
    {
        public InvalidCategory() :
            base("Invalid category")
        { }
    }
}