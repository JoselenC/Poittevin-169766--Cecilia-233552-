using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VideoMapperTest
    {
        private DbContextOptions<ContextDB> options;
        private ContextDB context;
        private DataBaseRepository<Video, VideoDto> RepoVideos;
        private Video VideoTest;
        private Category category1;
        private Category category2;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB")
                .Options;
            context = new ContextDB(options);
            RepoVideos = new DataBaseRepository<Video, VideoDto>(new VideoMapper(), context.Videos,context);
            DataBaseRepository<Category, CategoryDto> categRepo = new DataBaseRepository<Category, CategoryDto>(new CategoryMapper(), context.Categories,
                    context);
            category1 = new Category() {Name = "Musica"};
            categRepo.Add(category1);
            category2 = new Category() {Name = "Dormir"};
            categRepo.Add(category2);
            
            VideoTest = new Video() {
                Id = 1,
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                Categories = new List<Category>(){category1}
            };
            RepoVideos.Add(VideoTest);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DomainToDtoTest()
        {
            RepoVideos.Add(VideoTest);
            Video actualVideo = RepoVideos.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(VideoTest, actualVideo);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCategory))]
        public void DomainToDtoWrongcategoryTest()
        {
            Video VideoTest = new Video()
            {
                Id = 0,
                Categories =  new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = ""
            };
            List<Category> Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Category Category"
                }
            };
            VideoTest.Categories = Categories;
            RepoVideos.Add(VideoTest);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Video actualVideo = RepoVideos.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this.VideoTest, actualVideo);
        }
        
        [TestMethod]
        public void DtoToDomainWitVideoTest()
        {
            VideoTest = new Video() {
                Id = 1,
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                Categories = new List<Category>(){category1}
            };
            RepoVideos.Add(VideoTest);
            Video actualVideo = RepoVideos.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this.VideoTest, actualVideo);
        }

        [TestMethod]
        public void DtoToDomainWitPlaylistest()
        {
            VideoTest = new Video() {
                AssociatedToPlaylist = true,
                Id = 1,
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = "",
                Categories = new List<Category>(){category1}
            };
            RepoVideos.Add(VideoTest);
            Video actualVideo = RepoVideos.Find(x => x.Name == "Stand by me");
            Assert.AreEqual(this.VideoTest, actualVideo);
        }
        
        [TestMethod]
        public void UpdateTest()
        {
            Video actualVideo = RepoVideos.Find(x => x.Name=="Stand by me");
            actualVideo.Name = "Help";
            Video updatedVideo = RepoVideos.Update(VideoTest, actualVideo);
            Assert.AreEqual(actualVideo, updatedVideo);
        }
        
        [TestMethod]
        public void UpdateVideoWithCateogryTest()
        {
            Video Video =new Video() {
                Id = 1,
                Name = "Help",
                CreatorName = "The beatles",
                Duration = 121,
                UrlArchive = "",
                Categories = new List<Category>(){category2,category1}
            };
            RepoVideos.Add(Video);
            Video actualVideo =new Video() {
                Id = 1,
                Name = "ToUpdate",
                Categories = new List<Category>(){category2,category1}
            };
            actualVideo.Name = "Help";
            Video updatedVideo = RepoVideos.Update(Video, actualVideo);
            Assert.AreEqual(actualVideo, updatedVideo);
        }
       
        [TestMethod]
        public void UpdateVideoWithDiffCateogryTest()
        {
            Video actualVideo =new Video() {
                Id = 1,
                Name = "Help",
                CreatorName = "The beatles",
                Duration = 121,
                UrlArchive = "",
                Categories = new List<Category>(){category2}
            };
            Video updatedVideo = RepoVideos.Update(VideoTest, actualVideo);
            Assert.AreEqual(actualVideo, updatedVideo);
        }
    }
}