using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AudioDtoTest
    {
        
        [TestMethod]
        public void GetSetAudioId()
        {
            AudioDto audio = new AudioDto();
            audio.AudioDtoID = 1;
            Assert.AreEqual(1, audio.AudioDtoID);
        }
        
        [TestMethod]
        public void GetSetAudioName()
        {
            string AudioName = "Let it be";
            AudioDto audio = new AudioDto();
            audio.Name = "Let it be";
            string getAudioName = audio.Name;
            Assert.AreEqual(AudioName, getAudioName);
        }
        
        [TestMethod]
        public void GetSetAudioUrlAudio()
        {
            string urlAudioName = "urlAudioName";
            AudioDto audio = new AudioDto();
            audio.UrlAudio = "urlAudioName";
            string getAudioUrlAudio = audio.UrlAudio;
            Assert.AreEqual(urlAudioName, getAudioUrlAudio);
        }
        
        [TestMethod]
        public void GetSetAudioUrlImage()
        {
            string AudioUrlImage = "UrlImage";
            AudioDto audio = new AudioDto();
            audio.UrlImage = "UrlImage";
            string getAudioUrlImage = audio.UrlImage;
            Assert.AreEqual(AudioUrlImage, getAudioUrlImage);
        }
        
        [TestMethod]
        public void GetSetAudioDuration()
        {
            double duration = 23 ;
            AudioDto audio = new AudioDto();
            audio.Duration = 23;
            double getAudioDuration = audio.Duration;
            Assert.AreEqual(duration, getAudioDuration);
        }
        
        [TestMethod]
        public void GetSetAudioAuthorName()
        {
            string authorName = "Paul McCartney";
            AudioDto audio = new AudioDto();
            audio.AuthorName = authorName;
            string getAuthorName= audio.AuthorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetPlaylistAudioDto()
        {
            AudioDto audio = new AudioDto();
            audio.PlaylistAudiosDto = new List<PlaylistAudioDto>();
            ICollection<PlaylistAudioDto> getPlaylistAudio= audio.PlaylistAudiosDto;
            CollectionAssert.AreEqual(getPlaylistAudio.ToList(), new List<PlaylistAudioDto>());
        }
    }
}