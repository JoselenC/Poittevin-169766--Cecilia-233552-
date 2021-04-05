using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface ICategoryLogic
    {
        public List<Category> GetCategories();

        public Category GetCategoryByName(string name);

    }
}