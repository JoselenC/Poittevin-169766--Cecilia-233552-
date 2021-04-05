using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NoFindSongByAuthor: Exception
    {
    public NoFindSongByAuthor() :
        base("No find song by author")
    { }
    
    }
}