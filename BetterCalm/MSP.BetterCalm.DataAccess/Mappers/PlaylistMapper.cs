using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistMapper:IMapper<Playlist,PlaylistDto>
    {
        public PlaylistDto DomainToDto(Playlist obj, ContextDB context)
        {
            
            PlaylistDto playlistDto = context.Playlists
                .Where(x => x.UrlImage == obj.UrlImage)
                .Where(x => x.Description == obj.Description)
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
                context.Entry(playlistDto).Collection("Categories").Load();
                context.Entry(playlistDto).Collection("Songs").Load();
                context.Entry(playlistDto).State = EntityState.Modified;
            }

            playlistDto.Categories = createCategories(obj.Categories, context);
            playlistDto.Songs = createSongs(obj.Songs, context);
            return playlistDto;
        }

        private List<CategoryDto> createCategories(List<Category> categories, ContextDB context)
        {
            List<CategoryDto> CategoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> CategoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoriesDto = CategoriesSet.FirstOrDefault(x => x.Name == category.Name);
                    if (categoriesDto is null)
                        categoriesDto = new CategoryDto()
                        {
                            Name = category.Name
                        };
                    CategoriesDto.Add(categoriesDto);
                }
            }

            return CategoriesDto;
        }

        private List<SongDto> createSongs(List<Song> songs, ContextDB context)
        {
            List<SongDto> SongsDto = new List<SongDto>();
            DbSet<SongDto> SongsSet = context.Set<SongDto>();
            if (!(songs is null))
            {
                foreach (Song song in songs)
                {
                    SongDto categoriesDto = SongsSet.FirstOrDefault(x => x.Name == song.Name);
                    if (categoriesDto is null)
                        categoriesDto = new SongDto()
                        {
                            Name = song.Name
                        };
                    SongsDto.Add(categoriesDto);
                }
            }

            return SongsDto;
        }

        public Playlist DtoToDomain(PlaylistDto obj, ContextDB context)
        {
            List<Category> categories = new List<Category>();
            CategoryMapper categoryMapper = new CategoryMapper();
            context.Entry(obj).Collection("Categories").Load();
            if (!(obj.Categories is null))
            {
                foreach (CategoryDto categoryDto in obj.Categories)
                { 
                    categories.Add(categoryMapper.DtoToDomain(categoryDto, context));
                }
            }
            List<Song> songs = new List<Song>();
            SongMapper songMapper = new SongMapper();
            context.Entry(obj).Collection("Songs").Load();
            if (!(obj.Songs is null))
            {
                foreach (SongDto songDto in obj.Songs)
                { 
                    songs.Add(songMapper.DtoToDomain(songDto, context));
                }
            }

            return new Playlist()
            {
                Name = obj.Name,
                Description = obj.Description,
                Categories= categories,
                Songs = songs,
                UrlImage = obj.UrlImage
            };
        }

        public PlaylistDto UpdateDtoObject(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context)
        {
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Description = updatedObject.Description;
            objToUpdate.UrlImage = updatedObject.UrlImage;
            if (objToUpdate.Categories == null)
            {
                objToUpdate.Categories = new List<CategoryDto>();
            }
            List<CategoryDto> diffListOldValuesCategories =
                objToUpdate.Categories.Where(x => updatedObject.Categories.Contains(new Category() { Name=x.Name})).ToList();
            List<Category> diffListNewValuesCategories = updatedObject.Categories
                .Where(x => !objToUpdate.Categories.Contains(new CategoryDto() {Name = x.Name })).ToList();
            diffListOldValuesCategories.AddRange(diffListNewValuesCategories.Select(x => new CategoryDto() {Name = x.Name}));
            List<CategoryDto> categoryoDelete =
                objToUpdate.Categories.Where(x => !diffListOldValuesCategories.Contains(x)).ToList();
            if (categoryoDelete != null)
            {
                foreach (CategoryDto categoryDto in categoryoDelete)
                {
                    context.Entry(categoryDto).State = EntityState.Deleted;
                }
            }
            objToUpdate.Categories = diffListOldValuesCategories;
            

            if (objToUpdate.Songs == null)
            {
                objToUpdate.Songs = new List<SongDto>();
            }
            List<SongDto> diffListOldValues =
                objToUpdate.Songs.Where(x => updatedObject.Songs.Contains(new Song() { Name=x.Name})).ToList();
            List<Song> diffListNewValues = updatedObject.Songs
                .Where(x => !objToUpdate.Songs.Contains(new SongDto() {Name = x.Name })).ToList();
            diffListOldValues.AddRange(diffListNewValues.Select(x => new SongDto() {Name = x.Name}));
            List<SongDto> songToDelete =
                objToUpdate.Songs.Where(x => !diffListOldValues.Contains(x)).ToList();
            if (songToDelete != null)
            {
                foreach (SongDto categoryDto in songToDelete)
                {
                    context.Entry(categoryDto).State = EntityState.Deleted;
                }
            }
            objToUpdate.Songs = diffListOldValues;
            
            return objToUpdate;
        }
    }
}