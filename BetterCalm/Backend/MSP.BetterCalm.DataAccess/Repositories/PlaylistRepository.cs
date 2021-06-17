using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Repositories
{
    public class PlaylistRepository : ManagerPlaylistRepository
    {
        public PlaylistRepository(IMapper<Playlist, PlaylistDto> mapper, ContextDb context)
        {
            this.Playlists = new DataBaseRepository<Playlist, PlaylistDto>(mapper, context.Playlists, context);
        }
    }
}