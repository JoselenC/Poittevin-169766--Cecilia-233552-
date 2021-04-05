using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NoFindSongByName: Exception
    {
        public NoFindSongByName() :
            base("No find song by name")
        { }
    }
}