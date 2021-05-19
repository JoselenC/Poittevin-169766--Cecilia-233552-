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
        [ExpectedException(typeof(NotFoundPlaylist), "")]
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
            _playlistService.SetPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByCategoryName("Dormir");
            CollectionAssert.AreEqual(playlists, playlist2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist), "")]
        public void NoFindPlaylistByCategoryName()
        {
            Playlist playlist = new Playlist() {Categories = new List<Category>() {new Category() {Name = "Dormir"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.GetPlaylistByCategoryName("Para correr");
        }

        [TestMethod]
        public void FindPlaylistByAudioName()
        {
            Playlist playlist = new Playlist() {Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByAudioName("Stand by me");
            CollectionAssert.AreEqual(playlists, playlist2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist), "")]
        public void NoFindPlaylistByAudioName()
        {
            Playlist playlist = new Playlist() {Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
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
            _playlistService.SetPlaylist(playlist);
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
            _playlistService.SetPlaylist(playlist);
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
                UrlImage = "",
                Description = "descrption"
            };
            Playlist playlist2 = new Playlist()
            {
                Audios = new List<Audio>() {new Audio() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Musica"}},
                Name = "Entrena tu mente",
                UrlImage = "",
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
        public void DeletePlaylistByID()
        {
            Playlist playlist = new Playlist() {Id = 1};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            playlisMock.Setup(x => x.Delete(playlist));
            playlisMock.Setup(x => x.Add(playlist));
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.SetPlaylist(playlist);
            _playlistService.DeletePlaylist(1);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }

        [TestMethod]
        public void DeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>();
            playlisMock.Setup(x => x.Delete(playlist));
            _playlistService.SetPlaylist(playlist);
            playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.DeletePlaylist(playlist.Id);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist))]
        public void NoDeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Para correr"};
            playlisMock.Setup(x => x.FindById(3)).Returns(playlist);
            playlisMock.Setup(x => x.Delete(playlist)).Throws(new NotFoundPlaylist());
            _playlistService.DeletePlaylist(3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist))]
        public void NoFindDeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Para correr"};
            playlisMock.Setup(x => x.FindById(3)).Returns(playlist);
            playlisMock.Setup(x => x.Delete(playlist)).Throws(new KeyNotFoundException());
            _playlistService.DeletePlaylist(3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void AddPlayListInvalidEmptyName()
        {
            Playlist playlist = new Playlist() {Name = ""};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDescriptionLength), "")]
        public void AddPlayListInvalidDescriptionLength()
        {
            Playlist playlist = new Playlist() {Name = "Entrenmaineto",
                Description = "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrption" +
                              "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiond"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
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
        [ExpectedException(typeof(NotFoundId), "")]
        public void NoFindPlaylistById()
        {
            playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            _playlistService.GetPlaylistById(2);
        }

        [TestMethod]
        public void UpdatePlaylistById()
        {
            Playlist playlist = new Playlist()
            {
                Name = "Yoga", Id = 1,Description = "",Audios = new List<Audio>() {new Audio() {Id=0,Name = "Stand by me"},new Audio() {Id=1,Name = "Stand by me"}},
                UrlImage ="", Categories =new List<Category>() {new Category() {Name = "Musica"}}
            };
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _playlistService.UpdatePlaylistById(1, playlist);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist))]
        public void NoUpdatePlaylisy()
        {
            playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            _playlistService.UpdatePlaylistById(2, new Playlist());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist), "")]
        public void UpdatePlaylistByNotExistId()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1};
            playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            playlisMock.Setup(x => x.Update(playlist, playlist));
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
        
        [TestMethod]
        public void AssociateAudioToPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>()};
            Audio audio = new Audio() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>(){audio}};
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            AudioMock.Setup(x => x.FindById(1)).Returns(audio);
            AudioMock.Setup(a => a.Add(audio));
            playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AssociateAudioToPlaylist(1, 1);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void AssociateInvvalidAudioToPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>()};
            Audio audio = new Audio() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>(){audio}};
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            AudioMock.Setup(x => x.FindById(1)).Throws(new KeyNotFoundException());
            AudioMock.Setup(a => a.Add(audio));
            playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AssociateAudioToPlaylist(1, 1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void AssociateAudioToInvalidPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>()};
            Audio audio = new Audio() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>(){audio}};
            playlisMock.Setup(x => x.FindById(1)).Throws(new KeyNotFoundException());
            AudioMock.Setup(x => x.FindById(1)).Returns(audio);
            AudioMock.Setup(a => a.Add(audio));
            playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AssociateAudioToPlaylist(1, 1);
        }
        
        [TestMethod]
        public void AddNewAudioToPlaylistTest()
        {
            Playlist playlist = new Playlist()
            {
                Name = "Yoga", Id = 1,Audios = new List<Audio>(),
                Categories = new List<Category>()
            };
            Audio audio = new Audio() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>(){audio}};
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            AudioMock.Setup(x => x.FindById(1)).Returns(audio);
            AudioMock.Setup(a => a.Add(audio)).Returns(audio);
            playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AddNewAudioToPlaylist(audio, 1);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }
        
        [TestMethod]
        public void AddNewAudioDiffCategoriesToPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>(), 
                Categories = new List<Category>(){new Category(){Name ="Musica"}}};
            Audio audio = new Audio() {Name = "Let it be", Id = 1,Categories = new List<Category>()};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>(){audio}};
            playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            AudioMock.Setup(a => a.Add(audio)).Returns(audio);
            playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AddNewAudioToPlaylist(audio, 1);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }
       
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void AddNewAudioToInvalidPlaylistTest()
        {
            Playlist playlist = new Playlist()
            {
                Name = "Yoga", Id = 1,Audios = new List<Audio>(),
                Categories = new List<Category>()
            };
            Audio audio = new Audio() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Audios = new List<Audio>(){audio}};
            playlisMock.Setup(x => x.FindById(1)).Throws(new KeyNotFoundException());
            AudioMock.Setup(x => x.FindById(1)).Returns(audio);
            AudioMock.Setup(a => a.Add(audio)).Returns(audio);
            playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AddNewAudioToPlaylist(audio, 1);
        }
    }
}