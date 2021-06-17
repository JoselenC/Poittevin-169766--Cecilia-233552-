using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;
using ContentDto = MSP.BetterCalm.WebAPI.Dtos.ContentDto;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class ContentControllerTest
    {
        private Mock<IContentService> mockContentService;
        private ContentController ContentController ;
        private List<Content> Contents;
        private List<ContentDto> ContentsDtos;
        private Content _content;
        private ContentDto ContentDto;
            
        [TestInitialize]
        public void InitializeTest()
        {
            mockContentService=new Mock<IContentService>(MockBehavior.Strict);
            ContentController = new ContentController(mockContentService.Object);
            Contents = new List<Content>();
            _content = new Content()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                UrlImage = "",
                Type = "audio"
            };
            Contents.Add(_content);
            ContentDto = new ContentDto()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "120s",
                UrlArchive = "",
                UrlImage = "",
                Type = "audio"
            };
            ContentsDtos = new List<ContentDto>();
            foreach (Content Content in Contents)
            {
                ContentsDtos.Add(new ContentDto().CreateContentDto(Content));
            }

        }
        
        [TestMethod]
        public void TestGetAllContents()
        {
            mockContentService.Setup(m => m.GetContents()).Returns(Contents);
            var result = ContentController.GetAll();
            var okResult = result as OkObjectResult;
            List<ContentDto> ContentsValue = (List<ContentDto>) okResult.Value;
            CollectionAssert.AreEqual(ContentsDtos,ContentsValue);
        }
        
        [TestMethod]
        public void TestGetContentByName()
        {
            mockContentService.Setup(m => m.GetContentsByName("Stand by me")).Returns(Contents);
            var result = ContentController.GetContentsByName("Stand by me");
            var okResult = result as OkObjectResult;
            List<ContentDto> ContentsValue = (List<ContentDto>) okResult.Value;
            CollectionAssert.AreEqual(ContentsDtos,ContentsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetContentByName()
        {
            mockContentService.Setup(m => m.GetContentsByName("Stand by me")).Throws(new KeyNotFoundException());
            var result = ContentController.GetContentsByName("Stand by me") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestGetContentByAuthorName()
        {
            mockContentService.Setup(m => m.GetContentsByAuthor("John Lennon")).Returns(Contents);
            var result = ContentController.GetContentsByAuthor("John Lennon");
            var okResult = result as OkObjectResult;
            List<ContentDto> ContentsValue = (List<ContentDto>) okResult.Value;
            CollectionAssert.AreEqual(ContentsDtos,ContentsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetContentByAuthorName()
        {
            mockContentService.Setup(m => m.GetContentsByAuthor("John Lennon")).Throws(new KeyNotFoundException());
            var result = ContentController.GetContentsByAuthor("John Lennon")as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestCreateContent()
        {
            ContentDto expectedContent = new ContentDto()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "12s",
                UrlArchive = "",
                UrlImage = "",
                Type = "audio"
            };
            Content content = new Content()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = "",
                Type = "audio"
            };
            mockContentService.Setup(m => m.SetContent(content)).Returns(content);
            var result = ContentController.CreateContent(expectedContent);
            var okResult = result as CreatedResult;
            var ContentsValue = okResult.Value;
            Assert.AreEqual(expectedContent,ContentsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength))]
        public void TestNoCreateContentEmptyName()
        {
            mockContentService.Setup(m => m.SetContent(_content)).Throws(new InvalidNameLength());
            ContentController.CreateContent(ContentDto);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisContent))]
        public void TestNoCreateContent()
        {
            mockContentService.Setup(m => m.SetContent(_content)).Throws(new AlreadyExistThisContent());
            ContentController.CreateContent(ContentDto);
        }
        
        [TestMethod]
        public void TestGetContentByCategoryNAme()
        {
            mockContentService.Setup(m => m.SetContent(_content)).Returns(_content);
            ContentController.CreateContent(ContentDto);
            mockContentService.Setup(m => m.GetContentsByCategoryName("Dormir")).Returns(Contents);
            var result = ContentController.GetContentsByCategoryName("Dormir");
            var okResult = result as OkObjectResult;
            List<ContentDto> ContentsValue = (List<ContentDto>) okResult.Value;
            CollectionAssert.AreEqual(ContentsDtos,ContentsValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetContentByCategoryNAme()
        {
            mockContentService.Setup(m => m.GetContentsByCategoryName("Dormir")).Throws(new KeyNotFoundException());
            var result = ContentController.GetContentsByCategoryName("Dormir") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestDeleteContent()
        {
            mockContentService.Setup(m => m.SetContent(_content)).Returns(_content);
            ContentController.CreateContent(ContentDto);
            mockContentService.Setup(m => m.DeleteContent(_content.Id));
            var result = ContentController.DeleteContent(_content.Id);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Content removed",value);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoDeleteContent()
        {
            mockContentService.Setup(m => m.DeleteContent(_content.Id)).Throws(new KeyNotFoundException());
            ContentController.DeleteContent(_content.Id);
        }
       
        [TestMethod]
        public void TestGetContentById()
        {
            ContentDto = new ContentDto()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlArchive = "",
                UrlImage = "",
                Type = "audio"
            };
            mockContentService.Setup(m => m.GetContentById(1)).Returns(_content);
            var result = ContentController.GetContentById(1);
            var okResult = result as OkObjectResult;
            var realContentDto =  okResult.Value;
            Assert.AreEqual(ContentDto,realContentDto);
        }
        
       
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetContentById()
        {
            mockContentService.Setup(m => m.GetContentById(1)).Throws(new KeyNotFoundException());
            ContentController.GetContentById(1);
        }
        
        [TestMethod]
        public void TestUpdateContent()
        {
            mockContentService.Setup(m => m.UpdateContentById(1, _content));
            var result = ContentController.UpdateContent(1,ContentDto);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoUpdateContent()
        {
            mockContentService.Setup(m => m.UpdateContentById(1, _content)).Throws(new KeyNotFoundException());
            ContentController.UpdateContent(1, ContentDto);
        }
    }
}