using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistCategoryDtoTest
    {
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistCategoryDto playlistCategory = new PlaylistCategoryDto();
            playlistCategory.PlaylistID = 1;
            Assert.AreEqual(1, playlistCategory.PlaylistID);
        }
        
        [TestMethod]
        public void GetSetCategoryId()
        {
            PlaylistCategoryDto playlistCategory = new PlaylistCategoryDto();
            playlistCategory.CategoryID = 1;
            Assert.AreEqual(1, playlistCategory.CategoryID);
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