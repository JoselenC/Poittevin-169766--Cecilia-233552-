using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlayListRepositoryTest
    {
        [TestMethod]
        public void CategoryRepositoryCreationCategoriesTypeTest()
        {
            PlaylistRepository playlistRepository = new PlaylistRepository( new PlaylistMapper(),new ContextDb());
            Assert.IsInstanceOfType(playlistRepository.Playlists, typeof(DataBaseRepository<Playlist, PlaylistDto>));
        }
    }
}