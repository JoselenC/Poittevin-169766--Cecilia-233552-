using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistCategoryDtoTest
    {
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistCategoryDto playlistCategory = new PlaylistCategoryDto();
            playlistCategory.PlaylistId = 1;
            Assert.AreEqual(1, playlistCategory.PlaylistId);
        }
        
        [TestMethod]
        public void GetSetCategoryId()
        {
            PlaylistCategoryDto playlistCategory = new PlaylistCategoryDto();
            playlistCategory.CategoryId = 1;
            Assert.AreEqual(1, playlistCategory.CategoryId);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            PlaylistCategoryDto playlistCategory = new PlaylistCategoryDto();
            playlistCategory.CategoryDto = new CategoryDto();
            Assert.AreEqual(playlistCategory.CategoryDto, playlistCategory.CategoryDto);
        }
        
        [TestMethod]
        public void GetSetPlaylistDto()
        {
            PlaylistCategoryDto playlistCategory = new PlaylistCategoryDto();
            playlistCategory.PlaylistDto = new PlaylistDto();
            Assert.AreEqual(playlistCategory.PlaylistDto, playlistCategory.PlaylistDto);
        }
    }
}