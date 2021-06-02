using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundContent:Exception
    {
        public NotFoundContent() :
            base("No content found")
        { }
    }
}