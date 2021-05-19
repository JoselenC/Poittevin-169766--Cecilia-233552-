using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistAudioDtoTest
    {
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistAudioDto playlistAudio = new PlaylistAudioDto();
            playlistAudio.PlaylistID = 1;
            Assert.AreEqual(1, playlistAudio.PlaylistID);
        }
        
        [TestMethod]
        public void GetSetAudioId()
        {
            PlaylistAudioDto playlistAudio = new PlaylistAudioDto();
            playlistAudio.AudioID = 1;
            Assert.AreEqual(1, playlistAudio.AudioID);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            PlaylistAudioDto playlistAudio = new PlaylistAudioDto();
            playlistAudio.PlaylistDto = new PlaylistDto();
            Assert.AreEqual(playlistAudio.PlaylistDto, playlistAudio.PlaylistDto);
        }
        
        [TestMethod]
        public void GetSetAudioDto()
        {
            PlaylistAudioDto playlistAudio = new PlaylistAudioDto();
            playlistAudio.AudioDto = new AudioDto();
            Assert.AreEqual(playlistAudio.AudioDto, playlistAudio.AudioDto);
        }
    }
}