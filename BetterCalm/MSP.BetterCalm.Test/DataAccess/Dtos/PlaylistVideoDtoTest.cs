using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistVideoDtoTest
    {
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistVideoDto playlistVideo = new PlaylistVideoDto();
            playlistVideo.PlaylistID = 1;
            Assert.AreEqual(1, playlistVideo.PlaylistID);
        }
        
        [TestMethod]
        public void GetSetVideoId()
        {
            PlaylistVideoDto playlistVideo = new PlaylistVideoDto();
            playlistVideo.VideoID = 1;
            Assert.AreEqual(1, playlistVideo.VideoID);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            PlaylistVideoDto playlistVideo = new PlaylistVideoDto();
            playlistVideo.PlaylistDto = new PlaylistDto();
            Assert.AreEqual(playlistVideo.PlaylistDto, playlistVideo.PlaylistDto);
        }
        
        [TestMethod]
        public void GetSetVideoDto()
        {
            PlaylistVideoDto playlistVideo = new PlaylistVideoDto();
            playlistVideo.VideoDto = new VideoDto();
            Assert.AreEqual(playlistVideo.VideoDto, playlistVideo.VideoDto);
        }
    }
}