using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NotFoundPlaylist:Exception
    {
        public NotFoundPlaylist() :
            base("No playlist found")
        { }
    }
}