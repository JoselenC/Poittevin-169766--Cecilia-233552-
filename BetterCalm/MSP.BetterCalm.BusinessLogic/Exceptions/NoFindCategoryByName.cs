using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class NoFindCategoryByName: Exception
    {
        public NoFindCategoryByName() :
            base("No find category by name")
        { }
    }
    
}