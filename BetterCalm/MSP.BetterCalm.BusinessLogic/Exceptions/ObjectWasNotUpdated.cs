using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class ObjectWasNotUpdated: Exception
    {
        public ObjectWasNotUpdated() :
            base("The id of the object to update does not exist")
        {
        }
    }
}