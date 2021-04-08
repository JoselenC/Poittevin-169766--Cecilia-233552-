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
    public class SongLogicTest
    {
        private Mock<ManagerSongRepository> repoMock;
        private Mock<IRepository<Song>> songsMock;
        private SongLogic songLogic;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerSongRepository>();
            songsMock = new Mock<IRepository<Song>>();
            repoMock.Object.Songs = songsMock.Object;
            songLogic = new SongLogic(repoMock.Object);
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
            List<Song> songs3 = songLogic.GetSongsByName("Stand by me");
            CollectionAssert.AreEqual(songs, songs3);
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
            List<Song> songs3 = songLogic.GetSongsByAuthor("John Lennon");
            CollectionAssert.AreEqual(songs, songs3);
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
            Song song3 = songLogic.GetSongByNameAndAuthor("Stand by me","John Lennon");
            Assert.AreEqual(song1, song3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NoFindSongByNameAndAuthor), "")]
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
            songLogic.SetSong(song1);
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Throws(new ValueNotFound());
            songLogic.GetSongByNameAndAuthor("Let it be","John Lennon");
        }
        
        [TestMethod]
        [ExpectedException(typeof(NoFindSongByNameAndAuthor), "")]
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
            ).Throws(new ValueNotFound());
            songLogic.GetSongByNameAndAuthor("Stand by me","Ringo Starr");
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
            List<Song> songs2 = songLogic.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }

        [TestMethod]
        public void SetSongs()
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
                x => x.Set(songs1)
            );
            songLogic.SetSong(song);
            
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs1);
            List<Song> songs2 = songLogic.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
        }

        [TestMethod]
        public void UpdateSong()
        {     Category category = new Category()
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
                Categories = new List<Category>(){category},
                Name = "Stand by me",
                AuthorName = "The beatles",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song>
            {
                song,
                song2
            };
            songsMock.Setup(
                x => x.Update(song,song2)
            );
            songLogic.UpdateSong(song,song2);
            
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs1);
            List<Song> songs2 = songLogic.GetSongs();
            CollectionAssert.AreEqual(songs1, songs2);
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
            songLogic.SetSong(song1);
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            List<Song> song3 = songLogic.GetSongsByCategoryName("Dormir");
            CollectionAssert.AreEqual(songs, song3);
        }
        
        
        [TestMethod]
        public void DeleteSongByAuthorAndName()
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
            List<Song> songs = new List<Song>(){song1,song2};
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Returns(song1);
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            songsMock.Setup(
                x => x.Set(songs)
            );
            songLogic.SetSong(song1);
            songLogic.SetSong(song2);
            songLogic.DeleteSongByNameAndAuthor("Stand by me","John Lennon");
            List<Song> songPostDelete = songLogic.GetSongs();
            CollectionAssert.AreEqual(songPostDelete, songs);
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
            songLogic.SetSong(song1);
            songLogic.SetSong(song2);
            songLogic.DeleteSong(song1);
            List<Song> songPostDelete = songLogic.GetSongs();
            CollectionAssert.AreEqual(songPostDelete, songs);
        }
    }
}