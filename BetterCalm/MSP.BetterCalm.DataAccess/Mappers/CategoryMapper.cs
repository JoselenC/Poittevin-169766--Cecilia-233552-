using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryMapper: IMapper<Category, CategoryDto>

    {
        public CategoryDto DomainToDto(Category obj, ContextDB context)
        {
            Microsoft.EntityFrameworkCore.DbSet<CategoryDto> CategorySet = context.Set<CategoryDto>();
            CategoryDto categoryDto = CategorySet.FirstOrDefault(x => x.Name == obj.Name);
            if (categoryDto is null)
            categoryDto = new CategoryDto()
            {
             Name = obj.Name,
            };
            return categoryDto;
            

        }

        public Category DtoToDomain(CategoryDto obj, ContextDB context)
        {
           return new Category()
            {
                Name = obj.Name
            };
        }

        public void UpdateDtoObject<T, D>(T objToUpdate, D updatedObject, ContextDB context) where T : class
        {
            throw new NotImplementedException();
        }
    }
}