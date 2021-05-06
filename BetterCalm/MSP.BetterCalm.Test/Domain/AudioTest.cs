using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class AudioTest
    {
        [TestMethod]
        public void GetSetAudioName()
        {
            string AudioName = "Let it be";
            Audio audio = new Audio();
            audio.Name = "Let it be";
            string getAudioName = audio.Name;
            Assert.AreEqual(AudioName, getAudioName);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetAudioEmptyName()
        {
            Audio audio = new Audio();
            audio.Name = "";
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidUrl), "")]
        public void GetSetInvalidAudioUrlAudio()
        {
            string urlAudioName = "urlAudioName";
            Audio audio = new Audio();
            audio.UrlAudio = "urlAudioName";
            string getAudioUrlAudio = audio.UrlAudio;
            Assert.AreEqual(urlAudioName, getAudioUrlAudio);
        }
        
        [TestMethod]
        public void GetSetAudioUrlEmptyAudio()
        {
            string urlAudioName = "";
            Audio audio = new Audio();
            audio.UrlAudio = "";
            string getAudioUrlAudio = audio.UrlAudio;
            Assert.AreEqual(urlAudioName, getAudioUrlAudio);
        }
        
        [TestMethod]
        public void GetSetAudioUrlAudio()
        {
            string urlAudioName = "https://www.youtube.com/watch?v=QDYfEBY9NM4";
            Audio audio = new Audio();
            audio.UrlAudio = "https://www.youtube.com/watch?v=QDYfEBY9NM4";
            string getAudioUrlAudio = audio.UrlAudio;
            Assert.AreEqual(urlAudioName, getAudioUrlAudio);
        }
        
        [TestMethod]
        public void GetSetAudioUrlImage()
        {
            string AudioUrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            Audio audio = new Audio();
            audio.UrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            string getAudioUrlImage = audio.UrlImage;
            Assert.AreEqual(AudioUrlImage, getAudioUrlImage);
        }
        
        [TestMethod]
        public void GetSetAudioEmptyUrlImage()
        {
            string AudioUrlImage = "";
            Audio audio = new Audio();
            audio.UrlImage = "";
            string getAudioUrlImage = audio.UrlImage;
            Assert.AreEqual(AudioUrlImage, getAudioUrlImage);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidUrl), "")]
        public void GetSetInalidAudioUrlImage()
        {
            string AudioUrlImage = "UrlImage";
            Audio audio = new Audio();
            audio.UrlImage = "UrlImage";
            string getAudioUrlImage = audio.UrlImage;
            Assert.AreEqual(AudioUrlImage, getAudioUrlImage);
        }
        
        [TestMethod]
        public void GetSetAudioDuration()
        {
            double duration = 23 ;
            Audio audio = new Audio();
            audio.Duration = 23;
            double getAudioDuration = audio.Duration;
            Assert.AreEqual(duration, getAudioDuration);
        }
        
        [TestMethod]
        public void GetSetAudioDurationHour()
        {
            double duration = 120 ;
            Audio audio = new Audio();
            audio.Duration = 120;
            double getAudioDuration = audio.Duration;
            Assert.AreEqual(duration, getAudioDuration);
        }
        
        [TestMethod]
        public void GetSetAudioId()
        {
            int id = 2 ;
            Audio audio = new Audio();
            audio.Id = 2;
            int getAudioId = audio.Id;
            Assert.AreEqual(id, getAudioId);
        }
        
        [TestMethod]
        public void GetSetAudioAuthorName()
        {
            string authorName = "Paul McCartney";
            Audio audio = new Audio();
            audio.AuthorName = authorName;
            string getAuthorName= audio.AuthorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetAudioCategories()
        {
            List<Category> categories = new List<Category>();
            Audio audio = new Audio();
            audio.Categories = categories;
            List<Category> getAudioCategories = audio.Categories;
            Assert.AreEqual(categories, getAudioCategories);
        }
      
        [TestMethod]
        public void IsSameAudioName()
        {
            Audio audio = new Audio();
            audio.Name = "let it be";
            string AudioName = "let it be";
            Assert.IsTrue(audio.IsSameAudioName(AudioName));
        }
        
        [TestMethod]
        public void IsDifferentAudioName()
        {
            Audio audio = new Audio();
            audio.Name = "Something";
            string AudioName = "let it be";
            Assert.IsFalse(audio.IsSameAudioName(AudioName));
        }
        
        [TestMethod]
        public void IsSameAuthorName()
        {
            Audio audio = new Audio();
            audio.AuthorName = "Ringo Starr";
            string authorName =  "Ringo Starr";
            Assert.IsTrue(audio.IsSameAuthorName(authorName));
        }
        
        [TestMethod]
        public void IsDifferentAuthorNae()
        {
            Audio audio = new Audio();
            audio.AuthorName =  "Ringo Starr";
            string authorName = "John Lennon";
            Assert.IsFalse(audio.IsSameAuthorName(authorName));
        }
        
        [TestMethod]
        public void IsSameCategoryName()
        {
            Audio audio = new Audio();
            audio.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Dormir";
            Assert.IsTrue(audio.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void IsDifferentCategoryName()
        {
            Audio audio = new Audio();
            audio.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Musica";
            Assert.IsFalse(audio.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void EqualsNull()
        {
            Audio audio = new Audio();
            audio.AuthorName =  "Ringo Starr";
            Assert.IsFalse( audio.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            Audio audio = new Audio();
            audio.AuthorName =  "Ringo Starr";
            Assert.IsFalse( audio.Equals(new Category()));
        }
    }
}
