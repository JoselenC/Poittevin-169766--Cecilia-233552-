using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryRepository:ManagerCategoryRepository
    {
    public CategoryRepository(IMapper<Category, CategoryDto> mapper, ContextDB context)
    {
        this.Categories = new DataBaseRepository<Category, CategoryDto>(mapper, context.Categories, context);
    }
    
    }
}