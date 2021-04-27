using System;

namespace MSP.BetterCalm.BusinessLogic.Exceptions
{
    public class CategoryNotFound: Exception
    {
        public CategoryNotFound() :
            base("No find category by name")
        { }
    }
}