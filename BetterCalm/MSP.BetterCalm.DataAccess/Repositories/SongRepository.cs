using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class SongRepository:ManagerSongRepository
    {
        public SongRepository(IMapper<Song, SongDto> mapper, ContextDB context)
        {
            Songs = new DataBaseRepository<Song, SongDto>(mapper, context.Songs, context);
        }
    }
}