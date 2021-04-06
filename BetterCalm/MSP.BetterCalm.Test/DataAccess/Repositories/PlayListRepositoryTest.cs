using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlayListRepositoryTest
    {
        [TestMethod]
        public void CategoryRepositoryCreationCategoriesTypeTest()
        {
            PlaylistRepository playlistRepository = new PlaylistRepository( new PlaylistMapper(),new ContextDB());
            Assert.IsInstanceOfType(playlistRepository.Playlists, typeof(DataBaseRepository<Playlist, PlaylistDto>));
        }
    }
}