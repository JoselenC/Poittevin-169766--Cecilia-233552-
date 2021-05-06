using System;
using System.Linq;
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
                Name = obj.Name,
                Id = obj.CategoryDtoID
            };
        }

        public Category GetById(ContextDB context, int id)
        {
            CategoryDto categoryDto = context.Categories.FirstOrDefault(m => m.CategoryDtoID == id);
            if(categoryDto!=null)
                return DtoToDomain(categoryDto,context);
            return null;
        }

        public CategoryDto UpdateDtoObject(CategoryDto objToUpdate, Category updatedObject,ContextDB context)
        {
            throw new NotImplementedException();
        }
    }
}