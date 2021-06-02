using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ContentCategoryDtoTest
    {
        [TestMethod]
        public void GetSetContentId()
        {
            ContentCategoryDto content = new ContentCategoryDto();
            content.ContentId = 1;
            Assert.AreEqual(1, content.ContentId);
        }
        
        [TestMethod]
        public void GetSetCategoryId()
        {
            ContentCategoryDto content = new ContentCategoryDto();
            content.CategoryId = 1;
            Assert.AreEqual(1, content.CategoryId);
        }
        
        [TestMethod]
        public void GetSetContentDto()
        {
            ContentCategoryDto content = new ContentCategoryDto();
            content.ContentDto = new ContentDto();
            Assert.AreEqual(content.ContentDto, content.ContentDto);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            ContentCategoryDto content = new ContentCategoryDto();
            content.CategoryDto = new CategoryDto();
            Assert.AreEqual(content.CategoryDto, content.CategoryDto);
        }
    }
}