using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class SongCategoryDtoTest
    {
        [TestMethod]
        public void GetSetSongId()
        {
            SongCategoryDto song = new SongCategoryDto();
            song.SongID = 1;
            Assert.AreEqual(1, song.SongID);
        }
        
        [TestMethod]
        public void GetSetCategoryId()
        {
            SongCategoryDto song = new SongCategoryDto();
            song.CategoryID = 1;
            Assert.AreEqual(1, song.CategoryID);
        }
        
        [TestMethod]
        public void GetSetSongDto()
        {
            SongCategoryDto song = new SongCategoryDto();
            song.SongDto = new SongDto();
            Assert.AreEqual(song.SongDto, song.SongDto);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            SongCategoryDto song = new SongCategoryDto();
            song.CategoryDto = new CategoryDto();
            Assert.AreEqual(song.CategoryDto, song.CategoryDto);
        }
    }
}