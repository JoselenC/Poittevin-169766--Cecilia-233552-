using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class InvalidAmountOfProblematicsError: Exception
    {

        public InvalidAmountOfProblematicsError(): base("The Amount of Problematics should be exactly 3")
        {
            
        }
    }
}