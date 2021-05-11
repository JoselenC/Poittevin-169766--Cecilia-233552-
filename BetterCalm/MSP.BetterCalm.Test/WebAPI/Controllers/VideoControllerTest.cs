using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Controllers;
using MSP.BetterCalm.WebAPI.Dtos;
using VideoDto = MSP.BetterCalm.WebAPI.Dtos.VideoDto;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class VideoControllerTest
    {
        private Mock<IVideoService> mockVideoService;
        private VideoController VideoController ;
        private List<Video> Videos;
        private List<VideoDto> VideosDtos;
        private Video _Video;
        private VideoDto VideoDto;
            
        [TestInitialize]
        public void InitializeTest()
        {
            mockVideoService=new Mock<IVideoService>(MockBehavior.Strict);
            VideoController = new VideoController(mockVideoService.Object);
            Videos = new List<Video>();
            _Video = new Video()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 120,
                UrlArchive = ""
            };
            Videos.Add(_Video);
            VideoDto = new VideoDto()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "120s",
                UrlArchive = ""
            };
            VideosDtos = new List<VideoDto>();
            foreach (Video Video in Videos)
            {
                VideosDtos.Add(new VideoDto().CreateVideoDto(Video));
            }

        }
        
        [TestMethod]
        public void TestGetAllVideos()
        {
            mockVideoService.Setup(m => m.GetVideos()).Returns(Videos);
            var result = VideoController.GetAll();
            var okResult = result as OkObjectResult;
            List<VideoDto> VideosValue = (List<VideoDto>) okResult.Value;
            CollectionAssert.AreEqual(VideosDtos,VideosValue);
        }
        
        [TestMethod]
        public void TestGetVideoByName()
        {
            mockVideoService.Setup(m => m.GetVideosByName("Stand by me")).Returns(Videos);
            var result = VideoController.GetVideosByName("Stand by me");
            var okResult = result as OkObjectResult;
            List<VideoDto> VideosValue = (List<VideoDto>) okResult.Value;
            CollectionAssert.AreEqual(VideosDtos,VideosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetVideoByName()
        {
            mockVideoService.Setup(m => m.GetVideosByName("Stand by me")).Throws(new KeyNotFoundException());
            var result = VideoController.GetVideosByName("Stand by me") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestGetVideoByCreatorName()
        {
            mockVideoService.Setup(m => m.GetVideosByAuthor("John Lennon")).Returns(Videos);
            var result = VideoController.GetVideosByAuthor("John Lennon");
            var okResult = result as OkObjectResult;
            List<VideoDto> VideosValue = (List<VideoDto>) okResult.Value;
            CollectionAssert.AreEqual(VideosDtos,VideosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetVideoByCreatorName()
        {
            mockVideoService.Setup(m => m.GetVideosByAuthor("John Lennon")).Throws(new KeyNotFoundException());
            var result = VideoController.GetVideosByAuthor("John Lennon")as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestCreateVideo()
        {
            VideoDto expectedVideo = new VideoDto()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "12s",
                UrlArchive = ""
            };
            Video Video = new Video()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            mockVideoService.Setup(m => m.SetVideo(Video)).Returns(Video);
            var result = VideoController.CreateVideo(expectedVideo);
            var okResult = result as CreatedResult;
            var VideosValue = okResult.Value;
            Assert.AreEqual(expectedVideo,VideosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength))]
        public void TestNoCreateVideoEmptyName()
        {
            mockVideoService.Setup(m => m.SetVideo(_Video)).Throws(new InvalidNameLength());
            VideoController.CreateVideo(VideoDto);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistVideo))]
        public void TestNoCreateVideo()
        {
            mockVideoService.Setup(m => m.SetVideo(_Video)).Throws(new AlreadyExistVideo());
            VideoController.CreateVideo(VideoDto);
        }
        
        [TestMethod]
        public void TestGetVideoByCategoryNAme()
        {
            mockVideoService.Setup(m => m.SetVideo(_Video)).Returns(_Video);
            VideoController.CreateVideo(VideoDto);
            mockVideoService.Setup(m => m.GetVideosByCategoryName("Dormir")).Returns(Videos);
            var result = VideoController.GetVideosByCategoryName("Dormir");
            var okResult = result as OkObjectResult;
            List<VideoDto> VideosValue = (List<VideoDto>) okResult.Value;
            CollectionAssert.AreEqual(VideosDtos,VideosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetVideoByCategoryNAme()
        {
            mockVideoService.Setup(m => m.GetVideosByCategoryName("Dormir")).Throws(new KeyNotFoundException());
            var result = VideoController.GetVideosByCategoryName("Dormir") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestDeleteVideo()
        {
            mockVideoService.Setup(m => m.SetVideo(_Video)).Returns(_Video);
            VideoController.CreateVideo(VideoDto);
            mockVideoService.Setup(m => m.DeleteVideo(_Video.Id));
            var result = VideoController.DeleteVideo(_Video.Id);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Video removed",value);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoDeleteVideo()
        {
            mockVideoService.Setup(m => m.DeleteVideo(_Video.Id)).Throws(new KeyNotFoundException());
            VideoController.DeleteVideo(_Video.Id);
        }
       
        [TestMethod]
        public void TestGetVideoById()
        {
            VideoDto = new VideoDto()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = "2m",
                UrlArchive = ""
            };
            mockVideoService.Setup(m => m.GetVideoById(1)).Returns(_Video);
            var result = VideoController.GetVideoById(1);
            var okResult = result as OkObjectResult;
            var realVideoDto =  okResult.Value;
            Assert.AreEqual(VideoDto,realVideoDto);
        }
        
       
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetVideoById()
        {
            mockVideoService.Setup(m => m.GetVideoById(1)).Throws(new KeyNotFoundException());
            VideoController.GetVideoById(1);
        }
        
        [TestMethod]
        public void TestUpdateVideo()
        {
            mockVideoService.Setup(m => m.UpdateVideoById(1, _Video));
            var result = VideoController.UpdateVideo(1,VideoDto);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoUpdateVideo()
        {
            mockVideoService.Setup(m => m.UpdateVideoById(1, _Video)).Throws(new KeyNotFoundException());
            VideoController.UpdateVideo(1, VideoDto);
        }
    }
}