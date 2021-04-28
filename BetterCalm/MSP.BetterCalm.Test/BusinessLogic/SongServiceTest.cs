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
    public class SongServiceTest
    {
        private Mock<ManagerSongRepository> repoMock;
        private Mock<IRepository<Song>> songsMock;
        private SongService _songService;
        private ContextDB context = new ContextDB();

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerSongRepository>();
            songsMock = new Mock<IRepository<Song>>();
            repoMock.Object.Songs =  songsMock.Object;
            _songService = new SongService(repoMock.Object);
        }

        [TestMethod]
        public void FindSongByName()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Returns(song1);
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            List<Song> songs3 = _songService.GetSongsByName("Stand by me");
            CollectionAssert.AreEqual(songs, songs3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByName()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Returns(song1);
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            _songService.GetSongsByName("LetITBE");
        }
        
        [TestMethod]
        public void FindSongByAuthor()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Returns(song1);
            
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            List<Song> songs3 = _songService.GetSongsByAuthor("John Lennon");
            CollectionAssert.AreEqual(songs, songs3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByAuthor()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Returns(song1);
            
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
           _songService.GetSongsByAuthor("Ringo Starr");
        }

        [TestMethod]
        public void FindSongByAuthorAndName()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Returns(song1);
            Song song3 = _songService.GetSongByNameAndAuthor("Stand by me","John Lennon");
            Assert.AreEqual(song1, song3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByAuthorAndName()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Throws(new KeyNotFoundException());
            _songService.GetSongByNameAndAuthor("Stand by me","Ringo Starr");
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongDiffAuthor()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Throws(new KeyNotFoundException());
            _songService.GetSongByNameAndAuthor("Let it be","John Lennon");
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongDiffName()
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
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Throws(new KeyNotFoundException());
            _songService.GetSongByNameAndAuthor("Stand by me","Ringo Starr");
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
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs1);
            List<Song> songs2 = _songService.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisSong), "")]
        public void SetSongs()
        {     
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Id=4,
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.FindById(3)
            ).Throws(new ValueNotFound());
            _songService.SetSong(song);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetSongsInvalidName()
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
                Name = "",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.Set(songs1)
            );
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoUpdateSong()
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
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song>
            {
                song
            };
            List<Song> songs1 = new List<Song> {song};
            songsMock.Setup(x => x.Update(song,song2)).Throws(new KeyNotFoundException());
            _songService.UpdateSong(song,song2);
        }
[TestMethod]
        [ExpectedException(typeof(AlreadyExistThisSong), "")]
        public void SetSongRepeted()
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
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.Set(songs1)
            );
            _songService.SetSong(song);
            _songService.SetSong(song);
        }

       
        [TestMethod]
        public void FindSongByCategoryName()
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
            List<Song> songs = new List<Song>()
            {
                song1,
                song1,
                song1,
                song1
            };
            songsMock.Setup(
                x => x.Set(songs)
            );
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            List<Song> song3 = _songService.GetSongsByCategoryName("Dormir");
            CollectionAssert.AreEqual(songs, song3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByCategoryName()
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
            List<Song> songs = new List<Song>()
            {
                song1,
                song1,
                song1,
                song1
            };
            songsMock.Setup(
                x => x.Set(songs)
            );
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            _songService.GetSongsByCategoryName("Musica");
        }
        
      [TestMethod]
        public void DeleteSong()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Id = 1,
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
                Id = 1,
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs = new List<Song>(){song1,song2};
            songsMock.Setup(
                x => x.Delete(song1));
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            songsMock.Setup(
                x => x.Set(songs)
            );
            _songService.DeleteSong(song1.Id);
            List<Song> songPostDelete = _songService.GetSongs();
            CollectionAssert.AreEqual(songPostDelete, songs);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoDeleteSongByAuthorAndName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song1 = new Song()
            {
                Id=3,
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
            List<Song> songs = new List<Song>(){song2};
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Throws(new KeyNotFoundException());
            _songService.DeleteSongByNameAndAuthor("Stand by me","John Lennon");
        }
        
        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisSong), "")]
        public void NoSetSong()
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
            List<Song> songs = new List<Song>(){song1};
            songsMock.Setup(
                x => x.Add(song1)
            ).Throws(new AlreadyExistThisSong());
            _songService.SetSong(song1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void NoSetSongInvalidName()
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
                Name = "",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs = new List<Song>(){song1};
            songsMock.Setup(
                x => x.Add(song1)
            ).Throws(new InvalidNameLength());
            _songService.SetSong(song1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoDeleteSong()
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
                Name = "Let it be ",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Song song2 = new Song()
            {
                Categories = new List<Category>()
                {
                    category
                },
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            songsMock.Setup(x => x.Delete(song1)).Throws(new ValueNotFound());
            _songService.DeleteSong(song1);
        }
        
        [TestMethod]
        public void DeleteSongTest()
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
                Name = "Let it be ",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs = new List<Song>(){song1};
            songsMock.Setup(
                x => x.Delete(song1)
            ).Throws(new ValueNotFound());
            _songService.DeleteSongs(songs);
            CollectionAssert.AreEqual(songs, songs);
        }
        
        [TestMethod]
        public void UpdateSongTest()
        {     
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Id=2,
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
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.Update(song,song)
            );
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs1);
            _songService.UpdateSongById(2,song);
            List<Song> songs2 = _songService.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void NoUpdateSongTest()
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
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.FindById(7)
            ).Throws(new ValueNotFound());
            songsMock.Setup(
                x => x.Update(song,song)
            ).Throws(new ValueNotFound());
            _songService.UpdateSongById(7,song);
        }
        
        [TestMethod]
        public void GetSongByIDTest()
        {     
            Category category = new Category()
            {
                Name = "Dormir"
            };
            Song song = new Song()
            {
                Id=2,
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
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.FindById(2)
            ).Returns(song);
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs1);
            _songService.GetSongById(2);
            List<Song> songs2 = _songService.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void NoGetSongByIDTest()
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
                Name = "Let it e",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song>
            {
                song
            };
            songsMock.Setup(
                x => x.FindById(3)
            ).Throws(new ValueNotFound());
            _songService.GetSongById(3);
        }
    }
}