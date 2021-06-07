using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test.BusinessLogic
{
    [TestClass]
    public class ContentserviceTest
    {
        private Mock<ManagerContentRepository> _repoMock;
        private Mock<IRepository<Content>> _contentsMock;
        private ContentService _contentservice;
        private ContextDb _context = new ContextDb();

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _repoMock = new Mock<ManagerContentRepository>();
            _contentsMock = new Mock<IRepository<Content>>();
            _repoMock.Object.Contents =  _contentsMock.Object;
            _contentservice = new ContentService(_repoMock.Object);
        }

        [TestMethod]
        public void FindContentByName()
        {
            Content content1 = new Content() {Name = "Stand by me"};
            _contentsMock.Setup(x => x.Find(It.IsAny<Predicate<Content>>())).Returns(content1);
            List<Content> contents = new List<Content>() {content1};
            _contentsMock.Setup(x => x.Get()).Returns(contents);
            List<Content> contents3 = _contentservice.GetContentsByName("Stand by me");
            CollectionAssert.AreEqual(contents, contents3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundContent), "")]
        public void NoFindContentByName()
        {
            Content content1 = new Content() {Name = "Stand by me"};
            _contentsMock.Setup(x => x.Find(It.IsAny<Predicate<Content>>())).Returns(content1);
            List<Content> contents = new List<Content>() {content1};
            _contentsMock.Setup(x => x.Get()).Returns(contents);
            _contentservice.GetContentsByName("LetITBE");
        }
        
        [TestMethod]
        public void FindContentByAuthor()
        {
            Content content1 = new Content() {Name = "Stand by me", AuthorName = "John Lennon"};
            _contentsMock.Setup(x => x.Find(It.IsAny<Predicate<Content>>())).Returns(content1);
            List<Content> contents = new List<Content>() {content1};
            _contentsMock.Setup(x => x.Get()).Returns(contents);
            List<Content> contents3 = _contentservice.GetContentsByAuthor("John Lennon");
            CollectionAssert.AreEqual(contents, contents3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundContent), "")]
        public void NoFindContentByAuthor()
        {
            Content content1 = new Content() {Name = "Stand by me", AuthorName = "John Lennon"};
            _contentsMock.Setup(x => x.Find(It.IsAny<Predicate<Content>>())).Returns(content1);
            List<Content> contents = new List<Content>() {content1};
            _contentsMock.Setup(x => x.Get()).Returns(contents);
           _contentservice.GetContentsByAuthor("Ringo Starr");
        }
        
        [TestMethod]
        public void GetContents()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Content content = new Content()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            List<Content> contents1 = new List<Content> {content};
            _contentsMock.Setup(x => x.Get()).Returns(contents1);
            List<Content> contents2 = _contentservice.GetContents();
            CollectionAssert.AreEqual(contents1, contents2);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisContent), "")]
        public void Setcontents()
        {    
            Content content = new Content()
            {
                Id=4,
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(3)).Throws(new AlreadyExistThisContent());
            _contentservice.SetContent(content);
        }

        [TestMethod]
        public void SetContentTest()
        {    
            Content content = new Content()
            {
                Id=1,
                Name = "Help",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.Add(content)).Returns(content);
            _contentsMock.Setup(x => x.FindById(content.Id)).Throws(new KeyNotFoundException());
            Content contentAdded=_contentservice.SetContent(content);
            Assert.AreEqual(content,contentAdded);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisContent), "")]
        public void SetcontentsRepeted()
        {    
            Content content = new Content()
            {
                Id=4,
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentservice.SetContent(content);
            _contentservice.SetContent(content);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetcontentsInvalidName()
        {
            Content content = new Content() {Name = ""};
            List<Content> contents1 = new List<Content> {content};
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisContent), "")]
        public void SetContentRepeted()
        {    
            Content content = new Content() {Name = "Let it be"};
            List<Content> contents1 = new List<Content> {content};
            _contentservice.SetContent(content);
            _contentservice.SetContent(content);
        }

       
        [TestMethod]
        public void FindContentByCategoryName()
        {
            Category category = new Category() {Name = "Dormir"};
            Content content1 = new Content()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            List<Content> contents = new List<Content>() {content1, content1, content1, content1};
            _contentsMock.Setup(x => x.Get()).Returns(contents);
            List<Content> content3 = _contentservice.GetContentsByCategoryName("Dormir");
            CollectionAssert.AreEqual(contents, content3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundContent), "")]
        public void NoFindContentByCategoryName()
        {
            Content content1 = new Content()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me"
            };
            List<Content> contents = new List<Content>() {content1, content1, content1, content1};
            _contentsMock.Setup(x => x.Get()).Returns(contents);
            _contentservice.GetContentsByCategoryName("Musica");
        }
        
      [TestMethod]
        public void DeleteContent()
        {
            Content content1 = new Content()
            {
                Id = 1,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            Content Content2 = new Content()
            {
                Id = 1,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            List<Content> contents = new List<Content>(){content1,Content2};
            _contentsMock.Setup(x => x.FindById(Content2.Id)).Returns(content1);
            _contentsMock.Setup(x => x.Delete(content1));
            _contentsMock.Setup(x => x.Get()).Returns(contents);
            _contentservice.DeleteContent(content1.Id);
            List<Content> contentPostDelete = _contentservice.GetContents();
            CollectionAssert.AreEqual(contentPostDelete, contents);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisContent), "")]
        public void NoSetContent()
        {
            Content content1 = new Content()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.Add(content1)).Throws(new AlreadyExistThisContent());
            _contentservice.SetContent(content1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void NoSetContentInvalidName()
        {
            Content content1 = new Content()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.Add(content1)).Throws(new InvalidNameLength());
            _contentservice.SetContent(content1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundContent))]
        public void NoDeleteContent()
        {
            Content content1 = new Content()
            {
                Id=3,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(content1.Id)).Throws(new NotFoundContent());
            _contentservice.DeleteContent(content1.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundContent))]
        public void NoFindDeleteContent()
        {
            Content content1 = new Content()
            {
                Id=3,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(content1.Id)).Throws(new KeyNotFoundException());
            _contentservice.DeleteContent(content1.Id);
        }
        
        [TestMethod]
        public void UpdateContentTest()
        {  
            Content content = new Content()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            List<Content> contents1 = new List<Content> {content};
            _contentsMock.Setup(x => x.FindById(2)).Returns(content);
            _contentsMock.Setup(x => x.Update(content,content));
            _contentsMock.Setup(x => x.Get()).Returns(contents1);
            _contentservice.UpdateContentById(2,content);
            List<Content> contents2 = _contentservice.GetContents();
            CollectionAssert.AreEqual(contents1, contents2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundContent), "")]
        public void NoUpdateContentTest()
        {  
            Content content = new Content()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(7)).Throws(new KeyNotFoundException());
            _contentservice.UpdateContentById(7,content);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundContent))]
        public void NoFindUpdateContentTest()
        {  
            Content content = new Content()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(7)).Throws(new KeyNotFoundException());
            _contentservice.UpdateContentById(7,content);
        }
        
        [TestMethod]
        public void GetContentByIdTest()
        {  
            Content content = new Content()
            {
                AssociatedToPlaylist = false,
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(2)).Returns(content);
            Content contentFind=_contentservice.GetContentById(2);
            Assert.AreEqual(content, contentFind);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void GetContentByIdAssociatedTest()
        {  
            Content content = new Content()
            {
                AssociatedToPlaylist = true,
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(2)).Returns(content);
           _contentservice.GetContentById(2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void GetContentByIdKeyNotFountTest()
        {  
            Content content = new Content()
            {
                AssociatedToPlaylist = true,
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());;
            _contentservice.GetContentById(2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void NoGetContentByIdTest()
        {   
            Content content = new Content()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it e",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlArchive = "",
                UrlImage = ""
            };
            _contentsMock.Setup(x => x.FindById(3)).Throws(new NotFoundId());
            _contentservice.GetContentById(3);
        }
    }
}