using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlayListDtoTest
    {
        
        [TestMethod]
        public void GetSetPlaylistId()
        {
            PlaylistDto Content = new PlaylistDto();
            Content.PlaylistDtoId = 1;
            Assert.AreEqual(1, Content.PlaylistDtoId);
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
        public void GetSetPlaylistUrlContent()
        {
            string description = "urlContentName";
            PlaylistDto playlist = new PlaylistDto();
            playlist.Description = "urlContentName";
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
        public void GetSetPlaylistContentDto()
        {
            PlaylistDto playlist = new PlaylistDto();
            playlist.PlaylistContentsDto = new List<PlaylistContentDto>();
            ICollection<PlaylistContentDto> getPlaylistContent= playlist.PlaylistContentsDto;
            CollectionAssert.AreEqual(getPlaylistContent.ToList(), new List<PlaylistContentDto>());
        }
        
        [TestMethod]
        public void GetSetPlaylistCategoryDto()
        {
            PlaylistDto playlist = new PlaylistDto();
            playlist.PlaylistCategoriesDto = new List<PlaylistCategoryDto>();
            ICollection<PlaylistCategoryDto> getPlaylistContent= playlist.PlaylistCategoriesDto;
            CollectionAssert.AreEqual(getPlaylistContent.ToList(), new List<PlaylistCategoryDto>());
        }
    }
}