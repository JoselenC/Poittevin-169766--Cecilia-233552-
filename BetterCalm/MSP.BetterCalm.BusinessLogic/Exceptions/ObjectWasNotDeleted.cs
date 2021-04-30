using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class ObjectWasNotDeleted : Exception
    {
        public ObjectWasNotDeleted() :
            base("The id of the object to delete does not exist")
        {
        }
    }
}