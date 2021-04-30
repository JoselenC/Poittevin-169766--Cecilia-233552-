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
        public  DataBaseRepository<Playlist, PlaylistDto> Playlists;
        private ContextDB context;
        public  Playlist playlistTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            context = new ContextDB(this.options);
            context.Categories.Add(new CategoryDto() {Name = "Dormir"});
            PlaylistMapper songMapper = new PlaylistMapper();
            Playlists = new DataBaseRepository<Playlist, PlaylistDto>(songMapper, context.Playlists, context);
        }

     
        [TestCleanup]
        public void TestCleanUp()
        {
            context.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void UpdateTest()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                PlaylistSongsDto= new List<PlaylistSongDto>(),
                PlaylistCategoriesDto = new List<PlaylistCategoryDto>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.UpdateDtoObject(playlistTestDto, playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
        
        }
        
        [TestMethod]
        public void UpdateTestDiffCategorySong()
        {
            Playlist NewPlaylistTest = new Playlist()
            {
                Categories = new List<Category>()
                {
                    new Category(){Name = "Dormir"}
                },
                Songs= new List<Song>(){ 
                    new Song()
                    {
                        Name = "Let it be",
                        AuthorName = "John Lennon",
                        Duration = 12,
                        UrlAudio = "",
                        UrlImage = ""
                    }
                },
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto OldPlaylistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                PlaylistCategoriesDto= new List<PlaylistCategoryDto>()
                {
                    new PlaylistCategoryDto()
                    {
                        CategoryDto = new CategoryDto(){Name = "Dormir",CategoryDtoID = 8},
                        CategoryID = 1
                    }
                },
                PlaylistSongsDto = new List<PlaylistSongDto>()
                {
                  new PlaylistSongDto()
                  {
                      SongDto= new SongDto(){Name = "let it be", AuthorName = "Jhon Lennon"},
                      SongID = 1,
                      PlaylistDto = new PlaylistDto(){Name = "Musicas", Description = "Lo mas escuchado"},
                      PlaylistID = 1,
                  } 
                }
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            context.Playlists.Add(OldPlaylistTestDto);
            playlistMapper.UpdateDtoObject(OldPlaylistTestDto, NewPlaylistTest, context);
            PlaylistDto expectedPlaylist = context.Playlists.Find(1);
            Assert.AreEqual(expectedPlaylist,OldPlaylistTestDto);
        }

        [TestMethod]
        public void UpdateTestNull()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                PlaylistSongsDto= null,
                PlaylistCategoriesDto = null,
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.UpdateDtoObject(playlistTestDto, playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
        }
        
         [TestMethod]
        public void DomainToDtoTest()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                PlaylistSongsDto= new List<PlaylistSongDto>(),
                PlaylistCategoriesDto = new List<PlaylistCategoryDto>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.DomainToDto(playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidCategory), "")]
        public void DomainToDtoTestDiffCategoryySong()
        {
            Playlist playlistTest = new Playlist()
            {
                Categories = new List<Category>()
                {
                    new Category(){Name = "aaaaa"}
                },
                Songs= new List<Song>(){ new Song(){Name = "Let it be"}},
                Name = "Entrenamiento",
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            playlistMapper.DomainToDto(playlistTest, context);
        }

        [TestMethod]
        public void DomainToDtoTestNull()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                PlaylistSongsDto= null,
                PlaylistCategoriesDto = null,
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.DomainToDto(playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
        }

        [TestMethod]
        public void DtoToDomainTest()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs = new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                PlaylistSongsDto = new List<PlaylistSongDto>(),
                PlaylistCategoriesDto = new List<PlaylistCategoryDto>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            context.Playlists.Add(playlistTestDto);
            Playlist playlists = playlistMapper.DtoToDomain(playlistTestDto, context);
            Assert.AreEqual(playlists, playlistTest);
        }

       [TestMethod]
        public void DtoToDomainTestNull()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(),
                Categories = new List<Category>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                PlaylistSongsDto= null,
                PlaylistCategoriesDto = null,
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            context.Playlists.Add(playlistTestDto);
            Playlist playlists= playlistMapper.DtoToDomain(playlistTestDto, context);
            Assert.AreEqual(playlists,playlistTest);
        }
    }
}