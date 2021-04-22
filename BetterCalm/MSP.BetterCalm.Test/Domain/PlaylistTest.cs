using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistTest
    {
        [TestMethod]
        public void GetSetPlaylistName()
        {
            string playlistName = "Entrena tu mente";
            Playlist playlist = new Playlist();
            playlist.Name = "Entrena tu mente";
            string getPlaylistName = playlist.Name;
            Assert.AreEqual(playlistName, getPlaylistName);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void GetSetPlaylistNameInvalidLength()
        {
            Playlist playlist = new Playlist();
            playlist.Name = "";
        }
        
        [TestMethod]
        public void GetSetPlaylistDescriptionValidLength()
        {
            string playlistDescription = "Entrena tu mente";
            Playlist playlist = new Playlist();
            playlist.Description = "Entrena tu mente";
            string getDescription = playlist.Description;
            Assert.AreEqual(playlistDescription, getDescription);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDescriptionLength), "")]
        public void GetSetPlaylistDescriptionInvalidLength()
        {
            Playlist playlist = new Playlist();
            playlist.Description = "12312321231231231232131231231231231231" +
                                   "12333333333333333333333333333333333123333333333" +
                                   "1233333333333333333333333123333333333331322222" +
                                   "1233123111111111123";
        }

        [TestMethod]
        public void GetSetPlaylistUrlAudio()
        {
            string description = "urlAudioName";
            Playlist playlist = new Playlist();
            playlist.Description = "urlAudioName";
            string getPlaylistDescription = playlist.Description;
            Assert.AreEqual(description, getPlaylistDescription);
        }

        [TestMethod]
        public void GetSetPlaylistId()
        {
            int id = 1;
            Playlist playlist = new Playlist();
            playlist.Id = 1;
            int getPlaylistId= playlist.Id;
            Assert.AreEqual(id, getPlaylistId);
        }
        
        [TestMethod]
        public void GetSetPlaylistUrlImage()
        {
            string playlistUrlImage = "UrlImage";
            Playlist playlist = new Playlist();
            playlist.UrlImage = "UrlImage";
            string getplaylistUrlImage = playlist.UrlImage;
            Assert.AreEqual(playlistUrlImage, getplaylistUrlImage);
        }

        [TestMethod]
        public void GetSetPlaylistCategories()
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
        
        [TestMethod]
        public void EqualsPlaylist()
        {
            Playlist playlist = new Playlist()
            {
                Id=1,
              Name  = "Entrena tu mente",
              Description = "para despejar",
              UrlImage="url"
            };
            Assert.AreEqual(playlist, playlist);
        }
        
        [TestMethod]
        public void NotEqualsPlaylistNull()
        {
            Playlist playlist = new Playlist()
            {
                Id=1,
                Name  = "Entrena tu mente",
                Description = "para despejar",
                UrlImage="url"
            };
            Assert.AreNotEqual(playlist, null);
        }
        
        [TestMethod]
        public void PlaylistNull()
        {
            Playlist playlist=null;
            Assert.IsNull(playlist);
        }
        
        [TestMethod]
        public void NotPlaylistNull()
        {
            Playlist playlist = new Playlist();
            Assert.IsNotNull(playlist);
        }
        
        [TestMethod]
        public void NotEqualsPlaylistId()
        {
            Playlist playlist = new Playlist()
            {
                Id=1,
                Name  = "Entrena tu mente",
                Description = "para despejar",
                UrlImage="url"
            };
            Playlist playlistToCompare = new Playlist()
            {
                Id=2,
                Name  = "Entrena tu mente2",
                Description = "para despejar",
                UrlImage="url"
            };
            Assert.AreNotEqual(playlist, playlistToCompare);
        }
        
        [TestMethod]
        public void NotEqualsPlaylistType()
        {
            Category category = new Category();
            Playlist playlist = new Playlist()
            {
                Id=1,
                Name  = "Entrena tu mente",
                Description = "para despejar",
                UrlImage="url"
            };
            Assert.AreNotEqual(category, playlist);
        }
        
       
    }
}