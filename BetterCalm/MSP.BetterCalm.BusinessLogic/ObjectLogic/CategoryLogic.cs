using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private ManagerCategoryRepository repository;

        public CategoryLogic(ManagerCategoryRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Category> GetCategories()
        {
            return repository.Categories.Get();
        }            

        public Category GetCategoryByName(string name)
        {
            try
            {
                return repository.Categories.Find(x => x.IsSameCategoryName(name));
            }
            catch (ValueNotFound)
            {
                throw new NoFindCategoryByName();
            }

        }

      
    }
}