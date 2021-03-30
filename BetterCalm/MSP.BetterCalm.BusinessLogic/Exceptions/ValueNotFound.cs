using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class ValueNotFound: Exception
    {
        public ValueNotFound() :
            base("No find category by name")
        { }
    }
}