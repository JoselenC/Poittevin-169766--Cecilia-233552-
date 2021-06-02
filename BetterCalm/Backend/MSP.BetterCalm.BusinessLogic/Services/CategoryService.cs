using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
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
            return repository.Categories.Get();
        }            

        public Category GetCategoryByName(string name)
        {
            try
            {
                return repository.Categories.Find(x => x.IsSameCategoryName(name));
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundCategory();
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                return repository.Categories.FindById(id);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }
      
    }
}