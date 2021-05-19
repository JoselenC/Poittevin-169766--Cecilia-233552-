using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VideoTest
    {
        [TestMethod]
        public void GetSetVideoName()
        {
            string VideoName = "Let it be";
            Video Video = new Video();
            Video.Name = "Let it be";
            string getVideoName = Video.Name;
            Assert.AreEqual(VideoName, getVideoName);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetVideoEmptyName()
        {
            Video Video = new Video();
            Video.Name = "";
        }
     
        [TestMethod]
        public void GetSetVideoUrlArchive()
        {
            string VideoUrlArchive = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            Video Video = new Video();
            Video.UrlArchive = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            string getVideoUrlArchive = Video.UrlArchive;
            Assert.AreEqual(VideoUrlArchive, getVideoUrlArchive);
        }
        
        [TestMethod]
        public void GetSetVideoEmptyUrlArchive()
        {
            string VideoUrlArchive = "";
            Video Video = new Video();
            Video.UrlArchive = "";
            string getVideoUrlArchive = Video.UrlArchive;
            Assert.AreEqual(VideoUrlArchive, getVideoUrlArchive);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidUrl), "")]
        public void GetSetInalidVideoUrlArchive()
        {
            string VideoUrlArchive = "UrlArchive";
            Video Video = new Video();
            Video.UrlArchive = "UrlArchive";
            string getVideoUrlArchive = Video.UrlArchive;
            Assert.AreEqual(VideoUrlArchive, getVideoUrlArchive);
        }
        
        [TestMethod]
        public void GetSetVideoDuration()
        {
            double duration = 23 ;
            Video Video = new Video();
            Video.Duration = 23;
            double getVideoDuration = Video.Duration;
            Assert.AreEqual(duration, getVideoDuration);
        }
        
        [TestMethod]
        public void GetSetVideoDurationHour()
        {
            double duration = 120 ;
            Video Video = new Video();
            Video.Duration = 120;
            double getVideoDuration = Video.Duration;
            Assert.AreEqual(duration, getVideoDuration);
        }
        
        [TestMethod]
        public void GetSetVideoId()
        {
            int id = 2 ;
            Video Video = new Video();
            Video.Id = 2;
            int getVideoId = Video.Id;
            Assert.AreEqual(id, getVideoId);
        }
        
        [TestMethod]
        public void GetSetVideoCreatorName()
        {
            string CreatorName = "Paul McCartney";
            Video Video = new Video();
            Video.CreatorName = CreatorName;
            string getCreatorName= Video.CreatorName;
            Assert.AreEqual(CreatorName, getCreatorName);
        }
        
        [TestMethod]
        public void GetSetVideoCategories()
        {
            List<Category> categories = new List<Category>();
            Video Video = new Video();
            Video.Categories = categories;
            List<Category> getVideoCategories = Video.Categories;
            Assert.AreEqual(categories, getVideoCategories);
        }
      
        [TestMethod]
        public void IsSameVideoName()
        {
            Video Video = new Video();
            Video.Name = "let it be";
            string VideoName = "let it be";
            Assert.IsTrue(Video.IsSameVideoName(VideoName));
        }
        
        [TestMethod]
        public void IsDifferentVideoName()
        {
            Video Video = new Video();
            Video.Name = "Something";
            string VideoName = "let it be";
            Assert.IsFalse(Video.IsSameVideoName(VideoName));
        }
        
        [TestMethod]
        public void IsSameCreatorName()
        {
            Video Video = new Video();
            Video.CreatorName = "Ringo Starr";
            string CreatorName =  "Ringo Starr";
            Assert.IsTrue(Video.IsSameCreatorName(CreatorName));
        }
        
        [TestMethod]
        public void IsDifferentAuthorNae()
        {
            Video Video = new Video();
            Video.CreatorName =  "Ringo Starr";
            string CreatorName = "John Lennon";
            Assert.IsFalse(Video.IsSameCreatorName(CreatorName));
        }
        
        [TestMethod]
        public void IsSameCategoryName()
        {
            Video Video = new Video();
            Video.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Dormir";
            Assert.IsTrue(Video.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void IsDifferentCategoryName()
        {
            Video Video = new Video();
            Video.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Musica";
            Assert.IsFalse(Video.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void EqualsNull()
        {
            Video Video = new Video();
            Video.CreatorName =  "Ringo Starr";
            Assert.IsFalse( Video.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            Video Video = new Video();
            Video.CreatorName =  "Ringo Starr";
            Assert.IsFalse( Video.Equals(new Category()));
        }
    }
}
