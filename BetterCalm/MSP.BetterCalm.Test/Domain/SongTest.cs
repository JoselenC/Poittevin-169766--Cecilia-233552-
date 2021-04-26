using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class SongTest
    {
        [TestMethod]
        public void GetSetSongName()
        {
            string songName = "Let it be";
            Song song = new Song();
            song.Name = "Let it be";
            string getsongName = song.Name;
            Assert.AreEqual(songName, getsongName);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetSongEmptyName()
        {
            Song song = new Song();
            song.Name = "";
        }
        
        [TestMethod]
        public void GetSetSongUrlAudio()
        {
            string urlAudioName = "urlAudioName";
            Song song = new Song();
            song.UrlAudio = "urlAudioName";
            string getsongUrlAudio = song.UrlAudio;
            Assert.AreEqual(urlAudioName, getsongUrlAudio);
        }
        
        [TestMethod]
        public void GetSetSongUrlImage()
        {
            string songUrlImage = "UrlImage";
            Song song = new Song();
            song.UrlImage = "UrlImage";
            string getsongUrlImage = song.UrlImage;
            Assert.AreEqual(songUrlImage, getsongUrlImage);
        }
        
        [TestMethod]
        public void GetSetSongDuration()
        {
            int duration = 23 ;
            Song song = new Song();
            song.Duration = 23;
            int getsongDuration = song.Duration;
            Assert.AreEqual(duration, getsongDuration);
        }
        
        [TestMethod]
        public void GetSetSongDurationHour()
        {
            int duration = 2 ;
            Song song = new Song();
            song.Duration = 120;
            int getsongDuration = song.Duration;
            Assert.AreEqual(duration, getsongDuration);
        }
        
        [TestMethod]
        public void GetSetSongId()
        {
            int id = 2 ;
            Song song = new Song();
            song.Id = 2;
            int getsongId = song.Id;
            Assert.AreEqual(id, getsongId);
        }
        
        [TestMethod]
        public void GetSetSongAuthorName()
        {
            string authorName = "Paul McCartney";
            Song song = new Song();
            song.AuthorName = authorName;
            string getAuthorName= song.AuthorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetSongCategories()
        {
            List<Category> categories = new List<Category>();
            Song song = new Song();
            song.Categories = categories;
            List<Category> getsongCategories = song.Categories;
            Assert.AreEqual(categories, getsongCategories);
        }
      
        [TestMethod]
        public void IsSameSongName()
        {
            Song song = new Song();
            song.Name = "let it be";
            string songName = "let it be";
            Assert.IsTrue(song.IsSameSongName(songName));
        }
        
        [TestMethod]
        public void IsDifferentSongName()
        {
            Song song = new Song();
            song.Name = "Something";
            string songName = "let it be";
            Assert.IsFalse(song.IsSameSongName(songName));
        }
        
        [TestMethod]
        public void IsSameAuthorName()
        {
            Song song = new Song();
            song.AuthorName = "Ringo Starr";
            string authorName =  "Ringo Starr";
            Assert.IsTrue(song.IsSameAuthorName(authorName));
        }
        
        [TestMethod]
        public void IsDifferentAuthorNae()
        {
            Song song = new Song();
            song.AuthorName =  "Ringo Starr";
            string authorName = "John Lennon";
            Assert.IsFalse(song.IsSameAuthorName(authorName));
        }
        
        [TestMethod]
        public void IsSameCategoryName()
        {
            Song song = new Song();
            song.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Dormir";
            Assert.IsTrue(song.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void IsDifferentCategoryName()
        {
            Song song = new Song();
            song.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Musica";
            Assert.IsFalse(song.IsSameCategoryName(categoryName));
        }
        
       
    }
}
