using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AudioCategoryDtoTest
    {
        [TestMethod]
        public void GetSetAudioId()
        {
            AudioCategoryDto audio = new AudioCategoryDto();
            audio.AudioID = 1;
            Assert.AreEqual(1, audio.AudioID);
        }
        
        [TestMethod]
        public void GetSetCategoryId()
        {
            AudioCategoryDto audio = new AudioCategoryDto();
            audio.CategoryID = 1;
            Assert.AreEqual(1, audio.CategoryID);
        }
        
        [TestMethod]
        public void GetSetAudioDto()
        {
            AudioCategoryDto audio = new AudioCategoryDto();
            audio.AudioDto = new AudioDto();
            Assert.AreEqual(audio.AudioDto, audio.AudioDto);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            AudioCategoryDto audio = new AudioCategoryDto();
            audio.CategoryDto = new CategoryDto();
            Assert.AreEqual(audio.CategoryDto, audio.CategoryDto);
        }
    }
}