using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryMapper: IMapper<Category, CategoryDto>

    {
        public CategoryDto DomainToDto(Category obj,ContextDB context)
        {
            CategoryDto categoryDto = context.Categories.FirstOrDefault(x => x.Name == obj.Name);
            if (categoryDto is null)
                categoryDto = new CategoryDto()
            {
             Name = obj.Name,
            };
            return categoryDto;
        }

        public Category DtoToDomain(CategoryDto obj,ContextDB context)
        {
           return new Category()
            {
                Name = obj.Name
            };
        }

        public CategoryDto UpdateDtoObject(CategoryDto objToUpdate, Category updatedObject,ContextDB context)
        {
            throw new NotImplementedException();
        }
    }
}