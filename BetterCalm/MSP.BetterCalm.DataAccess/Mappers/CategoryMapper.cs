using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryMapper: IMapper<Category, CategoryDto>

    {
        private DbSet<CategoryDto> categorySet;

        public CategoryMapper(DbSet<CategoryDto> categorySet)
        {
            this.categorySet = categorySet;
        }

        public CategoryDto DomainToDto(Category obj)
        {
            CategoryDto categoryDto = categorySet.FirstOrDefault(x => x.Name == obj.Name);
            if (categoryDto is null)
                categoryDto = new CategoryDto()
            {
             Name = obj.Name,
            };
            return categoryDto;
        }

        public Category DtoToDomain(CategoryDto obj)
        {
           return new Category()
            {
                Name = obj.Name
            };
        }

        public void UpdateDtoObject<T, D>(T objToUpdate, D updatedObject) where T : class
        {
            throw new NotImplementedException();
        }
    }
}