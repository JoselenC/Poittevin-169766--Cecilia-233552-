using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistMapperTest
    {
        private DbContextOptions<ContextDB> options;
        private ContextDB context;
        private DataBaseRepository<Playlist, PlaylistDto> RepoPlaylists;
        private Playlist PlaylistTest;
        private Category category1;
        private Category category2;
        private Audio AudioTest;
        private Audio AudioTest2;

        [TestInitialize]
        public void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB")
                .Options;
            context = new ContextDB(options);
            RepoPlaylists = new DataBaseRepository<Playlist, PlaylistDto>(new PlaylistMapper(), context.Playlists, context);
            DataBaseRepository<Category, CategoryDto> categRepo = new DataBaseRepository<Category, CategoryDto>(
                new CategoryMapper(), context.Categories,
                context);
            DataBaseRepository<Audio, AudioDto> audioRepo = new DataBaseRepository<Audio, AudioDto>(new AudioMapper(), context.Audios,
                context);
            category1 = new Category() {Name = "Musica",Id=1};
            categRepo.Add(category1);
            category2 = new Category() {Name = "Dormir",Id=2};
            categRepo.Add(category2);
            AudioTest = new Audio() {
                Id=1,
                Name = "Stand by me",
                AuthorName = "John Lennon",
                Duration = 120,
                UrlAudio = "",
                UrlImage = "",
                Categories = new List<Category>(){category1}
            };
            AudioTest2 = new Audio() {
                Id=2,
                Name = "Help",
                AuthorName = "The beatles",
                Duration = 120,
                UrlAudio = "",
                UrlImage = "",
                Categories = new List<Category>(){category2}
            };
            audioRepo.Add(AudioTest);
            audioRepo.Add(AudioTest2);
            PlaylistTest = new Playlist()
            {
                Id=1,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){AudioTest},
                Categories = new List<Category>() {category1}
            };
            RepoPlaylists.Add(PlaylistTest);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void DomainToDtoTest()
        {
            RepoPlaylists.Add(PlaylistTest);
            Playlist actualPlaylist = RepoPlaylists.Find(x => x.Name == "Playlist");
            Assert.AreEqual(PlaylistTest, actualPlaylist);
        }
        
        [TestMethod]
        public void DomainToDtoNewAudioTest()
        {
            Audio audio = new Audio() {
                Name = "Let it be",
                AuthorName = "The beatles",
                Duration = 120,
                UrlAudio = "",
                UrlImage = ""
            };
            Playlist playlist = new Playlist()
            {
                Id=1,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){audio},
                Categories = new List<Category>() {category1}
            };
            RepoPlaylists.Add(playlist);
            Playlist actualPlaylist = RepoPlaylists.Find(x => x.Name == "Playlist");
            Assert.AreEqual(PlaylistTest, actualPlaylist);
        }

        [TestMethod]
        public void DomainToDtoAudioEmptyAtributesTest()
        {
            Audio audio = new Audio() {
                Name = "Audio",
                Categories = new List<Category>() {category2}
            };
            Playlist playlist = new Playlist()
            {
                Id=1,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){audio},
                Categories = new List<Category>() {category1}
            };
            RepoPlaylists.Add(playlist);
            Playlist actualPlaylist = RepoPlaylists.Find(x => x.Name == "Playlist");
            Assert.AreEqual(PlaylistTest, actualPlaylist);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidCategory))]
        public void DomainToDtoWrongcategoryTest()
        {
            Playlist PlaylistTest = new Playlist()
            {
                Id = 0,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){AudioTest2},
                Categories = new List<Category>() {category1}
            };
            List<Category> Categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Category Category"
                }
            };
            PlaylistTest.Categories = Categories;
            RepoPlaylists.Add(PlaylistTest);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Playlist actualPlaylist = RepoPlaylists.Find(x => x.Name == "Playlist");
            Assert.AreEqual(this.PlaylistTest, actualPlaylist);
        }

        [TestMethod]
        public void DtoToDomainWitPlaylistTest()
        {
            Playlist actualPlaylist = RepoPlaylists.Find(x => x.Name == "Playlist");
            Assert.AreEqual(this.PlaylistTest, actualPlaylist);
        }

        [TestMethod]
        public void DtoToDomainWitPlaylistest()
        {
            Playlist actualPlaylist = RepoPlaylists.Find(x => x.Name == "Playlist");
            Assert.AreEqual(this.PlaylistTest, actualPlaylist);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Playlist actualPlaylist =new Playlist()
            {
                Id=1,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){AudioTest2},
                Categories = new List<Category>() {category2}
            };
            Playlist updatedPlaylist = RepoPlaylists.Update(PlaylistTest, actualPlaylist);
            Assert.AreEqual(actualPlaylist, updatedPlaylist);
        }

        [TestMethod]
        public void UpdatePlaylistWithCateogryTest()
        {
            Playlist Playlist = new Playlist()
            {
                Id = 2,
                Name = "Playlist",
                Audios = new List<Audio>(),
                Categories = new List<Category>()
            };
            RepoPlaylists.Add(Playlist);
            Playlist actualPlaylist = new Playlist()
            {
                Id = 2,
                Name = "ToUpdate",
                Audios = new List<Audio>(){AudioTest2},
                Categories = new List<Category>() {category2, category1}
            };
            Playlist updatedPlaylist = RepoPlaylists.Update(Playlist, actualPlaylist);
            Assert.AreEqual(actualPlaylist, updatedPlaylist);
        }

        [TestMethod]
        public void UpdatePlaylistTest()
        {
            Playlist actualPlaylist = new Playlist()
            {
                Id = 1,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){AudioTest2},
                Categories = new List<Category>() {category2}
            };
            Playlist updatedPlaylist = RepoPlaylists.Update(PlaylistTest, actualPlaylist);
            Assert.AreEqual(actualPlaylist, updatedPlaylist);
        }
        
        [TestMethod]
        public void GetByIDTest()
        {
            Playlist actualPlaylist = new Playlist()
            {
                Id = 1,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){AudioTest},
                Categories = new List<Category>() {category1}
            };
            Playlist playlist = RepoPlaylists.FindById(1);
            Assert.AreEqual(actualPlaylist, playlist);
        }
        
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void NoGetByIDTest()
        {
            Playlist actualPlaylist = new Playlist()
            {
                Id = 1,
                Name = "Playlist",
                Description = "description",
                UrlImage = "",
                Audios = new List<Audio>(){AudioTest},
                Categories = new List<Category>() {category1}
            };
            Playlist playlist = RepoPlaylists.FindById(10);
            Assert.AreEqual(actualPlaylist, playlist);
        }
    }
}