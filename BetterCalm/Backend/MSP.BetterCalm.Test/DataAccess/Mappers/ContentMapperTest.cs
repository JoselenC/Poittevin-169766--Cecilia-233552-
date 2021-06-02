using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.DataAccess.Mappers;
using MSP.BetterCalm.DataAccess.Repositories;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class ContentMapperTest
    {
        private DbContextOptions<ContextDb> _options;
        private ContextDb _context;
        private DataBaseRepository<Content, ContentDto> _repoContents;
        private Content _contentTest;
        private Category _category1;
        private Category _category2;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _options = new DbContextOptionsBuilder<ContextDb>().UseInMemoryDatabase(databaseName: "BetterCalmDB")
                .Options;
            _context = new ContextDb(_options);
            _repoContents = new DataBaseRepository<Content, ContentDto>(new ContentMapper(), _context.Contents,_context);
            DataBaseRepository<Category, CategoryDto> categRepo = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper(), _context.Categories,
                    _context);
            _category1 = new Category() {Name = "Musica"};
            categRepo.Add(_category1);
            _category2 = new Category() {Name = "Dormir"};
            categRepo.Add(_category2);
            
            _contentTest = new Content() {
                Id = 1,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                UrlImage = "",
                Categories = new List<Category>(){_category1}
            };
            _repoContents.Add(_contentTest);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DomainToDtoTest()
        {
            _repoContents.Add(_contentTest);
            Content actualContent = _repoContents.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(_contentTest, actualContent);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategory))]
        public void DomainToDtoWrongcategoryTest()
        {
            Content contentTest = new Content()
            {
                Id = 0,
                Categories =  new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                UrlImage = ""
            };
            List<Category> Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Category Category"
                }
            };
            contentTest.Categories = Categories;
            _repoContents.Add(contentTest);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Content actualContent = _repoContents.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this._contentTest, actualContent);
        }
        
        [TestMethod]
        public void DtoToDomainWitContentTest()
        {
            _contentTest = new Content() {
                Id = 1,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                UrlImage = "",
                Categories = new List<Category>(){_category1}
            };
            _repoContents.Add(_contentTest);
            Content actualContent = _repoContents.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this._contentTest, actualContent);
        }

        [TestMethod]
        public void DtoToDomainWitPlaylistest()
        {
            _contentTest = new Content() {
                AssociatedToPlaylist = true,
                Id = 1,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                UrlImage = "",
                Categories = new List<Category>(){_category1}
            };
            _repoContents.Add(_contentTest);
            Content actualContent = _repoContents.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this._contentTest, actualContent);
        }
        
        [TestMethod]
        public void UpdateTest()
        {
            Content actualContent = _repoContents.Find(x => x.Name=="Stand by me");
            actualContent.Name = "Help";
            Content updatedContent = _repoContents.Update(_contentTest, actualContent);
            Assert.AreEqual(actualContent, updatedContent);
        }
        
        [TestMethod]
        public void UpdateContentWithCateogryTest()
        {
            Content content =new Content() {
                Id = 1,
                Name = "Help",
                AuthorName = "The beatles",
                Duration = 121,
                UrlArchive = "",
                UrlImage = "",
                Categories = new List<Category>(){_category2,_category1}
            };
            _repoContents.Add(content);
            Content actualContent =new Content() {
                Id = 1,
                Name = "ToUpdate",
                Categories = new List<Category>(){_category2,_category1}
            };
            actualContent.Name = "Help";
            Content updatedContent = _repoContents.Update(content, actualContent);
            Assert.AreEqual(actualContent, updatedContent);
        }
       
        [TestMethod]
        public void UpdateContentWithDiffCateogryTest()
        {
            Content actualContent =new Content() {
                Id = 1,
                Name = "Help",
                AuthorName = "The beatles",
                Duration = 121,
                UrlArchive = "",
                UrlImage = "",
                Categories = new List<Category>(){_category2}
            };
            Content updatedContent = _repoContents.Update(_contentTest, actualContent);
            Assert.AreEqual(actualContent, updatedContent);
        }
    }
}