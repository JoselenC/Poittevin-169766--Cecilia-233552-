using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundAudio:Exception
    {
        public NotFoundAudio() :
            base("No audio found")
        { }
    }
}