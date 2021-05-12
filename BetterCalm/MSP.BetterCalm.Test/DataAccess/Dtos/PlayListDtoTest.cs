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
            PlaylistDto Audio = new PlaylistDto();
            Audio.PlaylistDtoID = 1;
            Assert.AreEqual(1, Audio.PlaylistDtoID);
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
        public void GetSetPlaylistAudioDto()
        {
            PlaylistDto playlist = new PlaylistDto();
            playlist.PlaylistAudiosDto = new List<PlaylistAudioDto>();
            ICollection<PlaylistAudioDto> getPlaylistAudio= playlist.PlaylistAudiosDto;
            CollectionAssert.AreEqual(getPlaylistAudio.ToList(), new List<PlaylistAudioDto>());
        }
        
        [TestMethod]
        public void GetSetPlaylistCategoryDto()
        {
            PlaylistDto playlist = new PlaylistDto();
            playlist.PlaylistCategoriesDto = new List<PlaylistCategoryDto>();
            ICollection<PlaylistCategoryDto> getPlaylistAudio= playlist.PlaylistCategoriesDto;
            CollectionAssert.AreEqual(getPlaylistAudio.ToList(), new List<PlaylistCategoryDto>());
        }
        
        [TestMethod]
        public void GetSetPlaylistVideoDto()
        {
            PlaylistDto playlist = new PlaylistDto();
            playlist.PlaylistsVideosDto = new List<PlaylistVideoDto>();
            ICollection<PlaylistVideoDto> getPlaylistAudio= playlist.PlaylistsVideosDto;
            CollectionAssert.AreEqual(getPlaylistAudio.ToList(), new List<PlaylistVideoDto>());
        }
    }
}