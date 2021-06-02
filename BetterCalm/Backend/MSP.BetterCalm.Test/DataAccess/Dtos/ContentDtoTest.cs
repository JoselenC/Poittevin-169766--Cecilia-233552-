using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ContentDtoTest
    {
        
        [TestMethod]
        public void GetSetContentId()
        {
            ContentDto Content = new ContentDto();
            Content.ContentDtoId = 1;
            Assert.AreEqual(1, Content.ContentDtoId);
        }
        
        [TestMethod]
        public void GetSetContentName()
        {
            string ContentName = "Let it be";
            ContentDto Content = new ContentDto();
            Content.Name = "Let it be";
            string getContentName = Content.Name;
            Assert.AreEqual(ContentName, getContentName);
        }
        
        [TestMethod]
        public void GetSetContentUrlContent()
        {
            string urlContentName = "urlContentName";
            ContentDto Content = new ContentDto();
            Content.UrlArchive = "urlContentName";
            string getContentUrlContent = Content.UrlArchive;
            Assert.AreEqual(urlContentName, getContentUrlContent);
        }
        
        [TestMethod]
        public void GetSetContentUrlImage()
        {
            string ContentUrlImage = "UrlImage";
            ContentDto Content = new ContentDto();
            Content.UrlImage = "UrlImage";
            string getContentUrlImage = Content.UrlImage;
            Assert.AreEqual(ContentUrlImage, getContentUrlImage);
        }
        
        [TestMethod]
        public void GetSetContentDuration()
        {
            double duration = 23 ;
            ContentDto Content = new ContentDto();
            Content.Duration = 23;
            double getContentDuration = Content.Duration;
            Assert.AreEqual(duration, getContentDuration);
        }
        
        [TestMethod]
        public void GetSetContentAuthorName()
        {
            string authorName = "Paul McCartney";
            ContentDto Content = new ContentDto();
            Content.AuthorName = authorName;
            string getAuthorName= Content.AuthorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetPlaylistContentDto()
        {
            ContentDto Content = new ContentDto();
            Content.PlaylistContentsDto = new List<PlaylistContentDto>();
            ICollection<PlaylistContentDto> getPlaylistContent= Content.PlaylistContentsDto;
            CollectionAssert.AreEqual(getPlaylistContent.ToList(), new List<PlaylistContentDto>());
        }
    }
}