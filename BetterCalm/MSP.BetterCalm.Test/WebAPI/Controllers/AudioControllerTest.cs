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
using AudioDto = MSP.BetterCalm.WebAPI.Dtos.AudioDto;

namespace MSP.BetterCalm.Test.WebAPI
{
    [TestClass]
    public class AudioControllerTest
    {
        private Mock<IAudioService> mockAudioService;
        private AudioController AudioController ;
        private List<Audio> Audios;
        private Audio _audio;
        private BetterCalm.WebAPI.Dtos.AudioDto AudioDto;
            
        [TestInitialize]
        public void InitializeTest()
        {
            mockAudioService=new Mock<IAudioService>(MockBehavior.Strict);
            AudioController = new AudioController(mockAudioService.Object);
            Audios = new List<Audio>();
            _audio = new Audio()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""
            };
            AudioDto = new BetterCalm.WebAPI.Dtos.AudioDto()
            {
                Id = 1,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "120s",
                UrlAudio = "",
                UrlImage = ""
            };
        }
        
        [TestMethod]
        public void TestGetAllAudios()
        {
            mockAudioService.Setup(m => m.GetAudios()).Returns(this.Audios);
            var result = AudioController.GetAll();
            var okResult = result as OkObjectResult;
            var AudiosValue = okResult.Value;
            Assert.AreEqual(this.Audios,AudiosValue);
        }
        
        [TestMethod]
        public void TestGetAudioByName()
        {
            mockAudioService.Setup(m => m.GetAudiosByName("Stand by me")).Returns(Audios);
            var result = AudioController.GetAudiosByName("Stand by me");
            var okResult = result as OkObjectResult;
            var AudiosValue = okResult.Value;
            Assert.AreEqual(Audios,AudiosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetAudioByName()
        {
            mockAudioService.Setup(m => m.GetAudiosByName("Stand by me")).Throws(new KeyNotFoundException());
            var result = AudioController.GetAudiosByName("Stand by me") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestGetAudioByAuthorName()
        {
            mockAudioService.Setup(m => m.GetAudiosByAuthor("John Lennon")).Returns(Audios);
            var result = AudioController.GetAudiosByAuthor("John Lennon");
            var okResult = result as OkObjectResult;
            var AudiosValue = okResult.Value;
            Assert.AreEqual(Audios,AudiosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetAudioByAuthorName()
        {
            mockAudioService.Setup(m => m.GetAudiosByAuthor("John Lennon")).Throws(new KeyNotFoundException());
            var result = AudioController.GetAudiosByAuthor("John Lennon")as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestCreateAudio()
        {
            AudioDto AudioToAdd = new AudioDto()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "12s",
                UrlAudio = "",
                UrlImage = ""
            };
            Audio audio = new Audio()
            {
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            mockAudioService.Setup(m => m.SetAudio(audio)).Returns(audio);
            AudioController.CreateAudio(AudioToAdd);
            mockAudioService.Setup(m => m.GetAudios()).Returns(Audios);
            var result = AudioController.GetAll();
            var okResult = result as OkObjectResult;
            var AudiosValue = okResult.Value;
            Assert.AreEqual(Audios,AudiosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength))]
        public void TestNoCreateAudioEmptyName()
        {
            mockAudioService.Setup(m => m.SetAudio(_audio)).Throws(new InvalidNameLength());
            AudioController.CreateAudio(AudioDto);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisAudio))]
        public void TestNoCreateAudio()
        {
            mockAudioService.Setup(m => m.SetAudio(_audio)).Throws(new AlreadyExistThisAudio());
            AudioController.CreateAudio(AudioDto);
        }
        
        [TestMethod]
        public void TestGetAudioByCategoryNAme()
        {
            mockAudioService.Setup(m => m.SetAudio(_audio)).Returns(_audio);
            AudioController.CreateAudio(AudioDto);
            mockAudioService.Setup(m => m.GetAudiosByCategoryName("Dormir")).Returns(Audios);
            var result = AudioController.GetAudiosByCategoryName("Dormir");
            var okResult = result as OkObjectResult;
            var AudiosValue = okResult.Value;
            Assert.AreEqual(Audios,AudiosValue);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetAudioByCategoryNAme()
        {
            mockAudioService.Setup(m => m.GetAudiosByCategoryName("Dormir")).Throws(new KeyNotFoundException());
            var result = AudioController.GetAudiosByCategoryName("Dormir") as NotFoundObjectResult;
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void TestDeleteAudio()
        {
            mockAudioService.Setup(m => m.SetAudio(_audio)).Returns(_audio);
            AudioController.CreateAudio(AudioDto);
            mockAudioService.Setup(m => m.DeleteAudio(_audio.Id));
            var result = AudioController.DeleteAudio(_audio.Id);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Audio removed",value);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoDeleteAudio()
        {
            mockAudioService.Setup(m => m.DeleteAudio(_audio.Id)).Throws(new KeyNotFoundException());
            AudioController.DeleteAudio(_audio.Id);
        }
        
        [TestMethod]
        public void TestDeleteAudioFromBody()
        {
            mockAudioService.Setup(m => m.SetAudio(_audio)).Returns(_audio);
            AudioController.CreateAudio(AudioDto);
            mockAudioService.Setup(m => m.DeleteAudio(_audio.Id));
            var result = AudioController.DeleteAudio(AudioDto);
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            Assert.AreEqual("Audio removed",value);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoDeleteAudioFromBody()
        {
            mockAudioService.Setup(m => m.DeleteAudio(_audio.Id)).Throws(new KeyNotFoundException());
            AudioController.DeleteAudio(AudioDto);
        }
        
        [TestMethod]
        public void TestGetAudioById()
        {
            AudioDto = new BetterCalm.WebAPI.Dtos.AudioDto()
            {
                Id = 0,
                Categories = new List<Category>(),
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = "2m",
                UrlAudio = "",
                UrlImage = ""
            };
            mockAudioService.Setup(m => m.GetAudioById(1)).Returns(_audio);
            var result = AudioController.GetAudioById(1);
            var okResult = result as OkObjectResult;
            var categoryValue = okResult.Value;
            Assert.AreEqual(AudioDto,categoryValue);
        }
        
       
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoGetAudioById()
        {
            mockAudioService.Setup(m => m.GetAudioById(1)).Throws(new KeyNotFoundException());
            AudioController.GetAudioById(1);
        }
        
        [TestMethod]
        public void TestUpdateAudio()
        {
            mockAudioService.Setup(m => m.UpdateAudioById(1, _audio));
            var result = AudioController.UpdateAudio(1,AudioDto);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestNoUpdateAudio()
        {
            mockAudioService.Setup(m => m.UpdateAudioById(1, _audio)).Throws(new KeyNotFoundException());
            AudioController.UpdateAudio(1, AudioDto);
        }
    }
}