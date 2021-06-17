using System;
using System.Linq;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Mappers
{
    public class CategoryMapper: IMapper<Category, CategoryDto>

    {
        public CategoryDto DomainToDto(Category obj,ContextDb context)
        {
            CategoryDto categoryDto = context.Categories.FirstOrDefault(x => x.Name == obj.Name);
            if (categoryDto is null)
                categoryDto = new CategoryDto()
            {
                Name = obj.Name,
            };
            return categoryDto;
        }

        public Category DtoToDomain(CategoryDto obj,ContextDb context)
        {
           return new Category()
            {
                Name = obj.Name,
                Id = obj.CategoryDtoId
            };
        }

        public Category GetById(ContextDb context, int id)
        {
            CategoryDto categoryDto = context.Categories.FirstOrDefault(m => m.CategoryDtoId == id);
            if(categoryDto!=null)
                return DtoToDomain(categoryDto,context);
            return null;
        }

        public CategoryDto UpdateDtoObject(CategoryDto objToUpdate, Category updatedObject,ContextDb context)
        {
            throw new NotImplementedException();
        }
    }
}