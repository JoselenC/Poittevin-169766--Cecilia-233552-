using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class VideoRepository:ManagerVideoRepository
    {
        public VideoRepository(IMapper<Video, VideoDto> mapper, ContextDB context)
        {
            Videos = new DataBaseRepository<Video, VideoDto>(mapper, context.Videos, context);
        }
    }
}