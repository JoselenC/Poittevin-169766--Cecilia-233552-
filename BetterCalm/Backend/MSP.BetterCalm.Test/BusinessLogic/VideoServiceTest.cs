using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VideoServiceTest
    {
        private Mock<ManagerVideoRepository> repoMock;
        private Mock<IRepository<Video>> VideosMock;
        private VideoService _VideoService;
        private ContextDB context = new ContextDB();

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerVideoRepository>();
            VideosMock = new Mock<IRepository<Video>>();
            repoMock.Object.Videos =  VideosMock.Object;
            _VideoService = new VideoService(repoMock.Object);
        }

        [TestMethod]
        public void FindVideoByName()
        {
            Video Video1 = new Video() {Name = "Stand by me"};
            VideosMock.Setup(x => x.Find(It.IsAny<Predicate<Video>>())).Returns(Video1);
            List<Video> Videos = new List<Video>() {Video1};
            VideosMock.Setup(x => x.Get()).Returns(Videos);
            List<Video> Videos3 = _VideoService.GetVideosByName("Stand by me");
            CollectionAssert.AreEqual(Videos, Videos3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVideo), "")]
        public void NoFindVideoByName()
        {
            Video Video1 = new Video() {Name = "Stand by me"};
            VideosMock.Setup(x => x.Find(It.IsAny<Predicate<Video>>())).Returns(Video1);
            List<Video> Videos = new List<Video>() {Video1};
            VideosMock.Setup(x => x.Get()).Returns(Videos);
            _VideoService.GetVideosByName("LetITBE");
        }
        
        [TestMethod]
        public void FindVideoByAuthor()
        {
            Video Video1 = new Video() {Name = "Stand by me", CreatorName = "John Lennon"};
            VideosMock.Setup(x => x.Find(It.IsAny<Predicate<Video>>())).Returns(Video1);
            List<Video> Videos = new List<Video>() {Video1};
            VideosMock.Setup(x => x.Get()).Returns(Videos);
            List<Video> Videos3 = _VideoService.GetVideosByAuthor("John Lennon");
            CollectionAssert.AreEqual(Videos, Videos3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVideo), "")]
        public void NoFindVideoByAuthor()
        {
            Video Video1 = new Video() {Name = "Stand by me", CreatorName = "John Lennon"};
            VideosMock.Setup(x => x.Find(It.IsAny<Predicate<Video>>())).Returns(Video1);
            List<Video> Videos = new List<Video>() {Video1};
            VideosMock.Setup(x => x.Get()).Returns(Videos);
           _VideoService.GetVideosByAuthor("Ringo Starr");
        }
        
        [TestMethod]
        public void GetVideos()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Video Video = new Video()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            List<Video> Videos1 = new List<Video> {Video};
            VideosMock.Setup(x => x.Get()).Returns(Videos1);
            List<Video> Videos2 = _VideoService.GetVideos();
            CollectionAssert.AreEqual(Videos1, Videos2);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistVideo), "")]
        public void SetVideos()
        {    
            Video Video = new Video()
            {
                Id=4,
                Name = "Let it be",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(3)).Throws(new AlreadyExistVideo());
            _VideoService.SetVideo(Video);
        }

        [TestMethod]
        public void SetVideoTest()
        {    
            Video Video = new Video()
            {
                Id=1,
                Name = "Help",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.Add(Video)).Returns(Video);
            VideosMock.Setup(x => x.FindById(Video.Id)).Throws(new KeyNotFoundException());
            Video VideoAdded=_VideoService.SetVideo(Video);
            Assert.AreEqual(Video,VideoAdded);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistVideo), "")]
        public void SetVideosRepeted()
        {    
            Video Video = new Video()
            {
                Id=4,
                Name = "Let it be",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            _VideoService.SetVideo(Video);
            _VideoService.SetVideo(Video);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetVideosInvalidName()
        {
            Video Video = new Video() {Name = ""};
            List<Video> Videos1 = new List<Video> {Video};
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistVideo), "")]
        public void SetVideoRepeted()
        {    
            Video Video = new Video() {Name = "Let it be"};
            List<Video> Videos1 = new List<Video> {Video};
            _VideoService.SetVideo(Video);
            _VideoService.SetVideo(Video);
        }

       
        [TestMethod]
        public void FindVideoByCategoryName()
        {
            Category category = new Category() {Name = "Dormir"};
            Video Video1 = new Video()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            List<Video> Videos = new List<Video>() {Video1, Video1, Video1, Video1};
            VideosMock.Setup(x => x.Get()).Returns(Videos);
            List<Video> Video3 = _VideoService.GetVideosByCategoryName("Dormir");
            CollectionAssert.AreEqual(Videos, Video3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVideo), "")]
        public void NoFindVideoByCategoryName()
        {
            Video Video1 = new Video()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me"
            };
            List<Video> Videos = new List<Video>() {Video1, Video1, Video1, Video1};
            VideosMock.Setup(x => x.Get()).Returns(Videos);
            _VideoService.GetVideosByCategoryName("Musica");
        }
        
      [TestMethod]
        public void DeleteVideo()
        {
            Video Video1 = new Video()
            {
                Id = 1,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            Video Video2 = new Video()
            {
                Id = 1,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            List<Video> Videos = new List<Video>(){Video1,Video2};
            VideosMock.Setup(x => x.FindById(Video2.Id)).Returns(Video1);
            VideosMock.Setup(x => x.Delete(Video1));
            VideosMock.Setup(x => x.Get()).Returns(Videos);
            _VideoService.DeleteVideo(Video1.Id);
            List<Video> VideoPostDelete = _VideoService.GetVideos();
            CollectionAssert.AreEqual(VideoPostDelete, Videos);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistVideo), "")]
        public void NoSetVideo()
        {
            Video Video1 = new Video()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.Add(Video1)).Throws(new AlreadyExistVideo());
            _VideoService.SetVideo(Video1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void NoSetVideoInvalidName()
        {
            Video Video1 = new Video()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.Add(Video1)).Throws(new InvalidNameLength());
            _VideoService.SetVideo(Video1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVideo))]
        public void NoDeleteVideo()
        {
            Video Video1 = new Video()
            {
                Id=3,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(Video1.Id)).Throws(new NotFoundVideo());
            _VideoService.DeleteVideo(Video1.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundVideo))]
        public void NoFindDeleteVideo()
        {
            Video Video1 = new Video()
            {
                Id=3,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(Video1.Id)).Throws(new KeyNotFoundException());
            _VideoService.DeleteVideo(Video1.Id);
        }
        
        [TestMethod]
        public void UpdateVideoTest()
        {  
            Video Video = new Video()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            List<Video> Videos1 = new List<Video> {Video};
            VideosMock.Setup(x => x.FindById(2)).Returns(Video);
            VideosMock.Setup(x => x.Update(Video,Video));
            VideosMock.Setup(x => x.Get()).Returns(Videos1);
            _VideoService.UpdateVideoById(2,Video);
            List<Video> Videos2 = _VideoService.GetVideos();
            CollectionAssert.AreEqual(Videos1, Videos2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVideo), "")]
        public void NoUpdateVideoTest()
        {  
            Video Video = new Video()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(7)).Throws(new KeyNotFoundException());
            _VideoService.UpdateVideoById(7,Video);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundVideo))]
        public void NoFindUpdateVideoTest()
        {  
            Video Video = new Video()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(7)).Throws(new KeyNotFoundException());
            _VideoService.UpdateVideoById(7,Video);
        }
        
        [TestMethod]
        public void GetVideoByIDTest()
        {  
            Video Video = new Video()
            {
                AssociatedToPlaylist = false,
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(2)).Returns(Video);
            Video VideoFind=_VideoService.GetVideoById(2);
            Assert.AreEqual(Video, VideoFind);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void GetVideoByIDAssociatedTest()
        {  
            Video Video = new Video()
            {
                AssociatedToPlaylist = true,
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(2)).Returns(Video);
           _VideoService.GetVideoById(2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void GetVideoByIDKeyNotFountTest()
        {  
            Video Video = new Video()
            {
                AssociatedToPlaylist = true,
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());;
            _VideoService.GetVideoById(2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void NoGetVideoByIDTest()
        {   
            Video Video = new Video()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it e",
                CreatorName = "John Lennon",
                Duration = 12,
                UrlArchive = ""
            };
            VideosMock.Setup(x => x.FindById(3)).Throws(new NotFoundId());
            _VideoService.GetVideoById(3);
        }
    }
}