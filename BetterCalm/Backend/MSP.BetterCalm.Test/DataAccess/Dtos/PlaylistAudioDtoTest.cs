using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistContentDtoTest
    {
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistContentDto playlistContent = new PlaylistContentDto();
            playlistContent.PlaylistId = 1;
            Assert.AreEqual(1, playlistContent.PlaylistId);
        }
        
        [TestMethod]
        public void GetSetContentId()
        {
            PlaylistContentDto playlistContent = new PlaylistContentDto();
            playlistContent.ContentId = 1;
            Assert.AreEqual(1, playlistContent.ContentId);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            PlaylistContentDto playlistContent = new PlaylistContentDto();
            playlistContent.PlaylistDto = new PlaylistDto();
            Assert.AreEqual(playlistContent.PlaylistDto, playlistContent.PlaylistDto);
        }
        
        [TestMethod]
        public void GetSetContentDto()
        {
            PlaylistContentDto playlistContent = new PlaylistContentDto();
            playlistContent.ContentDto = new ContentDto();
            Assert.AreEqual(playlistContent.ContentDto, playlistContent.ContentDto);
        }
    }
}