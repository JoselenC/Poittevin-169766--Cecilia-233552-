using System;

namespace MSP.BetterCalm.Domain.Exceptions
{
    public class InvalidContentType : Exception
    {
        public InvalidContentType() :
            base("Invalid content type,the contents supported by the system ares audio or video")
        {
        }

    }
}