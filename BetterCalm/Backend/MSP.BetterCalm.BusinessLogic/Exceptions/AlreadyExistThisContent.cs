using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class AlreadyExistThisContent:Exception
    {
        public AlreadyExistThisContent() :
            base("Already exist this content")
        { }
    }
}