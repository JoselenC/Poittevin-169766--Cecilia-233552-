using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NoFindSongByNameAndAuthor: Exception
    {
        public NoFindSongByNameAndAuthor() :
            base("No find song by name")
        { }
    }
}