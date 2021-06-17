using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.Importer.Models;

namespace MSP.BetterCalm.Test.Importer
{
    [TestClass]
    public class ContentModelTest
    {
        [TestMethod]
        public void GetSetContentModelName()
        {
            string ContentModelName = "Let it be";
            ContentModel contentModel = new ContentModel();
            contentModel.Name = "Let it be";
            string getContentModelName = contentModel.Name;
            Assert.AreEqual(ContentModelName, getContentModelName);
        }
        
        [TestMethod]
        public void GetSetType()
        {
            string ContentModelName = "audio";
            ContentModel contentModel = new ContentModel();
            contentModel.Type = "audio";
            string getContentModelName = contentModel.Type;
            Assert.AreEqual(ContentModelName, getContentModelName);
        }
 
        
        [TestMethod]
        public void GetSetContentModelUrlEmptyContentModel()
        {
            string urlContentModelName = "";
            ContentModel contentModel = new ContentModel();
            contentModel.UrlArchive = "";
            string getContentModelUrlContentModel = contentModel.UrlArchive;
            Assert.AreEqual(urlContentModelName, getContentModelUrlContentModel);
        }
        
        [TestMethod]
        public void GetSetContentModelUrlContentModel()
        {
            string urlContentModelName = "https://www.youtube.com/watch?v=QDYfEBY9NM4";
            ContentModel contentModel = new ContentModel();
            contentModel.UrlArchive = "https://www.youtube.com/watch?v=QDYfEBY9NM4";
            string getContentModelUrlContentModel = contentModel.UrlArchive;
            Assert.AreEqual(urlContentModelName, getContentModelUrlContentModel);
        }
        
        [TestMethod]
        public void GetSetContentModelUrlImage()
        {
            string ContentModelUrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            ContentModel contentModel = new ContentModel();
            contentModel.UrlImage = "https://www.google.com/search?q=paisaje&tbm=isch&ved=2ahUKEwifk_70vbHwAhWHMrkGHdFZCwUQ2-cCegQIABAA&oq=paisaje&gs_lcp=CgNpbWcQAzIECCMQJzIHCAAQsQMQQzIKCAAQsQMQgwEQQzIHCAAQsQMQQzIHCAAQsQMQQzIHCAAQsQMQQzIECAAQQzIECAAQQzICCAAyAggAOgUIABCxAzoICAAQsQMQgwFQrfQDWPD7A2CE_QNoAHAAeACAAY4CiAHRCZIBBTAuNS4ymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=cwGSYN-NCofl5OUP0bOtKA#imgrc=Mo3K6BpTEC_zGM";
            string getContentModelUrlImage = contentModel.UrlImage;
            Assert.AreEqual(ContentModelUrlImage, getContentModelUrlImage);
        }
        
        [TestMethod]
        public void GetSetContentModelEmptyUrlImage()
        {
            string ContentModelUrlImage = "";
            ContentModel contentModel = new ContentModel();
            contentModel.UrlImage = "";
            string getContentModelUrlImage = contentModel.UrlImage;
            Assert.AreEqual(ContentModelUrlImage, getContentModelUrlImage);
        }
        
      
        [TestMethod]
        public void GetSetContentModelDuration()
        {
            string duration = "23s" ;
            ContentModel contentModel = new ContentModel();
            contentModel.Duration = "23s";
            string getContentModelDuration = contentModel.Duration;
            Assert.AreEqual(duration, getContentModelDuration);
        }
        
        [TestMethod]
        public void GetSetContentModelAuthorName()
        {
            string authorName = "Paul McCartney";
            ContentModel contentModel = new ContentModel();
            contentModel.CreatorName = authorName;
            string getAuthorName= contentModel.CreatorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetContentModelCategories()
        {
            List<Category> categories = new List<Category>();
            ContentModel contentModel = new ContentModel();
            contentModel.Categories = categories;
            List<Category> getContentModelCategories = contentModel.Categories;
            Assert.AreEqual(categories, getContentModelCategories);
        }
   
     
    }
}
