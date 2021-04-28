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
        private Mock<ManagerSongRepository> repoSongMock;
        private Mock<IRepository<Playlist>> playlisMock;
        private Mock<IRepository<Song>> songMock;
        private PlaylistService _playlistService;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoSongMock=new Mock<ManagerSongRepository>();
            repoMock = new Mock<ManagerPlaylistRepository>();
            playlisMock = new Mock<IRepository<Playlist>>();
            songMock = new Mock<IRepository<Song>>();
            repoMock.Object.Playlists = playlisMock.Object;
            repoSongMock.Object.Songs = songMock.Object;
            _playlistService = new PlaylistService(repoMock.Object, repoSongMock.Object);
        }

        [TestMethod]
        public void FindPlaylistByName()
        {
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>()
            {
                playlist
            };
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            playlisMock.Setup(
                x => x.Find(It.IsAny<Predicate<Playlist>>())
            ).Returns(playlist);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByName("Entrena tu mente");
            CollectionAssert.AreEqual(playlist2, playlists);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindPlaylistByName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>()
                {
                    song1
                },
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>()
            {
                playlist
            };
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            playlisMock.Setup(
                x => x.Find(It.IsAny<Predicate<Playlist>>())
            ).Returns(playlist);
           _playlistService.GetPlaylistByName("Para correr");
        }
      
         [TestMethod]
        public void FindPlaylistByCategoryName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>()
            {
                playlist
            };
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            List<Playlist> playlist2 = _playlistService.GetPlaylistByCategoryName("Dormir");
            CollectionAssert.AreEqual(playlists, playlist2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindPlaylistByCategoryName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>()
            {
                playlist
            };
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            _playlistService.GetPlaylistByCategoryName("Para correr");
        }
        
        [TestMethod]
        public void FindPlaylistBySongName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>()
            {
                playlist
            };
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            List<Playlist> playlist2 = _playlistService.GetPlaylistBySongName( "Stand by me");
            CollectionAssert.AreEqual(playlists, playlist2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindPlaylistBySongName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>()
            {
                playlist
            };
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            _playlistService.GetPlaylistBySongName("Para correr");
        }
        
        [TestMethod]
        public void GetSongs()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist};
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }

        [TestMethod]
        public void SetPlaylist()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist};
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist);

            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }
        
        [TestMethod]
        public void SetPlaylistId()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Id=1,
                Songs = new List<Song>() {song},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist};
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist);

            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }
        
        [TestMethod]
        public void UpdatPlaylist()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Song song2 = new Song()
            {
                Categories = new List<Category>() {category},
                Name = "Stand by me",
                AuthorName = "The beatles",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist1 = new Playlist()
            {
                Songs = new List<Song>() {song},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            Playlist playlist2 = new Playlist()
            {
                Songs = new List<Song>() {song2},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist2};
            playlisMock.Setup(
                x => x.Update(playlist1, playlist2)
            );
            _playlistService.UpdatePlaylist(playlist1, playlist2);

            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            List<Playlist> playlists2 = _playlistService.GetPlaylist();
            CollectionAssert.AreEqual(playlists, playlists2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoDeletePlaylistByName()
        {
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
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
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Id=1,
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist};
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
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Id = 1,
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>();
            playlisMock.Setup(
                x => x.Delete(playlist)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            _playlistService.DeletePlaylist(playlist.Id);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoDeletePlaylistTest()
        {
            // TODO: avoid to create all objects just for a error test
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Id = 1,
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Para correr",
                UrlImage = "urlImage",
                Description = "descrption"
            };

            playlisMock.Setup(x => x.FindById(3)).Returns(playlist);
            playlisMock.Setup(x => x.Delete(playlist)).Throws(new KeyNotFoundException());
            _playlistService.DeletePlaylist(3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void AddPlayListInvalidEmptyName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song},
                Categories = new List<Category>() {category},
                Name = "",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist};
            playlisMock.Setup(
                x => x.Set(playlists)
            ).Throws(new InvalidNameLength());
            _playlistService.AddPlaylist(playlist);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDescriptionLength), "")]
        public void AddPlayListInvalidDescriptionLength()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song},
                Categories = new List<Category>() {category},
                Name = "Entrenmaineto",
                UrlImage = "urlImage",
                Description = "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrption" +
                              "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiond"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist};
            playlisMock.Setup(
                x => x.Set(playlists)
            ).Throws(new InvalidDescriptionLength());
            _playlistService.AddPlaylist(playlist);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidDescriptionLength), "")]
        public void AddPlayList()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Songs = new List<Song>() {song},
                Categories = new List<Category>() {category},
                Name = "Entrenmaineto",
                UrlImage = "urlImage",
                Description = "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrption" +
                              "descrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiondescrptiond"
            };
            List<Playlist> playlists = new List<Playlist>(){playlist};
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }
        
        [TestMethod]
        public void FindPlaylistById()
        {
            Playlist playlist = new Playlist() { Name = "Yoga", Id = 1};
            playlisMock.Setup(
                x => x.FindById(1)
            ).Returns(playlist);
            Playlist playlist3 = _playlistService.GetPlaylistById(1);
            Assert.AreEqual(playlist, playlist3);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void FindPlaylistByNotExistId()
        {
            playlisMock.Setup(
                x => x.FindById(2)
            ).Throws( new KeyNotFoundException());
            _playlistService.GetPlaylistById(2);
        }
      
        [TestMethod]
        public void UpdatePlaylistById()
        {
            Playlist playlist = new Playlist() { Name = "Yoga", Id = 1};
            playlisMock.Setup(
                x => x.FindById(1)
            ).Returns(playlist);
            _playlistService.UpdatePlaylistById(1,playlist);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void UpdatePlaylistByNotExistId()
        {
            Playlist playlist = new Playlist() { Name = "Yoga", Id = 1};
            playlisMock.Setup(
                x => x.FindById(2)
            ).Throws( new KeyNotFoundException());
            playlisMock.Setup(x => x.Update(playlist, playlist)).Throws(new KeyNotFoundException());
            _playlistService.UpdatePlaylistById(2,playlist);
        }
        
        [TestMethod]
        public void UpdatePlaylist()
        {
            Playlist playlist = new Playlist() { Name = "Yoga", Id = 1};
            playlisMock.Setup(
                x => x.FindById(1)
            ).Returns(playlist);
            _playlistService.UpdatePlaylist(playlist,playlist);
            Assert.AreEqual(_playlistService.GetPlaylist(), _playlistService.GetPlaylist());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoUpdatePlaylist()
        {
            Playlist playlist = new Playlist() { Name = "Yoga", Id = 2};
            playlisMock.Setup(
                x => x.FindById(2)
            ).Throws( new KeyNotFoundException());
            playlisMock.Setup(x => x.Update(playlist, playlist)).Throws(new KeyNotFoundException());
            _playlistService.UpdatePlaylist(playlist,playlist);
        }
        
        
        
    }
}