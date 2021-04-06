using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NoFindPlaylistByName:Exception
    {
        public NoFindPlaylistByName() :
            base("No find playlist by name")
        { }
    }
}