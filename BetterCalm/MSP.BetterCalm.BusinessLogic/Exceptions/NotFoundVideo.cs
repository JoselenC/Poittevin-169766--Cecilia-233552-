using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundVideo:Exception
    {
        public NotFoundVideo() :
            base("No video found")
        { }
    }
}