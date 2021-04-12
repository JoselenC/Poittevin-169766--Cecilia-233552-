using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class AlreadyExistThisSong:Exception
    {
        public AlreadyExistThisSong() :
            base("Already exist this song")
        { }
    }
}