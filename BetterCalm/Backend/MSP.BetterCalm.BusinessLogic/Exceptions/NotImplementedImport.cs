using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotImplementedImport:Exception
    {
        public NotImplementedImport() :
            base("Nobody implements the interface with that assembly")
        { }
    }
}