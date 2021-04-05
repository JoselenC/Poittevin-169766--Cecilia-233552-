using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class SongRepositoryTest
    {
        [TestMethod]
        public void SongRepositoryCreationCategoriesTypeTest()
        {
            SongRepository songRepository = new SongRepository(new SongMapper(),new ContextDB());
            Assert.IsInstanceOfType(songRepository.Songs, typeof(DataBaseRepository<Song, SongDto>));
        }
    }
}