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
            Song song1 = new Song() {Name = "Stand by me"};
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Returns(song1);
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(x => x.Get()).Returns(songs);
            List<Song> songs3 = _songService.GetSongsByName("Stand by me");
            CollectionAssert.AreEqual(songs, songs3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByName()
        {
            Song song1 = new Song() {Name = "Stand by me"};
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Returns(song1);
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(x => x.Get()).Returns(songs);
            _songService.GetSongsByName("LetITBE");
        }
        
        [TestMethod]
        public void FindSongByAuthor()
        {
            Song song1 = new Song() {Name = "Stand by me", AuthorName = "John Lennon"};
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Returns(song1);
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(x => x.Get()).Returns(songs);
            List<Song> songs3 = _songService.GetSongsByAuthor("John Lennon");
            CollectionAssert.AreEqual(songs, songs3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByAuthor()
        {
            Song song1 = new Song() {Name = "Stand by me", AuthorName = "John Lennon"};
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Returns(song1);
            List<Song> songs = new List<Song>() {song1};
            songsMock.Setup(x => x.Get()).Returns(songs);
           _songService.GetSongsByAuthor("Ringo Starr");
        }

        [TestMethod]
        public void FindSongByAuthorAndName()
        {
            Song song1 = new Song() {Name = "Stand by me", AuthorName = "John Lennon"};
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Returns(song1);
            Song song3 = _songService.GetSongByNameAndAuthor("Stand by me","John Lennon");
            Assert.AreEqual(song1, song3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByAuthorAndName()
        {
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Throws(new KeyNotFoundException());
            _songService.GetSongByNameAndAuthor("Stand by me","Ringo Starr");
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongDiffAuthor()
        {
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Throws(new KeyNotFoundException());
            _songService.GetSongByNameAndAuthor("Let it be","John Lennon");
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongDiffName()
        {
            songsMock.Setup(x => x.Find(It.IsAny<Predicate<Song>>())).Throws(new KeyNotFoundException());
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
            List<Song> songs1 = new List<Song> {song};
            songsMock.Setup(x => x.Get()).Returns(songs1);
            List<Song> songs2 = _songService.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisSong), "")]
        public void SetSongs()
        {    
            Song song = new Song()
            {
                Id=4,
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            songsMock.Setup(x => x.FindById(3)).Throws(new AlreadyExistThisSong());
            _songService.AddSong(song);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void SetSongsInvalidName()
        {
            Song song = new Song() {Name = ""};
            List<Song> songs1 = new List<Song> {song};
            songsMock.Setup(x => x.Set(songs1));
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisSong), "")]
        public void SetSongRepeted()
        {    
            Song song = new Song() {Name = "Let it be"};
            List<Song> songs1 = new List<Song> {song};
            songsMock.Setup(x => x.Set(songs1));
            _songService.AddSong(song);
            _songService.AddSong(song);
        }

       
        [TestMethod]
        public void FindSongByCategoryName()
        {
            Category category = new Category() {Name = "Dormir"};
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
            List<Song> songs = new List<Song>() {song1, song1, song1, song1};
            songsMock.Setup(x => x.Set(songs));
            songsMock.Setup(x => x.Get()).Returns(songs);
            List<Song> song3 = _songService.GetSongsByCategoryName("Dormir");
            CollectionAssert.AreEqual(songs, song3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException), "")]
        public void NoFindSongByCategoryName()
        {
            Song song1 = new Song()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me"
            };
            List<Song> songs = new List<Song>() {song1, song1, song1, song1};
            songsMock.Setup(x => x.Set(songs));
            songsMock.Setup(x => x.Get()).Returns(songs);
            _songService.GetSongsByCategoryName("Musica");
        }
        
      [TestMethod]
        public void DeleteSong()
        {
            Song song1 = new Song()
            {
                Id = 1,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Song song2 = new Song()
            {
                Id = 1,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs = new List<Song>(){song1,song2};
            songsMock.Setup(x => x.Delete(song1));
            songsMock.Setup(x => x.Get()).Returns(songs);
            songsMock.Setup(x => x.Set(songs));
            _songService.DeleteSong(song1.Id);
            List<Song> songPostDelete = _songService.GetSongs();
            CollectionAssert.AreEqual(songPostDelete, songs);
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyExistThisSong), "")]
        public void NoSetSong()
        {
            Song song1 = new Song()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            songsMock.Setup(x => x.Add(song1)).Throws(new AlreadyExistThisSong());
            _songService.AddSong(song1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidNameLength), "")]
        public void NoSetSongInvalidName()
        {
            Song song1 = new Song()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            songsMock.Setup(x => x.Add(song1)).Throws(new InvalidNameLength());
            _songService.AddSong(song1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ObjectWasNotDeleted), "")]
        public void NoDeleteSong()
        {
            Song song1 = new Song()
            {
                Id=3,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            songsMock.Setup(x => x.FindById(song1.Id)).Throws(new ObjectWasNotDeleted());
            _songService.DeleteSong(song1.Id);
        }

        [TestMethod]
        public void UpdateSongTest()
        {  
            Song song = new Song()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song> {song};
            songsMock.Setup(x => x.Update(song,song));
            songsMock.Setup(x => x.Get()).Returns(songs1);
            _songService.UpdateSongById(2,song);
            List<Song> songs2 = _songService.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ObjectWasNotUpdated), "")]
        public void NoUpdateSongTest()
        {  
            Song song = new Song()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it be",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            songsMock.Setup(x => x.FindById(7)).Throws(new ObjectWasNotUpdated());
            _songService.UpdateSongById(7,song);
        }
        
        [TestMethod]
        public void GetSongByIDTest()
        {  
            Song song = new Song()
            {
                Id=2,
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song> {song};
            songsMock.Setup(x => x.FindById(2)).Returns(song);
            songsMock.Setup(x => x.Get()).Returns(songs1);
            _songService.GetSongById(2);
            List<Song> songs2 = _songService.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotFoundId), "")]
        public void NoGetSongByIDTest()
        {   
            Song song = new Song()
            {
                Categories = new List<Category>() {new Category() {Name = "Dormir"}},
                Name = "Let it e",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            songsMock.Setup(x => x.FindById(3)).Throws(new NotFoundId());
            _songService.GetSongById(3);
        }
    }
}