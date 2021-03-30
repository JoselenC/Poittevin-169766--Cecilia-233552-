using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NoFindProblematicByName: Exception
    {
        public NoFindProblematicByName() :
            base("No find category by name")
        { }
    }
}