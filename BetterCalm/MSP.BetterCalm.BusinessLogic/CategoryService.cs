using System.Collections.Generic;
using System.Linq.Expressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class CategoryService
    {
        private ManagerRepository repository;

        public CategoryService(ManagerRepository vRepository)
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

        public void SetCategory(Category category)
        {
            repository.Categories.Add(category);
        }
    }
}