using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class ContentDtoTest
    {
        [TestMethod]
        public void GetSetContentName()
        {
            string ContentName = "Let it be";
            ContentDto content = new ContentDto();
            content.Name = "Let it be";
            string getContentName = content.Name;
            Assert.AreEqual(ContentName, getContentName);
        }
      
        
        [TestMethod]
        public void GetSetContentUrlContent()
        {
            string urlContentName = "urlContentName";
            ContentDto content = new ContentDto();
            content.UrlArchive = "urlContentName";
            string getContentUrlContent = content.UrlArchive;
            Assert.AreEqual(urlContentName, getContentUrlContent);
        }
        
        [TestMethod]
        public void GetSetContentUrlImage()
        {
            string ContentUrlImage = "UrlImage";
            ContentDto content = new ContentDto();
            content.UrlImage = "UrlImage";
            string getContentUrlImage = content.UrlImage;
            Assert.AreEqual(ContentUrlImage, getContentUrlImage);
        }
        
        [TestMethod]
        public void GetSetContentDurationH()
        {
            string duration = "23h" ;
            ContentDto content = new ContentDto();
            content.Duration = "23h";
            string  getContentDuration = content.Duration;
            Assert.AreEqual(duration, getContentDuration);
        }
        
        [TestMethod]
        public void GetSetContentDurationM()
        {
            string duration = "23m" ;
            ContentDto content = new ContentDto();
            content.Duration = "23m";
            string  getContentDuration = content.Duration;
            Assert.AreEqual(duration, getContentDuration);
        }
        
        [TestMethod]
        public void GetSetContentDurationS()
        {
            string duration = "23s" ;
            ContentDto content = new ContentDto();
            content.Duration = "23s";
            string  getContentDuration = content.Duration;
            Assert.AreEqual(duration, getContentDuration);
        }
        
       
        [TestMethod]
        public void GetSetContentId()
        {
            int id = 2 ;
            ContentDto content = new ContentDto();
            content.Id = 2;
            int getContentId = content.Id;
            Assert.AreEqual(id, getContentId);
        }
        
        [TestMethod]
        public void GetSetContentAuthorName()
        {
            string authorName = "Paul McCartney";
            ContentDto content = new ContentDto();
            content.AuthorName = authorName;
            string getAuthorName= content.AuthorName;
            Assert.AreEqual(authorName, getAuthorName);
        }
        
        [TestMethod]
        public void GetSetContentCategories()
        {
            List<Category> categories = new List<Category>();
            ContentDto content = new ContentDto();
            content.Categories = categories;
            List<Category> getContentCategories = content.Categories;
            Assert.AreEqual(categories, getContentCategories);
        }
        
        [TestMethod]
        public void CreateContentdtoTest()
        {
            Content content = new Content()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                UrlImage = ""
            };
            ContentDto contentDtoExpected = new ContentDto()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlArchive = "",
                UrlImage = ""
            };
            ContentDto contentDto = new ContentDto().CreateContentDto(content);
            Assert.AreEqual(contentDtoExpected, contentDto);
        }
        
        [TestMethod]
        public void CreateContentdto()
        {
            Content content = new Content()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 60*60*60,
                UrlArchive = "",
                UrlImage = ""
            };
            ContentDto contentDtoExpected = new ContentDto()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "60h",
                UrlArchive = "",
                UrlImage = ""
            };
            ContentDto contentDto = new ContentDto().CreateContentDto(content);
            Assert.AreEqual(contentDtoExpected, contentDto);
        }
        
       [TestMethod]
        public void EqualsNull()
        {
            ContentDto ContentdtoExpected = new ContentDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlArchive = "",
                UrlImage = ""
            };
            Assert.IsFalse(ContentdtoExpected.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            ContentDto ContentdtoExpected = new ContentDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlArchive = "",
                UrlImage = ""
            };
            Assert.IsFalse(ContentdtoExpected.Equals(new Category()));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDurationFormat))]
        public void CreateContentTest()
        {
         ContentDto ContentdtoExpected = new ContentDto()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "12000sq",
                UrlArchive = "",
                UrlImage = ""
            };
            Content contentDto = ContentdtoExpected.CreateContent();
        }
        
        [TestMethod]
        public void CreateContentTestDurations()
        {
            ContentDto ContentdtoExpected = new ContentDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "12000s",
                UrlArchive = "",
                UrlImage = ""
            };
            Content content = new Content()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12000,
                UrlArchive = "",
                UrlImage = ""
            };
            Content contentDto = ContentdtoExpected.CreateContent();
            Assert.AreEqual(content, contentDto);
        }
        
        [TestMethod]
        public void CreateContentTestDurationS()
        {
            ContentDto ContentdtoExpected = new ContentDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "1200H",
                UrlArchive = "",
                UrlImage = ""
            };
            Content content = new Content()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 1200,
                UrlArchive = "",
                UrlImage = ""
            };
            Content contentDto = ContentdtoExpected.CreateContent();
            Assert.AreEqual(content, contentDto);
        }
        
        [TestMethod]
        public void CreateContentTestDurationM()
        {
            ContentDto ContentdtoExpected = new ContentDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "100m",
                UrlArchive = "",
                UrlImage = ""
            };
            Content content = new Content()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 10*60,
                UrlArchive = "",
                UrlImage = ""
            };
            Content contentDto = ContentdtoExpected.CreateContent();
            Assert.AreEqual(content, contentDto);
        }
        
        [TestMethod]
        public void CreateContentTestDurationH()
        {
            ContentDto ContentdtoExpected = new ContentDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "10h",
                UrlArchive = "",
                UrlImage = ""
            };
            Content content = new Content()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 10*60*60,
                UrlArchive = "",
                UrlImage = ""
            };
            Content contentDto = ContentdtoExpected.CreateContent();
            Assert.AreEqual(content, contentDto);
        }
    }
}