using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlayListDtoTest
    {
        
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistDto song = new PlaylistDto();
            song.PlaylistDtoID = 1;
            Assert.AreEqual(1, song.PlaylistDtoID);
        }
        
        [TestMethod]
        public void GetSetPlaylistName()
        {
            string playlistName = "Entrena tu mente";
            PlaylistDto playlist = new PlaylistDto();
            playlist.Name = "Entrena tu mente";
            string getPlaylistName = playlist.Name;
            Assert.AreEqual(playlistName, getPlaylistName);
        }

        [TestMethod]
        public void GetSetPlaylistUrlAudio()
        {
            string description = "urlAudioName";
            PlaylistDto playlist = new PlaylistDto();
            playlist.Description = "urlAudioName";
            string getPlaylistDescription = playlist.Description;
            Assert.AreEqual(description, getPlaylistDescription);
        }

        [TestMethod]
        public void GetSetPlaylistUrlImage()
        {
            string playlistUrlImage = "UrlImage";
            PlaylistDto playlist = new PlaylistDto();
            playlist.UrlImage = "UrlImage";
            string getplaylistUrlImage = playlist.UrlImage;
            Assert.AreEqual(playlistUrlImage, getplaylistUrlImage);
        }

        [TestMethod]
        public void GetSetPlaylistSongDto()
        {
            PlaylistDto playlist = new PlaylistDto();
            playlist.PlaylistSongsDto = new List<PlaylistSongDto>();
            ICollection<PlaylistSongDto> getPlaylistSong= playlist.PlaylistSongsDto;
            CollectionAssert.AreEqual(getPlaylistSong.ToList(), new List<PlaylistSongDto>());
        }
        
        [TestMethod]
        public void GetSetPlaylistCategoryDto()
        {
            PlaylistDto playlist = new PlaylistDto();
            playlist.PlaylistCategoriesDto = new List<PlaylistCategoryDto>();
            ICollection<PlaylistCategoryDto> getPlaylistSong= playlist.PlaylistCategoriesDto;
            CollectionAssert.AreEqual(getPlaylistSong.ToList(), new List<PlaylistCategoryDto>());
        }
    }
}