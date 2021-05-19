using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundAdministrator: Exception
    {
        public NotFoundAdministrator() :
            base("Administrator not found")
        { }
    }
}