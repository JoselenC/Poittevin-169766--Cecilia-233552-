using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistRepository : ManagerPlaylistRepository
    {
        public PlaylistRepository(IMapper<Playlist, PlaylistDto> mapper, ContextDB context)
        {
            this.Playlists = new DataBaseRepository<Playlist, PlaylistDto>(mapper, context.Playlists, context);
        }
    }
}