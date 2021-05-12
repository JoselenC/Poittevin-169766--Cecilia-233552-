using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VideoCategoryDtoTest
    {
        [TestMethod]
        public void GetSetVideoId()
        {
            VideoCategoryDto Video = new VideoCategoryDto();
            Video.VideoID = 1;
            Assert.AreEqual(1, Video.VideoID);
        }
        
        [TestMethod]
        public void GetSetCategoryId()
        {
            VideoCategoryDto Video = new VideoCategoryDto();
            Video.CategoryID = 1;
            Assert.AreEqual(1, Video.CategoryID);
        }
        
        [TestMethod]
        public void GetSetVideoDto()
        {
            VideoCategoryDto Video = new VideoCategoryDto();
            Video.VideoDto = new VideoDto();
            Assert.AreEqual(Video.VideoDto, Video.VideoDto);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            VideoCategoryDto Video = new VideoCategoryDto();
            Video.CategoryDto = new CategoryDto();
            Assert.AreEqual(Video.CategoryDto, Video.CategoryDto);
        }
    }
}