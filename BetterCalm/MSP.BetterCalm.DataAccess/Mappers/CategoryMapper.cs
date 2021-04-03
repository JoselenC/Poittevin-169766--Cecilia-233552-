using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryMapper: IMapper<Category, CategoryDto>

    {
        public CategoryDto DomainToDto(Category obj,DbSet<CategoryDto> categorySet)
        {
            CategoryDto categoryDto = categorySet.FirstOrDefault(x => x.Name == obj.Name);
            if (categoryDto is null)
                categoryDto = new CategoryDto()
            {
             Name = obj.Name,
            };
            return categoryDto;
        }

        public Category DtoToDomain(CategoryDto obj,DbSet<CategoryDto> categorySet)
        {
           return new Category()
            {
                Name = obj.Name
            };
        }

        public void UpdateDtoObject(CategoryDto objToUpdate, Category updatedObject, DbSet<CategoryDto> entity)
        {
            throw new NotImplementedException();
        }

    }
}