using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class AudioDtoTest
    {
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
        public void GetSetAudioDurationH()
        {
            string duration = "23h" ;
            AudioDto audio = new AudioDto();
            audio.Duration = "23h";
            string  getAudioDuration = audio.Duration;
            Assert.AreEqual(duration, getAudioDuration);
        }
        
        [TestMethod]
        public void GetSetAudioDurationM()
        {
            string duration = "23m" ;
            AudioDto audio = new AudioDto();
            audio.Duration = "23m";
            string  getAudioDuration = audio.Duration;
            Assert.AreEqual(duration, getAudioDuration);
        }
        
        [TestMethod]
        public void GetSetAudioDurationS()
        {
            string duration = "23s" ;
            AudioDto audio = new AudioDto();
            audio.Duration = "23s";
            string  getAudioDuration = audio.Duration;
            Assert.AreEqual(duration, getAudioDuration);
        }
        
       
        [TestMethod]
        public void GetSetAudioId()
        {
            int id = 2 ;
            AudioDto audio = new AudioDto();
            audio.Id = 2;
            int getAudioId = audio.Id;
            Assert.AreEqual(id, getAudioId);
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
        public void GetSetAudioCategories()
        {
            List<Category> categories = new List<Category>();
            AudioDto audio = new AudioDto();
            audio.Categories = categories;
            List<Category> getAudioCategories = audio.Categories;
            Assert.AreEqual(categories, getAudioCategories);
        }
        
        [TestMethod]
        public void CreateAudiodtoTest()
        {
            Audio audio = new Audio()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""
            };
            AudioDto audioDtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlAudio = "",
                UrlImage = ""
            };
            AudioDto audioDto = new AudioDto().CreateAudioDto(audio);
            Assert.AreEqual(audioDtoExpected, audioDto);
        }
        
        [TestMethod]
        public void CreateAudiodto()
        {
            Audio audio = new Audio()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 60*60*60,
                UrlAudio = "",
                UrlImage = ""
            };
            AudioDto audioDtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "60h",
                UrlAudio = "",
                UrlImage = ""
            };
            AudioDto audioDto = new AudioDto().CreateAudioDto(audio);
            Assert.AreEqual(audioDtoExpected, audioDto);
        }
        
       [TestMethod]
        public void EqualsNull()
        {
            AudioDto audiodtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlAudio = "",
                UrlImage = ""
            };
            Assert.IsFalse(audiodtoExpected.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            AudioDto audiodtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlAudio = "",
                UrlImage = ""
            };
            Assert.IsFalse(audiodtoExpected.Equals(new Category()));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDurationFormat))]
        public void CreateAudioTest()
        {
         AudioDto audiodtoExpected = new AudioDto()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "12000sq",
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audioDto = audiodtoExpected.CreateAudio();
        }
        
        [TestMethod]
        public void CreateAudioTestDurations()
        {
            AudioDto audiodtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "12000s",
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audio = new Audio()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12000,
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audioDto = audiodtoExpected.CreateAudio();
            Assert.AreEqual(audio, audioDto);
        }
        
        [TestMethod]
        public void CreateAudioTestDurationS()
        {
            AudioDto audiodtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "1200H",
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audio = new Audio()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 1200,
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audioDto = audiodtoExpected.CreateAudio();
            Assert.AreEqual(audio, audioDto);
        }
        
        [TestMethod]
        public void CreateAudioTestDurationM()
        {
            AudioDto audiodtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "100m",
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audio = new Audio()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 10*60,
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audioDto = audiodtoExpected.CreateAudio();
            Assert.AreEqual(audio, audioDto);
        }
        
        [TestMethod]
        public void CreateAudioTestDurationH()
        {
            AudioDto audiodtoExpected = new AudioDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "10h",
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audio = new Audio()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 10*60*60,
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audioDto = audiodtoExpected.CreateAudio();
            Assert.AreEqual(audio, audioDto);
        }
    }
}