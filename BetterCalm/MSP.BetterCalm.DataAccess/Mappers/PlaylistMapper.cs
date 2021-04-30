using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistMapper:IMapper<Playlist,PlaylistDto>
    {
        
        private List<CategoryDto> createCategories(List<Category> categories, ContextDB context)
        {
              
            List<CategoryDto> CategoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> CategoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoryDto= CategoriesSet.FirstOrDefault(x => x.CategoryDtoID == category.Id || x.Name==category.Name);
                    if (categoryDto == null)
                    {
                        throw new InvalidCategory();
                    }
                    CategoriesDto.Add(categoryDto);
                }
            }
            return CategoriesDto;
        }
        
        private List<SongDto> createSongs(List<Song> songs,  List<Category> categories,ContextDB context)
        {
              
            List<SongDto> songsDto = new List<SongDto>();
            DbSet<SongDto> songsSet = context.Set<SongDto>();
            if (!(songs is null))
            {
                foreach (Song song in songs)
                {
                    SongDto songDto= songsSet.FirstOrDefault(x => x.SongDtoID == song.Id || (x.Name==song.Name && x.AuthorName==song.AuthorName ));
                    if (songDto == null)
                    {
                        List<SongCategoryDto> songCategoryDtos = new List<SongCategoryDto>();
                       
                        songDto = new SongDto(){
                            AuthorName = song.AuthorName,
                            Name = song.Name,
                            Duration = song.Duration,
                            UrlAudio = song.UrlAudio,
                            UrlImage = song.UrlImage        
                        };
                        if (song.Categories != null)
                        {
                            foreach (var categorySong in song.Categories)
                            {
                                songCategoryDtos.Add(new SongCategoryDto()
                                {
                                    SongDto = songDto,
                                    CategoryDto = new CategoryMapper().DomainToDto(categorySong, context)
                                });
                            }
                        }

                        if (categories != null)
                        {
                            foreach (var category in categories)
                            {
                                songCategoryDtos.Add(new SongCategoryDto()
                                {
                                    SongDto = songDto,
                                    CategoryDto = new CategoryMapper().DomainToDto(category, context)
                                });
                            }
                        }
                        songDto.SongsCategoriesDto = songCategoryDtos;
                    }
                    songsDto.Add(songDto);
                }
            }
            return songsDto;
        }
        
        public PlaylistDto DomainToDto(Playlist obj, ContextDB context)
        {
            PlaylistDto playlistDto = context.Playlists
                .Where(x => x.UrlImage == obj.UrlImage)
                .Where(x=>x.Description==obj.Description)
                .FirstOrDefault(x => x.Name == obj.Name);
            
            if (playlistDto is null)
            {
                playlistDto = new PlaylistDto()
                {
                    Name = obj.Name,
                    Description = obj.Description,
                    UrlImage = obj.UrlImage
                };
            }
            else
            {
                context.Entry(playlistDto).Collection("PlaylistSongsDto").Load();
                context.Entry(playlistDto).Collection("PlaylistCategoriesDto").Load();
                context.Entry(playlistDto).State = EntityState.Modified;
            }
            
            List<SongDto> songs= createSongs(obj.Songs, obj.Categories, context);
            playlistDto.PlaylistSongsDto = new List<PlaylistSongDto>();
            foreach (var songDto in songs)
            {
                playlistDto.PlaylistSongsDto.Add(new PlaylistSongDto(){PlaylistDto = playlistDto, SongDto = songDto});
            }
            
            List<CategoryDto> categories= createCategories(obj.Categories, context);
            playlistDto.PlaylistCategoriesDto = new List<PlaylistCategoryDto>();
            foreach (var categoryDto in categories)
            {
                playlistDto.PlaylistCategoriesDto.Add(new PlaylistCategoryDto(){PlaylistDto = playlistDto,CategoryDto = categoryDto});
            }
            
            return playlistDto;
        }

        

        public Playlist DtoToDomain(PlaylistDto obj, ContextDB context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            List<Category> categories = new List<Category>();
            context.Entry(obj).Collection("PlaylistCategoriesDto").Load();
            if (!(obj.PlaylistCategoriesDto is null))
            {
                foreach (PlaylistCategoryDto playlistCategoryDto in obj.PlaylistCategoriesDto)
                { 
                    Category category=categoryMapper.GetById(context,playlistCategoryDto.CategoryID);
                    categories.Add(category);
                }
            }
            SongMapper songMapper = new SongMapper();
            List<Song> songs = new List<Song>();
            context.Entry(obj).Collection("PlaylistSongsDto").Load();
            if (!(obj.PlaylistSongsDto is null))
            {
                foreach (PlaylistSongDto playlistSongDto in obj.PlaylistSongsDto)
                { 
                    Song song=songMapper.GetById(context,playlistSongDto.SongID);
                    songs.Add(song);
                    
                }
            }
            return new Playlist()
            {
                Description = obj.Description,
                Name = obj.Name,
                Categories= categories,
                Songs = songs,
                UrlImage = obj.UrlImage
            };
        }

        public Playlist GetById(ContextDB context, int id)
        {
            PlaylistDto playlistDto = context.Playlists
                .FirstOrDefault(x => x.PlaylistDtoID == id);
            if (playlistDto != null)
               return DtoToDomain(playlistDto, context);
            return null;
        }

        public PlaylistDto UpdateDtoObject(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            SongMapper songMapper = new SongMapper();
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Description = updatedObject.Description;
            objToUpdate.UrlImage = updatedObject.UrlImage;
            if (objToUpdate.PlaylistSongsDto == null)
            {
                objToUpdate.PlaylistSongsDto = new List<PlaylistSongDto>();
            }
            if (objToUpdate.PlaylistCategoriesDto == null)
            {
                objToUpdate.PlaylistCategoriesDto = new List<PlaylistCategoryDto>(); 
            }
            var diffListOldValuesCategory = UpdatePlaylistCategory(objToUpdate, updatedObject, context, categoryMapper);
            objToUpdate.PlaylistCategoriesDto = diffListOldValuesCategory;
            var diffListOldValuesSong = UpdatePlaylistSongs(objToUpdate, updatedObject, context, songMapper);
            objToUpdate.PlaylistSongsDto = diffListOldValuesSong;
            return objToUpdate;
        }

        private static List<PlaylistSongDto> UpdatePlaylistSongs(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context,
            SongMapper songMapper)
        {
            List<PlaylistSongDto> diffListOldValuesSong =
                objToUpdate.PlaylistSongsDto
                    .Where(
                        x => updatedObject.Songs.Contains(songMapper.DtoToDomain(x.SongDto, context))
                    ).ToList();
            
            IEnumerable<Song> diffListNewValuesSong = updatedObject.Songs
                .Where(
                    x => !objToUpdate.PlaylistSongsDto.Contains(
                        new PlaylistSongDto() {SongDto = songMapper.DomainToDto(x, context)}
                        )
                    );

            diffListOldValuesSong.AddRange(diffListNewValuesSong.Select(x => new PlaylistSongDto()
                {SongDto = songMapper.DomainToDto(x, context)}));
            
            List<SongDto> songToDelete = new List<SongDto>();
            
            objToUpdate.PlaylistSongsDto.Where(x => !diffListOldValuesSong.Contains(x)).ToList();
            if (songToDelete != null)
            {
                foreach (SongDto songDto in songToDelete)
                {
                    context.Entry(songDto).State = EntityState.Deleted;
                }
            }

            return diffListOldValuesSong;
        }

        private static List<PlaylistCategoryDto> UpdatePlaylistCategory(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context,
            CategoryMapper categoryMapper)
        {
            List<PlaylistCategoryDto> diffListOldValuesCategory =
                objToUpdate.PlaylistCategoriesDto.Where(x =>
                    updatedObject.Categories
                        .Contains(categoryMapper.DtoToDomain(x.CategoryDto, context))).ToList();
            IEnumerable<Category> diffListNewValuesCategory = updatedObject.Categories
                .Where(x => !objToUpdate.PlaylistCategoriesDto.
                    Contains(new PlaylistCategoryDto() {CategoryDto = categoryMapper.DomainToDto(x, context)}));
            diffListOldValuesCategory.AddRange(diffListNewValuesCategory
                .Select(x => new PlaylistCategoryDto()
                {CategoryDto = categoryMapper.DomainToDto(x, context)}));
            List<CategoryDto> categoryToDelete = new List<CategoryDto>();
            objToUpdate.PlaylistCategoriesDto.
                Where(x => !diffListOldValuesCategory.Contains(x)).ToList();
            if (categoryToDelete != null)
            {
                foreach (CategoryDto categoryDto in categoryToDelete)
                {
                    context.Entry(categoryDto).State = EntityState.Deleted;
                }
            }

            return diffListOldValuesCategory;
        }
    }
}