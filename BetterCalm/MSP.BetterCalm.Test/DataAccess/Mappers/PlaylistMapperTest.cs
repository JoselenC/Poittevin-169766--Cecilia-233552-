using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class PlaylistMapperTest
    {
        private DbContextOptions<ContextDB> options;
        public  DataBaseRepository<Playlist, PlaylistDto> Playlists;
        public  Playlist playlistTest;

        [TestInitialize]
        public  void TestFixtureSetup()
        {
            options = new DbContextOptionsBuilder<ContextDB>().UseInMemoryDatabase(databaseName: "BetterCalmDB").Options;
            ContextDB context = new ContextDB(this.options);
            PlaylistMapper songMapper = new PlaylistMapper();
            Playlists = new DataBaseRepository<Playlist, PlaylistDto>(songMapper, context.Playlists, context);
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
                Songs= new List<SongDto>(),
                Categories = new List<CategoryDto>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.UpdateDtoObject(playlistTestDto, playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
        }
        
        [TestMethod]
        public void UpdateTestDiffCategoryySong()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(){ new Song()
                {
                    Categories = new List<Category>()
                    {
                        new Category(){Name = "Dormir"},
                        new Category(){Name = "Musica"}
                    },
                    Name = "Let it be",
                    AuthorName = "John Lennon",
                    Duration = 12,
                    UrlAudio = "",
                    UrlImage = ""
                }},
                Categories = new List<Category>()
                {
                    new Category(){Name = "Dormir"},
                    new Category(){Name = "Yoga"}
                },
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                Songs= new List<SongDto>()
                {
                    new SongDto()
                    {
                        SongDtoID = 1,
                        Categories = new List<CategoryDto>()
                        {
                            new CategoryDto(){Name = "Musica",CategoryDtoID = 8},
                            new CategoryDto(){Name = "Yoga",CategoryDtoID = 9}
                        },
                        Name = "Stand by me",
                        AuthorName = "The beatles",
                        Duration = 12,
                        UrlAudio = "",
                        UrlImage = ""
                    }
                },
                Categories = new List<CategoryDto>()
                {
                    new CategoryDto(){Name = "Musica",CategoryDtoID = 10},
                    new CategoryDto(){Name = "Yoga",CategoryDtoID = 11}
                },
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.UpdateDtoObject(playlistTestDto, playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
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
                Songs= null,
                Categories = null,
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
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
                Songs= new List<SongDto>(),
                Categories = new List<CategoryDto>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.DomainToDto(playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
        }
        
        [TestMethod]
        public void DomainToDtoTestDiffCategoryySong()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs= new List<Song>(){ new Song()
                {
                    Categories = new List<Category>()
                    {
                        new Category(){Name = "Dormir"},
                        new Category(){Name = "Musica"}
                    },
                    Name = "Let it be",
                    AuthorName = "John Lennon",
                    Duration = 12,
                    UrlAudio = "",
                    UrlImage = ""
                }},
                Categories = new List<Category>()
                {
                    new Category(){Name = "Dormir"},
                    new Category(){Name = "Yoga"}
                },
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                Songs= new List<SongDto>()
                {
                    new SongDto()
                    {
                        SongDtoID = 1,
                        Categories = new List<CategoryDto>()
                        {
                            new CategoryDto(){Name = "Musica",CategoryDtoID = 8},
                            new CategoryDto(){Name = "Yoga",CategoryDtoID = 9}
                        },
                        Name = "Stand by me",
                        AuthorName = "The beatles",
                        Duration = 12,
                        UrlAudio = "",
                        UrlImage = ""
                    }
                },
                Categories = new List<CategoryDto>()
                {
                    new CategoryDto(){Name = "Musica",CategoryDtoID = 10},
                    new CategoryDto(){Name = "Yoga",CategoryDtoID = 11}
                },
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.DomainToDto(playlistTest, context);
            Assert.AreEqual(context.Playlists.Find(1),playlistTestDto);
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
                Songs= null,
                Categories = null,
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
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
                Songs = new List<SongDto>(),
                Categories = new List<CategoryDto>(),
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
            context.Playlists.Add(playlistTestDto);
            Playlist playlists = playlistMapper.DtoToDomain(playlistTestDto, context);
            Assert.AreEqual(playlists, playlistTest);
        
    }

        [TestMethod]
        public void DtoToDomanTestDiffCategoryySong()
        {
            Playlist playlistTest = new Playlist()
            {
                Songs = new List<Song>()
                {
                    new Song()
                    {
                        Categories = new List<Category>()
                        {
                            new Category() {Name = "Dormir"},
                            new Category() {Name = "Musica"}
                        },
                        Name = "Let it be",
                        AuthorName = "John Lennon",
                        Duration = 12,
                        UrlAudio = "",
                        UrlImage = ""
                    }
                },
                Categories = new List<Category>()
                {
                    new Category() {Name = "Dormir"},
                    new Category() {Name = "Yoga"}
                },
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistDto playlistTestDto = new PlaylistDto()
            {
                PlaylistDtoID = 1,
                Songs = new List<SongDto>()
                {
                    new SongDto()
                    {
                        SongDtoID = 1,
                        Categories = new List<CategoryDto>()
                        {
                            new CategoryDto() {Name = "Musica", CategoryDtoID = 8},
                            new CategoryDto() {Name = "Yoga", CategoryDtoID = 9}
                        },
                        Name = "Stand by me",
                        AuthorName = "The beatles",
                        Duration = 12,
                        UrlAudio = "",
                        UrlImage = ""
                    }
                },
                Categories = new List<CategoryDto>()
                {
                    new CategoryDto() {Name = "Musica", CategoryDtoID = 10},
                    new CategoryDto() {Name = "Yoga", CategoryDtoID = 11}
                },
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
            context.Playlists.Add(playlistTestDto);
            playlistMapper.DomainToDto(playlistTest, context);
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
                Songs= null,
                Categories = null,
                Name = "Entrenamiento",
                Description = "description",
                UrlImage = ""
            };
            PlaylistMapper playlistMapper = new PlaylistMapper();
            ContextDB context = new ContextDB();
            context.Playlists.Add(playlistTestDto);
            Playlist playlists= playlistMapper.DtoToDomain(playlistTestDto, context);
            Assert.AreEqual(playlists,playlistTest);
        }
    }
}