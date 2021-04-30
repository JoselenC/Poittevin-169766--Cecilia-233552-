using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistServiceTest
    {

        private Mock<ManagerPlaylistRepository> repoMock;
        private Mock<ManagerAudioRepository> repoAudioMock;
        private Mock<IRepository<Playlist>> playlisMock;
        private Mock<IRepository<Audio>> AudioMock;
        private PlaylistService _playlistService;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoAudioMock = new Mock<ManagerAudioRepository>();
            repoMock = new Mock<ManagerPlaylistRepository>();
            playlisMock = new Mock<IRepository<Playlist>>();
            AudioMock = new Mock<IRepository<Audio>>();
            repoMock.Object.Playlists = playlisMock.Object;
            repoAudioMock.Object.Audios = AudioMock.Object;
            _playlistService = new PlaylistService(repoMock.Object, repoAudioMock.Object);
        }

        [TestMethod]
        public void FindPlaylistByName()
        {
            Playlist playlist = new Playlist() {Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            playlisMock.Setup(x => x.Find(It.IsAny<Predicate<Playlist>>())).Returns(playlist);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByName("Entrena tu mente");
            CollectionAssert.AreEqual(playlist2, playlists);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindPlaylistByName()
        {
            Playlist playlist = new Playlist() {Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            playlisMock.Setup(x => x.Find(It.IsAny<Predicate<Playlist>>())).Returns(playlist);
            _playlistService.GetPlaylistByName("Para correr");
        }

        [TestMethod]
        public void FindPlaylistByCategoryName()
        {
            Playlist playlist = new Playlist() {Categories = new List<Category>() {new Category() {Name = "Dormir"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByCategoryName("Dormir");
            CollectionAssert.AreEqual(playlists, playlist2);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindPlaylistByCategoryName()
        {
            Playlist playlist = new Playlist() {Categories = new List<Category>() {new Category() {Name = "Dormir"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.GetPlaylistByCategoryName("Para correr");
        }

        [TestMethod]
        public void FindPlaylistByAudioName()
        {
            Playlist playlist = new Playlist() {Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByAudioName("Stand by me");
            CollectionAssert.AreEqual(playlists, playlist2);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindPlaylistByAudioName()
        {
            Playlist playlist = new Playlist() {Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.GetPlaylistByAudioName("Para correr");
        }

        [TestMethod]
        public void GetPlaylist()
        {
            Playlist playlist = new Playlist() {Categories = new List<Category>() {new Category() {Name = "Dormir"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void SetPlaylist()
        {
            Playlist playlist = new Playlist()
            {
                Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Entrena tu mente"
            };
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void SetPlaylistId()
        {
            Playlist playlist = new Playlist()
            {
                Id = 1,
                Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Entrena tu mente"
            };
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void UpdatPlaylist()
        {
            Playlist playlist1 = new Playlist()
            {
                Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            Playlist playlist2 = new Playlist()
            {
                Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Musica"}},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>() {playlist2};
            playlisMock.Setup(x => x.Update(playlist1, playlist2));
            _playlistService.UpdatePlaylist(playlist1, playlist2);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoDeletePlaylistByName()
        {
            Playlist playlist = new Playlist() {Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            playlisMock.Setup(x => x.Find(It.IsAny<Predicate<Playlist>>())).Throws(new KeyNotFoundException());
            playlisMock.Setup(x => x.Delete(playlist)).Throws(new KeyNotFoundException());
            _playlistService.DeletePlaylistByName("Para correr");
        }

        [TestMethod]
        public void DeletePlaylistByID()
        {
            Playlist playlist = new Playlist() {Id = 1};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Delete(playlist));
            playlisMock.Setup(x => x.Add(playlist));
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.AddPlaylist(playlist);
            _playlistService.DeletePlaylist(1);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }

        [TestMethod]
        public void DeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>();
            playlisMock.Setup(x => x.Delete(playlist));
            _playlistService.AddPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.DeletePlaylist(playlist.Id);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectWasNotDeleted), "")]
        public void NoDeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Para correr"};
            playlisMock.Setup(x => x.FindById(3)).Returns(playlist);
            playlisMock.Setup(x => x.Delete(playlist)).Throws(new ObjectWasNotDeleted());
            _playlistService.DeletePlaylist(3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void AddPlayListInvalidEmptyName()
        {
            Playlist playlist = new Playlist() {Name = ""};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists)).Throws(new InvalidNameLength());
            _playlistService.AddPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDescriptionLength), "")]
        public void AddPlayListInvalidDescriptionLength()
        {
            Playlist playlist = new Playlist() {Name = "Entrenmaineto",
                Description = "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrption" +
                              "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiond"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Set(playlists)).Throws(new InvalidDescriptionLength());
            _playlistService.AddPlaylist(playlist);
        }

        [TestMethod]
        public void FindPlaylistById()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1};
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            Playlist playlist3 = _playlistService.GetPlaylistById(1);
            Assert.AreEqual(playlist, playlist3);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void FindPlaylistByNotExistId()
        {
            playlisMock.Setup(x => x.FindById(2)).Throws(new NotFoundId());
            _playlistService.GetPlaylistById(2);
        }

        [TestMethod]
        public void UpdatePlaylistById()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1};
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _playlistService.UpdatePlaylistById(1, playlist);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(ObjectWasNotUpdated), "")]
        public void UpdatePlaylistByNotExistId()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1};
            playlisMock.Setup(x => x.FindById(2)).Throws(new ObjectWasNotUpdated());
            playlisMock.Setup(x => x.Update(playlist, playlist)).Throws(new KeyNotFoundException());
            _playlistService.UpdatePlaylistById(2, playlist);
        }

        [TestMethod]
        public void UpdatePlaylist()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1};
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _playlistService.UpdatePlaylist(playlist, playlist);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoUpdatePlaylist()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 2};
            playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            playlisMock.Setup(x => x.Update(playlist, playlist)).Throws(new KeyNotFoundException());
            _playlistService.UpdatePlaylist(playlist, playlist);
        }
    }
}