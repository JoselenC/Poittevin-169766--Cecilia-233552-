using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ContentTest
    {
        [TestMethod]
        public void GetSetContentName()
        {
            string ContentName = "Let it be";
            Content content = new Content();
            content.Name = "Let it be";
            string getContentName = content.Name;
            Assert.AreEqual(ContentName, getContentName);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetContentEmptyName()
        {
            Content content = new Content();
            content.Name = "";
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidUrl), "")]
        public void GetSetInvalidContentUrlContent()
        {
            string urlContentName = "urlContentName";
            Content content = new Content();
            content.UrlArchive = "urlContentName";
            string getContentUrlContent = content.UrlArchive;
            Assert.AreEqual(urlContentName, getContentUrlContent);
        }
        
        [TestMethod]
        public void GetSetContentUrlEmptyContent()
        {
            string urlContentName = "";
            Content content = new Content();
            content.UrlArchive = "";
            string getContentUrlContent = content.UrlArchive;
            Assert.AreEqual(urlContentName, getContentUrlContent);
        }
        
        [TestMethod]
        public void GetSetContentUrlContent()
        {
            string urlContentName = "https://www.youtube.com/watch?v=QDYfEBY9NM4";
            Content content = new Content();
            content.UrlArchive = "https://www.youtube.com/watch?v=QDYfEBY9NM4";
            string getContentUrlContent = content.UrlArchive;
            Assert.AreEqual(urlContentName, getContentUrlContent);
        }
        
        [TestMethod]
        public void GetSetContentUrlImage()
        {
            string ContentUrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            Content content = new Content();
            content.UrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            string getContentUrlImage = content.UrlImage;
            Assert.AreEqual(ContentUrlImage, getContentUrlImage);
        }
        
        [TestMethod]
        public void GetSetContentEmptyUrlImage()
        {
            string ContentUrlImage = "";
            Content content = new Content();
            content.UrlImage = "";
            string getContentUrlImage = content.UrlImage;
            Assert.AreEqual(ContentUrlImage, getContentUrlImage);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidUrl), "")]
        public void GetSetInalidContentUrlImage()
        {
            string ContentUrlImage = "UrlImage";
            Content content = new Content();
            content.UrlImage = "UrlImage";
            string getContentUrlImage = content.UrlImage;
            Assert.AreEqual(ContentUrlImage, getContentUrlImage);
        }
        
        [TestMethod]
        public void GetSetContentDuration()
        {
            double duration = 23 ;
            Content content = new Content();
            content.Duration = 23;
            double getContentDuration = content.Duration;
            Assert.AreEqual(duration, getContentDuration);
        }
        
        [TestMethod]
        public void GetSetContentDurationHour()
        {
            double duration = 120 ;
            Content content = new Content();
            content.Duration = 120;
            double getContentDuration = content.Duration;
            Assert.AreEqual(duration, getContentDuration);
        }
        
        [TestMethod]
        public void GetSetContentId()
        {
            int id = 2 ;
            Content content = new Content();
            content.Id = 2;
            int getContentId = content.Id;
            Assert.AreEqual(id, getContentId);
        }
        
        [TestMethod]
        public void GetSetContentAuthorName()
        {
            string authorName = "Paul McCartney";
            Content content = new Content();
            content.AuthorName = authorName;
            string getAuthorName= content.AuthorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetContentCategories()
        {
            List<Category> categories = new List<Category>();
            Content content = new Content();
            content.Categories = categories;
            List<Category> getContentCategories = content.Categories;
            Assert.AreEqual(categories, getContentCategories);
        }
      
        [TestMethod]
        public void IsSameContentName()
        {
            Content content = new Content();
            content.Name = "let it be";
            string ContentName = "let it be";
            Assert.IsTrue(content.IsSameContentName(ContentName));
        }
        
        [TestMethod]
        public void IsDifferentContentName()
        {
            Content content = new Content();
            content.Name = "Something";
            string ContentName = "let it be";
            Assert.IsFalse(content.IsSameContentName(ContentName));
        }
        
        [TestMethod]
        public void IsSameAuthorName()
        {
            Content content = new Content();
            content.AuthorName = "Ringo Starr";
            string authorName =  "Ringo Starr";
            Assert.IsTrue(content.IsSameAuthorName(authorName));
        }
        
        [TestMethod]
        public void IsDifferentAuthorNae()
        {
            Content content = new Content();
            content.AuthorName =  "Ringo Starr";
            string authorName = "John Lennon";
            Assert.IsFalse(content.IsSameAuthorName(authorName));
        }
        
        [TestMethod]
        public void IsSameCategoryName()
        {
            Content content = new Content();
            content.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Dormir";
            Assert.IsTrue(content.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void IsDifferentCategoryName()
        {
            Content content = new Content();
            content.Categories = new List<Category>()
            {
                new Category()
                {
                    Name="Dormir"
                }
            };
            string categoryName =  "Musica";
            Assert.IsFalse(content.IsSameCategoryName(categoryName));
        }
        
        [TestMethod]
        public void EqualsNull()
        {
            Content content = new Content();
            content.AuthorName =  "Ringo Starr";
            Assert.IsFalse( content.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            Content content = new Content();
            content.AuthorName =  "Ringo Starr";
            Assert.IsFalse( content.Equals(new Category()));
        }
    }
}
