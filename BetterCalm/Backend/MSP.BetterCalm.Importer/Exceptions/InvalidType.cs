using System;

namespace MSP.BetterCalm.Importer
{
    public class InvalidType:Exception
    {
        public InvalidType() :
            base("the type of the parameter must be: string, int, date, bool")
        { }
    }
}