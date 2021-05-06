using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundProblematic:Exception
    {
        public NotFoundProblematic() :
            base("No problematic found")
        { }
        
    }
}