using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        private ManagerCategoryRepository repository;

        public CategoryService(ManagerCategoryRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Category> GetCategories()
        {
            List<Category> categories= repository.Categories.Get();
            List<Category> getCategories = new List<Category>();
            foreach (var category in categories)
            {
                if(!getCategories.Contains(category))
                    getCategories.Add(category);
            }

            return getCategories;
        }            

        public Category GetCategoryByName(string name)
        {
            try
            {
                return repository.Categories.Find(x => x.IsSameCategoryName(name));
            }
            catch (ValueNotFound)
            {
                throw new ValueNotFound();
            }

        }

      
    }
}