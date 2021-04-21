using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class SongDtoTest
    {
        
        [TestMethod]
        public void GetSetSongId()
        {
            SongDto song = new SongDto();
            song.SongDtoID = 1;
            Assert.AreEqual(1, song.SongDtoID);
        }
        
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
        public void GetSetSongDuration()
        {
            int duration = 23 ;
            SongDto song = new SongDto();
            song.Duration = 23;
            int getsongDuration = song.Duration;
            Assert.AreEqual(duration, getsongDuration);
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
            List<CategoryDto> categories = new List<CategoryDto>();
            SongDto song = new SongDto();
            song.Categories = categories;
            List<CategoryDto> getsongCategories = song.Categories;
            Assert.AreEqual(categories, getsongCategories);
        }
     
        [TestMethod]
        public void GetSetPlayListDtoId()
        {
            SongDto song = new SongDto();
            song.PlaylistDtoID = 1;
            Assert.AreEqual(1, song.PlaylistDtoID);
        }
        
        [TestMethod]
        public void GetSetPlayListDto()
        {
            SongDto song = new SongDto();
            PlaylistDto playlistDto= new PlaylistDto();
            song.PlaylistDto = playlistDto;
            Assert.AreEqual(playlistDto, song.PlaylistDto);
        }
        
        
        
    }
}