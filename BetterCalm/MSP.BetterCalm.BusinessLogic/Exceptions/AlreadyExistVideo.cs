using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class AlreadyExistVideo:Exception
    {
        public AlreadyExistVideo() :
            base("Already exist this video")
        { }
    }
}