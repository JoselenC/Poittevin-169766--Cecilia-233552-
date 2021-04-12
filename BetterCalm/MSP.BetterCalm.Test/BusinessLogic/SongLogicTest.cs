﻿using System;
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
    public class SongLogicTest
    {
        private Mock<ManagerSongRepository> repoMock;
        private Mock<IRepository<Song>> songsMock;
        private SongLogic songLogic;
        private ContextDB context = new ContextDB();

        [TestInitialize]
        public void TestFixtureSetup()
        {
            repoMock = new Mock<ManagerSongRepository>();
            songsMock = new Mock<IRepository<Song>>();
            repoMock.Object.Songs =  songsMock.Object;
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
            songLogic.GetSongsByName("LetITBE");
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
           songLogic.GetSongsByAuthor("Ringo Starr");
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
            ).Throws(new ValueNotFound());
            songLogic.GetSongByNameAndAuthor("Stand by me","Ringo Starr");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
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
            ).Throws(new ValueNotFound());
            songLogic.GetSongByNameAndAuthor("Let it be","John Lennon");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
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
        [ExpectedException(typeof(ValueNotFound), "")]
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
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            Song song2 = new Song()
            {
                Categories = new List<Category>(){category},
                Name = "LetItBe",
                AuthorName = "The beatles",
                Duration = 12,
                UrlAudio = "",
                UrlImage = ""
            };
            List<Song> songs1 = new List<Song> {song};
            songsMock.Setup(x => x.Update(song,song2)).Throws(new ValueNotFound());
            songLogic.UpdateSong(song,song2);
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
            List<Song> song3 = songLogic.GetSongsByCategoryName("Dormir");
            CollectionAssert.AreEqual(songs, song3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
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
            songLogic.GetSongsByCategoryName("Musica");
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
            songLogic.DeleteSongByNameAndAuthor("Stand by me","John Lennon");
            List<Song> songPostDelete = songLogic.GetSongs();
            CollectionAssert.AreEqual(songPostDelete, songs);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
        public void NoDeleteSongByAuthorAndName()
        {
            Category category = new Category()
            {
                Name = "Dormir"
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
            List<Song> songs = new List<Song>(){song2};
            songsMock.Setup(
                x => x.Find(It.IsAny<Predicate<Song>>())
            ).Throws(new ValueNotFound());
            songLogic.DeleteSongByNameAndAuthor("Stand by me","John Lennon");
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
            songLogic.DeleteSong(song1);
            List<Song> songPostDelete = songLogic.GetSongs();
            CollectionAssert.AreEqual(songPostDelete, songs);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ValueNotFound), "")]
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
            songsMock.Setup(x => x.Delete(song1)).Throws(new ValueNotFound());
            songLogic.DeleteSong(song1);
        }
        
        [TestMethod]
        public void SetSong()
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
            List<Song> songs = new List<Song>();
            songsMock.Setup(
                x => x.Get()
            ).Returns(songs);
            songLogic.SetSong(song1);
            CollectionAssert.AreEqual(songs, songLogic.GetSongs());
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
                x => x.Get()
            ).Returns(songs);
            songLogic.SetSong(song1);
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
                x => x.Get()
            ).Returns(songs);
            songLogic.SetSong(song1);
            CollectionAssert.AreEqual(songs, songLogic.GetSongs());
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
            List<Song> songs2 = new List<Song>();
            songsMock.Setup(
                x => x.Delete(song1)
            );
            songLogic.DeleteSongs(songs);
            CollectionAssert.AreEqual(songs, songs);
        }
    }
}