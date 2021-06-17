using System;

namespace MSP.BetterCalm.Domain.Exceptions
{
    public class InvalidDescriptionLength: Exception
    {
        public InvalidDescriptionLength() :
            base("Invalid description length")
        { }
        
    }
}