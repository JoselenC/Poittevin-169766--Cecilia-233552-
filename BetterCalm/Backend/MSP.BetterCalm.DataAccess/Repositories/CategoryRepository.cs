using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class CategoryRepository:ManagerCategoryRepository
    {
    public CategoryRepository(IMapper<Category, CategoryDto> mapper, ContextDb context)
    {
        this.Categories = new DataBaseRepository<Category, CategoryDto>(mapper, context.Categories, context);
    }
    
    }
}