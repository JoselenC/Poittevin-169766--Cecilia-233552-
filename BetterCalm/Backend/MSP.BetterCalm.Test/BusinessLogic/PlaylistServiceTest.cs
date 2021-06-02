using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test.BusinessLogic
{
    [TestClass]
    public class PlaylistServiceTest
    {

        private Mock<ManagerPlaylistRepository> _repoMock;
        private Mock<ManagerContentRepository> _repoContentMock;
        private Mock<IRepository<Playlist>> _playlisMock;
        private Mock<IRepository<Content>> _contentMock;
        private PlaylistService _playlistService;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            _repoContentMock = new Mock<ManagerContentRepository>();
            _repoMock = new Mock<ManagerPlaylistRepository>();
            _playlisMock = new Mock<IRepository<Playlist>>();
            _contentMock = new Mock<IRepository<Content>>();
            _repoMock.Object.Playlists = _playlisMock.Object;
            _repoContentMock.Object.Contents = _contentMock.Object;
            _playlistService = new PlaylistService(_repoMock.Object, _repoContentMock.Object);
        }

        [TestMethod]
        public void FindPlaylistByName()
        {
            Playlist playlist = new Playlist() {Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlisMock.Setup(x => x.Find(It.IsAny<Predicate<Playlist>>())).Returns(playlist);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByName("Entrena tu mente");
            CollectionAssert.AreEqual(playlist2, playlists);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist), "")]
        public void NoFindPlaylistByName()
        {
            Playlist playlist = new Playlist() {Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlisMock.Setup(x => x.Find(It.IsAny<Predicate<Playlist>>())).Returns(playlist);
            _playlistService.GetPlaylistByName("Para correr");
        }

        [TestMethod]
        public void FindPlaylistByCategoryName()
        {
            Playlist playlist = new Playlist() {Categories = new List<Category>() {new Category() {Name = "Dormir"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
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
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.GetPlaylistByCategoryName("Para correr");
        }

        [TestMethod]
        public void FindPlaylistByContentName()
        {
            Playlist playlist = new Playlist() {Contents = new List<Content>() {new Content() {Name = "Stand by me"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByContentName("Stand by me");
            CollectionAssert.AreEqual(playlists, playlist2);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist), "")]
        public void NoFindPlaylistByContentName()
        {
            Playlist playlist = new Playlist() {Contents = new List<Content>() {new Content() {Name = "Stand by me"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.GetPlaylistByContentName("Para correr");
        }

        [TestMethod]
        public void GetPlaylist()
        {
            Playlist playlist = new Playlist() {Categories = new List<Category>() {new Category() {Name = "Dormir"}}, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void SetPlaylist()
        {
            Playlist playlist = new Playlist()
            {
                Contents = new List<Content>() {new Content() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Entrena tu mente"
            };
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void SetPlaylistId()
        {
            Playlist playlist = new Playlist()
            {
                Id = 1,
                Contents = new List<Content>() {new Content() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Entrena tu mente"
            };
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlistService.SetPlaylist(playlist);
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void UpdatPlaylist()
        {
            Playlist playlist1 = new Playlist()
            {
                Contents = new List<Content>() {new Content() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Entrena tu mente",
                UrlImage = "",
                Description = "descrption"
            };
            Playlist playlist2 = new Playlist()
            {
                Contents = new List<Content>() {new Content() {Name = "Stand by me"}},
                Categories = new List<Category>() {new Category() {Name = "Musica"}},
                Name = "Entrena tu mente",
                UrlImage = "",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>() {playlist2};
            _playlisMock.Setup(x => x.Update(playlist1, playlist2));
            _playlistService.UpdatePlaylist(playlist1, playlist2);
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void DeletePlaylistById()
        {
            Playlist playlist = new Playlist() {Id = 1};
            List<Playlist> playlists = new List<Playlist>() {playlist};
            _playlisMock.Setup(x => x.Delete(playlist));
            _playlisMock.Setup(x => x.Add(playlist));
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.SetPlaylist(playlist);
            _playlistService.DeletePlaylist(1);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }

        [TestMethod]
        public void DeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Entrena tu mente"};
            List<Playlist> playlists = new List<Playlist>();
            _playlisMock.Setup(x => x.Delete(playlist));
            _playlistService.SetPlaylist(playlist);
            _playlisMock.Setup(x => x.Get()).Returns(playlists);
            _playlistService.DeletePlaylist(playlist.Id);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist))]
        public void NoDeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Para correr"};
            _playlisMock.Setup(x => x.FindById(3)).Returns(playlist);
            _playlisMock.Setup(x => x.Delete(playlist)).Throws(new NotFoundPlaylist());
            _playlistService.DeletePlaylist(3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist))]
        public void NoFindDeletePlaylistTest()
        {
            Playlist playlist = new Playlist() {Id = 1, Name = "Para correr"};
            _playlisMock.Setup(x => x.FindById(3)).Returns(playlist);
            _playlisMock.Setup(x => x.Delete(playlist)).Throws(new KeyNotFoundException());
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
            _playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            Playlist playlist3 = _playlistService.GetPlaylistById(1);
            Assert.AreEqual(playlist, playlist3);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void FindPlaylistByNotExistId()
        {
            _playlisMock.Setup(x => x.FindById(2)).Throws(new NotFoundId());
            _playlistService.GetPlaylistById(2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void NoFindPlaylistById()
        {
            _playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            _playlistService.GetPlaylistById(2);
        }

        [TestMethod]
        public void UpdatePlaylistById()
        {
            Playlist playlist = new Playlist()
            {
                Name = "Yoga", Id = 1,Description = "",Contents = new List<Content>() {new Content() {Id=0,Name = "Stand by me"},new Content() {Id=1,Name = "Stand by me"}},
                UrlImage ="", Categories =new List<Category>() {new Category() {Name = "Musica"}}
            };
            _playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _playlistService.UpdatePlaylistById(1, playlist);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist))]
        public void NoUpdatePlaylisy()
        {
            _playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            _playlistService.UpdatePlaylistById(2, new Playlist());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundPlaylist), "")]
        public void UpdatePlaylistByNotExistId()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1};
            _playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            _playlisMock.Setup(x => x.Update(playlist, playlist));
            _playlistService.UpdatePlaylistById(2, playlist);
        }

        [TestMethod]
        public void UpdatePlaylist()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1};
            _playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _playlistService.UpdatePlaylist(playlist, playlist);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoUpdatePlaylist()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 2};
            _playlisMock.Setup(x => x.FindById(2)).Throws(new KeyNotFoundException());
            _playlisMock.Setup(x => x.Update(playlist, playlist)).Throws(new KeyNotFoundException());
            _playlistService.UpdatePlaylist(playlist, playlist);
        }
        
        [TestMethod]
        public void AssociateContentToPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>()};
            Content content = new Content() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>(){content}};
            _playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _contentMock.Setup(x => x.FindById(1)).Returns(content);
            _contentMock.Setup(a => a.Add(content));
            _playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AssociateContentToPlaylist(1, 1);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void AssociateInvvalidContentToPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>()};
            Content content = new Content() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>(){content}};
            _playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _contentMock.Setup(x => x.FindById(1)).Throws(new KeyNotFoundException());
            _contentMock.Setup(a => a.Add(content));
            _playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AssociateContentToPlaylist(1, 1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void AssociateContentToInvalidPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>()};
            Content content = new Content() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>(){content}};
            _playlisMock.Setup(x => x.FindById(1)).Throws(new KeyNotFoundException());
            _contentMock.Setup(x => x.FindById(1)).Returns(content);
            _contentMock.Setup(a => a.Add(content));
            _playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AssociateContentToPlaylist(1, 1);
        }
        
        [TestMethod]
        public void AddNewContentToPlaylistTest()
        {
            Playlist playlist = new Playlist()
            {
                Name = "Yoga", Id = 1,Contents = new List<Content>(),
                Categories = new List<Category>()
            };
            Content content = new Content() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>(){content}};
            _playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _contentMock.Setup(x => x.FindById(1)).Returns(content);
            _contentMock.Setup(a => a.Add(content)).Returns(content);
            _playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AddNewContentToPlaylist(content, 1);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }
        
        [TestMethod]
        public void AddNewContentDiffCategoriesToPlaylistTest()
        {
            Playlist playlist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>(), 
                Categories = new List<Category>(){new Category(){Name ="Musica"}}};
            Content content = new Content() {Name = "Let it be", Id = 1,Categories = new List<Category>()};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>(){content}};
            _playlisMock.Setup(x => x.FindById(1)).Returns(playlist);
            _contentMock.Setup(a => a.Add(content)).Returns(content);
            _playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AddNewContentToPlaylist(content, 1);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }
       
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void AddNewContentToInvalidPlaylistTest()
        {
            Playlist playlist = new Playlist()
            {
                Name = "Yoga", Id = 1,Contents = new List<Content>(),
                Categories = new List<Category>()
            };
            Content content = new Content() {Name = "Let it be", Id = 1};
            Playlist newPlaylist = new Playlist() {Name = "Yoga", Id = 1,Contents = new List<Content>(){content}};
            _playlisMock.Setup(x => x.FindById(1)).Throws(new KeyNotFoundException());
            _contentMock.Setup(x => x.FindById(1)).Returns(content);
            _contentMock.Setup(a => a.Add(content)).Returns(content);
            _playlisMock.Setup(x => x.Update(playlist,newPlaylist));
            _playlistService.AddNewContentToPlaylist(content, 1);
        }
    }
}