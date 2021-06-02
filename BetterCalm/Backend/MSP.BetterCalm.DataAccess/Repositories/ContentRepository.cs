using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class ContentRepository:ManagerContentRepository
    {
        public ContentRepository(IMapper<Content, ContentDto> mapper, ContextDb context)
        {
            Contents = new DataBaseRepository<Content, ContentDto>(mapper, context.Contents, context);
        }
    }
}