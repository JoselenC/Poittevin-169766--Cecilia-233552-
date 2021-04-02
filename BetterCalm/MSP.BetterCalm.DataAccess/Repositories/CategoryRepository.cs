using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryRepository:ManagerRepository
    {
        public CategoryRepository(IMapper<Category, CategoryDto> mapper, ContextDB context)
        {
            this.Categories = new DataBaseRepository<Category, CategoryDto>(mapper, context.Categories, context);
        }
    }
}