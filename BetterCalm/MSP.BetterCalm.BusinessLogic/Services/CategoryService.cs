﻿using System.Collections.Generic;
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
            return repository.Categories.Find(x => x.IsSameCategoryName(name));
        }

        public Category GetCategoryById(int id)
        {
            try{
            return repository.Categories.FindById(id);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }
      
    }
}