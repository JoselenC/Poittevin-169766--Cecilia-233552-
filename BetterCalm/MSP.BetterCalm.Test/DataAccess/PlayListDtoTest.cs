using System.Collections.Generic;
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
        public void GetSetPlaylistCategories()
        {
            List<CategoryDto> categories = new List<CategoryDto>();
            PlaylistDto playlist = new PlaylistDto();
            playlist.Categories = categories;
            List<CategoryDto> getCategories = playlist.Categories;
            Assert.AreEqual(categories, getCategories);
        }

        [TestMethod]
        public void GetSetPlaylistSongs()
        {
            List<SongDto> songs = new List<SongDto>();
            PlaylistDto playlist = new PlaylistDto();
            playlist.Songs = songs;
            List<SongDto> getSongs = playlist.Songs;
            Assert.AreEqual(songs, getSongs);
        }
    }
}