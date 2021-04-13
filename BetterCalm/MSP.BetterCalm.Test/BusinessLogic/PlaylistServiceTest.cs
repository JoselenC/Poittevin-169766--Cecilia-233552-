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
        private Mock<IRepository<Playlist>> playlisMock;
        private PlaylistService _playlistService;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerPlaylistRepository>();
            playlisMock = new Mock<IRepository<Playlist>>();
            repoMock.Object.Playlists = playlisMock.Object;
            _playlistService = new PlaylistService(repoMock.Object);
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
            playlisMock.Setup(x => x.Find(It.IsAny<Predicate<Playlist>>())).Throws(new ValueNotFound());
            playlisMock.Setup(x => x.Delete(playlist)).Throws(new ValueNotFound());
            _playlistService.DeletePlaylistByName("Para correr");
        }

        [TestMethod]
        public void DeletePlaylistByName()
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
            List<Playlist> playlists = new List<Playlist>();
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            _playlistService.DeletePlaylistByName("para correr");
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
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Entrena tu mente",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>();
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            _playlistService.DeletePlaylist(playlist);
            CollectionAssert.AreEqual(playlists, _playlistService.GetPlaylist());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void NoDeletePlaylistTest()
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
            Playlist playlist2 = new Playlist()
            {
                Songs = new List<Song>() {song1},
                Categories = new List<Category>() {category},
                Name = "Para correr",
                UrlImage = "urlImage",
                Description = "descrption"
            };
            List<Playlist> playlists = new List<Playlist>();
            playlisMock.Setup(
                x => x.Set(playlists)
            );
            _playlistService.AddPlaylist(playlist)
                ;
            playlisMock.Setup(
                x => x.Get()
            ).Returns(playlists);
            playlisMock.Setup(x => x.Delete(playlist2)).Throws(new ValueNotFound());
            _playlistService.DeletePlaylist(playlist2);
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
      
    }
}