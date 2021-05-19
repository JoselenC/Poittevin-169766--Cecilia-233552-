using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VideoRepositoryTest
    {
        [TestMethod]
        public void VideoRepositoryCreationCategoriesTypeTest()
        {
            VideoRepository VideoRepository = new VideoRepository(new VideoMapper(),new ContextDB());
            Assert.IsInstanceOfType(VideoRepository.Videos, typeof(DataBaseRepository<Video, VideoDto>));
        }
    }
}