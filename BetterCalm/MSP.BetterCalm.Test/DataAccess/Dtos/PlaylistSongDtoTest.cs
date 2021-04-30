using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistSongDtoTest
    {
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistSongDto playlistSong = new PlaylistSongDto();
            playlistSong.PlaylistID = 1;
            Assert.AreEqual(1, playlistSong.PlaylistID);
        }
        
        [TestMethod]
        public void GetSetSongId()
        {
            PlaylistSongDto playlistSong = new PlaylistSongDto();
            playlistSong.SongID = 1;
            Assert.AreEqual(1, playlistSong.SongID);
        }
        
        [TestMethod]
        public void GetSetCategoryDto()
        {
            PlaylistSongDto playlistSong = new PlaylistSongDto();
            playlistSong.PlaylistDto = new PlaylistDto();
            Assert.AreEqual(playlistSong.PlaylistDto, playlistSong.PlaylistDto);
        }
        
        [TestMethod]
        public void GetSetSongDto()
        {
            PlaylistSongDto playlistSong = new PlaylistSongDto();
            playlistSong.SongDto = new SongDto();
            Assert.AreEqual(playlistSong.SongDto, playlistSong.SongDto);
        }
    }
}