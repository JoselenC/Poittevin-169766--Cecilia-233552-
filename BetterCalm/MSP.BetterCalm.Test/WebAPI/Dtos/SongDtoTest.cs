using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class SongDtoTest
    {
        [TestMethod]
        public void GetSetSongName()
        {
            string songName = "Let it be";
            SongDto song = new SongDto();
            song.Name = "Let it be";
            string getsongName = song.Name;
            Assert.AreEqual(songName, getsongName);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetSongEmptyName()
        {
            SongDto song = new SongDto();
            song.Name = "";
        }
        
        [TestMethod]
        public void GetSetSongUrlAudio()
        {
            string urlAudioName = "urlAudioName";
            SongDto song = new SongDto();
            song.UrlAudio = "urlAudioName";
            string getsongUrlAudio = song.UrlAudio;
            Assert.AreEqual(urlAudioName, getsongUrlAudio);
        }
        
        [TestMethod]
        public void GetSetSongUrlImage()
        {
            string songUrlImage = "UrlImage";
            SongDto song = new SongDto();
            song.UrlImage = "UrlImage";
            string getsongUrlImage = song.UrlImage;
            Assert.AreEqual(songUrlImage, getsongUrlImage);
        }
        
        [TestMethod]
        public void GetSetSongDurationH()
        {
            string duration = "23h" ;
            SongDto song = new SongDto();
            song.Duration = "23h";
            string  getsongDuration = song.Duration;
            Assert.AreEqual(duration, getsongDuration);
        }
        
        
        [TestMethod]
        public void GetSetSongId()
        {
            int id = 2 ;
            SongDto song = new SongDto();
            song.Id = 2;
            int getsongId = song.Id;
            Assert.AreEqual(id, getsongId);
        }
        
        [TestMethod]
        public void GetSetSongAuthorName()
        {
            string authorName = "Paul McCartney";
            SongDto song = new SongDto();
            song.AuthorName = authorName;
            string getAuthorName= song.AuthorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetSongCategories()
        {
            List<Category> categories = new List<Category>();
            SongDto song = new SongDto();
            song.Categories = categories;
            List<Category> getsongCategories = song.Categories;
            Assert.AreEqual(categories, getsongCategories);
        }
        
        [TestMethod]
        public void CreateSongdtoTest()
        {
            Song song = new Song()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""
            };
            SongDto songdtoExpected = new SongDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlAudio = "",
                UrlImage = ""
            };
            SongDto songDto = new SongDto().CreateSongDto(song);
            Assert.AreEqual(songdtoExpected, songDto);
        }
    }
}