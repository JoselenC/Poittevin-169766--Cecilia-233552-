using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class AlreadyExistThisAudio:Exception
    {
        public AlreadyExistThisAudio() :
            base("Already exist this audio")
        { }
    }
}