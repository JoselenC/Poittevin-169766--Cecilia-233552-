using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class InvalidDescriptionLength: Exception
    {
        public InvalidDescriptionLength() :
            base("Invalid description length")
        { }
        
    }
}