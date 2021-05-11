using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.Test.WebAPI.Dtos
{
    [TestClass]
    public class VideoDtoTest
    {
        [TestMethod]
        public void GetSetVideoName()
        {
            string VideoName = "Let it be";
            VideoDto Video = new VideoDto();
            Video.Name = "Let it be";
            string getVideoName = Video.Name;
            Assert.AreEqual(VideoName, getVideoName);
        }
      
        [TestMethod]
        public void GetSetVideoUrlArchive()
        {
            string VideoUrlArchive = "UrlArchive";
            VideoDto Video = new VideoDto();
            Video.UrlArchive = "UrlArchive";
            string getVideoUrlArchive = Video.UrlArchive;
            Assert.AreEqual(VideoUrlArchive, getVideoUrlArchive);
        }
        
        [TestMethod]
        public void GetSetVideoDurationH()
        {
            string duration = "23h" ;
            VideoDto Video = new VideoDto();
            Video.Duration = "23h";
            string  getVideoDuration = Video.Duration;
            Assert.AreEqual(duration, getVideoDuration);
        }
        
        [TestMethod]
        public void GetSetVideoDurationM()
        {
            string duration = "23m" ;
            VideoDto Video = new VideoDto();
            Video.Duration = "23m";
            string  getVideoDuration = Video.Duration;
            Assert.AreEqual(duration, getVideoDuration);
        }
        
        [TestMethod]
        public void GetSetVideoDurationS()
        {
            string duration = "23s" ;
            VideoDto Video = new VideoDto();
            Video.Duration = "23s";
            string  getVideoDuration = Video.Duration;
            Assert.AreEqual(duration, getVideoDuration);
        }
        
       
        [TestMethod]
        public void GetSetVideoId()
        {
            int id = 2 ;
            VideoDto Video = new VideoDto();
            Video.Id = 2;
            int getVideoId = Video.Id;
            Assert.AreEqual(id, getVideoId);
        }
        
        [TestMethod]
        public void GetSetVideoCreatorName()
        {
            string CreatorName = "Paul McCartney";
            VideoDto Video = new VideoDto();
            Video.CreatorName = CreatorName;
            string getCreatorName= Video.CreatorName;
            Assert.AreEqual(CreatorName, getCreatorName);
        }
        
        [TestMethod]
        public void GetSetVideoCategories()
        {
            List<Category> categories = new List<Category>();
            VideoDto Video = new VideoDto();
            Video.Categories = categories;
            List<Category> getVideoCategories = Video.Categories;
            Assert.AreEqual(categories, getVideoCategories);
        }
        
        [TestMethod]
        public void CreateVideodtoTest()
        {
            Video Video = new Video()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = ""
            };
            VideoDto VideoDtoExpected = new VideoDto()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "2m",
                UrlArchive = ""
            };
            VideoDto VideoDto = new VideoDto().CreateVideoDto(Video);
            Assert.AreEqual(VideoDtoExpected, VideoDto);
        }
        
        [TestMethod]
        public void CreateVideodto()
        {
            Video Video = new Video()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 60*60*60,
                UrlArchive = ""
            };
            VideoDto VideoDtoExpected = new VideoDto()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "60h",
                UrlArchive = ""
            };
            VideoDto VideoDto = new VideoDto().CreateVideoDto(Video);
            Assert.AreEqual(VideoDtoExpected, VideoDto);
        }
        
       [TestMethod]
        public void EqualsNull()
        {
            VideoDto VideodtoExpected = new VideoDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "2m",
                UrlArchive = ""
            };
            Assert.IsFalse(VideodtoExpected.Equals(null));
        }
        
        [TestMethod]
        public void EqualsDiffType()
        {
            VideoDto VideodtoExpected = new VideoDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "2m",
                UrlArchive = ""
            };
            Assert.IsFalse(VideodtoExpected.Equals(new Category()));
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDurationFormat))]
        public void CreateVideoTest()
        {
         VideoDto VideodtoExpected = new VideoDto()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "12000sq",
                UrlArchive = ""
            };
            Video VideoDto = VideodtoExpected.CreateVideo();
        }
        
        [TestMethod]
        public void CreateVideoTestDurations()
        {
            VideoDto VideodtoExpected = new VideoDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "12000s",
                UrlArchive = ""
            };
            Video Video = new Video()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12000,
                UrlArchive = ""
            };
            Video VideoDto = VideodtoExpected.CreateVideo();
            Assert.AreEqual(Video, VideoDto);
        }
        
        [TestMethod]
        public void CreateVideoTestDurationS()
        {
            VideoDto VideodtoExpected = new VideoDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "1200H",
                UrlArchive = ""
            };
            Video Video = new Video()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 1200,
                UrlArchive = ""
            };
            Video VideoDto = VideodtoExpected.CreateVideo();
            Assert.AreEqual(Video, VideoDto);
        }
        
        [TestMethod]
        public void CreateVideoTestDurationM()
        {
            VideoDto VideodtoExpected = new VideoDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "100m",
                 
                UrlArchive = ""
            };
            Video Video = new Video()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 10*60,
                 
                UrlArchive = ""
            };
            Video VideoDto = VideodtoExpected.CreateVideo();
            Assert.AreEqual(Video, VideoDto);
        }
        
        [TestMethod]
        public void CreateVideoTestDurationH()
        {
            VideoDto VideodtoExpected = new VideoDto()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "10h",
                 
                UrlArchive = ""
            };
            Video Video = new Video()
            {
                Id=0,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 10*60*60,
                 
                UrlArchive = ""
            };
            Video VideoDto = VideodtoExpected.CreateVideo();
            Assert.AreEqual(Video, VideoDto);
        }
    }
}