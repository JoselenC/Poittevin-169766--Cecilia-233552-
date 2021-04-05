using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistTest
    {
        [TestMethod]
        public void GetSetSongName()
        {
            string playlistName = "Entrena tu mente";
            Playlist playlist = new Playlist();
            playlist.Name = "Entrena tu mente";
            string getPlaylistName = playlist.Name;
            Assert.AreEqual(playlistName, getPlaylistName);
        }

        [TestMethod]
        public void GetSetSongUrlAudio()
        {
            string description = "urlAudioName";
            Playlist playlist = new Playlist();
            playlist.Description = "urlAudioName";
            string getPlaylistDescription = playlist.Description;
            Assert.AreEqual(description, getPlaylistDescription);
        }

        [TestMethod]
        public void GetSetSongUrlImage()
        {
            string playlistUrlImage = "UrlImage";
            Playlist playlist = new Playlist();
            playlist.UrlImage = "UrlImage";
            string getplaylistUrlImage = playlist.UrlImage;
            Assert.AreEqual(playlistUrlImage, getplaylistUrlImage);
        }

        [TestMethod]
        public void GetSetSongCategories()
        {
            List<Category> categories = new List<Category>();
            Playlist playlist = new Playlist();
            playlist.Categories = categories;
            List<Category> getCategories = playlist.Categories;
            Assert.AreEqual(categories, getCategories);
        }

        [TestMethod]
        public void GetSetPlaylistSongs()
        {
            List<Song> songs = new List<Song>();
            Playlist playlist = new Playlist();
            playlist.Songs = songs;
            List<Song> getSongs = playlist.Songs;
            Assert.AreEqual(songs, getSongs);
        }
        
        [TestMethod]
        public void IsSamePlaylistName()
        {
            Playlist playlist = new Playlist();
            playlist.Name = "Entrena tu mente";
            string playlistName = "Entrena tu mente";
            Assert.IsTrue(playlist.IsSamePlaylistName(playlistName));
        }

        [TestMethod]
        public void IsDiffPlaylistName()
        {
            Playlist playlist = new Playlist();
            playlist.Name = "Entrena tu mente";
            string playlistName = "Para relajar";
            Assert.IsFalse(playlist.IsSamePlaylistName(playlistName));
        }

      [TestMethod]
        public void IsSameCategoryName()
        {
            Playlist playlist = new Playlist();
            playlist.Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Dormir"
                }
            };
            string categoryName = "Dormir";
            Assert.IsTrue(playlist.IsSameCategoryName(categoryName));
        }

        [TestMethod]
        public void IsDifferentCategoryName()
        {
            Playlist playlist = new Playlist();
            playlist.Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Dormir"
                }
            };
            string categoryName = "Musica";
            Assert.IsFalse(playlist.IsSameCategoryName(categoryName));
        }

        [TestMethod]
        public void IsSameSongName()
        {
            Playlist playlist = new Playlist();
            playlist.Songs = new List<Song>()
            {
                new Song(){
            
                    Categories = new List<Category>(),
                    Name = "Let it be",
                    AuthorName = "John Lennon",
                    Duration = 12,
                    UrlAudio = "",
                    UrlImage = ""
                }
            };
            string categoryName = "Let it be";
            Assert.IsTrue(playlist.IsSameSongName(categoryName));
        }

        [TestMethod]
        public void IsDifferentSongName()
        {
            Playlist playlist = new Playlist();
            playlist.Songs = new List<Song>()
            {
                new Song(){
            
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
                }
            };
            string categoryName = "Let it be";
            Assert.IsFalse(playlist.IsSameSongName(categoryName));
        }

    }
}