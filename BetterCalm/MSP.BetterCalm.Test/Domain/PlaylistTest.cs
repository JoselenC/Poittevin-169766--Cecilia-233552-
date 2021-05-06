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
            string AudioUrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            Playlist audio = new Playlist();
            audio.UrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            string getAudioUrlImage = audio.UrlImage;
            Assert.AreEqual(AudioUrlImage, getAudioUrlImage);
        }
        
        [TestMethod]
        public void GetSetPlaylistEmptyUrlImage()
        {
            string AudioUrlImage = "";
            Playlist audio = new Playlist();
            audio.UrlImage = "";
            string getAudioUrlImage = audio.UrlImage;
            Assert.AreEqual(AudioUrlImage, getAudioUrlImage);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidUrl), "")]
        public void GetSetInalidPlaylistUrlImage()
        {
            string AudioUrlImage = "UrlImage";
            Playlist audio = new Playlist();
            audio.UrlImage = "UrlImage";
            string getAudioUrlImage = audio.UrlImage;
            Assert.AreEqual(AudioUrlImage, getAudioUrlImage);
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
        public void GetSetPlaylistAudios()
        {
            List<Audio> Audios = new List<Audio>();
            Playlist playlist = new Playlist();
            playlist.Audios = Audios;
            List<Audio> getAudios = playlist.Audios;
            Assert.AreEqual(Audios, getAudios);
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
        public void IsSameAudioName()
        {
            Playlist playlist = new Playlist();
            playlist.Audios = new List<Audio>()
            {
                new Audio(){
            
                    Categories = new List<Category>(),
                    Name = "Let it be",
                    AuthorName = "John Lennon",
                    Duration = 12,
                    UrlAudio = "",
                    UrlImage = ""
                }
            };
            string categoryName = "Let it be";
            Assert.IsTrue(playlist.IsSameAudioName(categoryName));
        }

        [TestMethod]
        public void IsDifferentAudioName()
        {
            Playlist playlist = new Playlist();
            playlist.Audios = new List<Audio>()
            {
                new Audio(){
            
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
                }
            };
            string categoryName = "Let it be";
            Assert.IsFalse(playlist.IsSameAudioName(categoryName));
        }
        
        [TestMethod]
        public void EqualsPlaylist()
        {
            Playlist playlist = new Playlist()
            {
                Id=1,
              Name  = "Entrena tu mente",
              Description = "para despejar",
              UrlImage=""
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
                UrlImage=""
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
        public void EqualsNull()
        {
            Playlist playlist = new Playlist()
            {
                Id=1,
                Name  = "Entrena tu mente",
                Description = "para despejar",
                UrlImage=""
            };
            Assert.IsFalse( playlist.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            Playlist playlist = new Playlist()
            {
                Id=1,
                Name  = "Entrena tu mente",
                Description = "para despejar",
                UrlImage=""
            };
            Assert.IsFalse( playlist.Equals(new Audio()));
        }
       
    }
}