using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class InvalidProblematic : Exception
    {
        public InvalidProblematic() :
            base("Invalid problematic")
        {
        }
    }
}