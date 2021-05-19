using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundCategory:Exception
    {
        public NotFoundCategory() :
            base("No category found")
        { }
    }
}