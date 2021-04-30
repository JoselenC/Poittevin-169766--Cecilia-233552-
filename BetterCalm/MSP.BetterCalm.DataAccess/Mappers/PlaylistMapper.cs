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
        
        private List<AudioDto> createAudios(List<Audio> audios,  List<Category> categories,ContextDB context)
        {
              
            List<AudioDto> audiosDto = new List<AudioDto>();
            DbSet<AudioDto> audiosSet = context.Set<AudioDto>();
            if (!(audios is null))
            {
                foreach (Audio audio in audios)
                {
                    AudioDto audioDto= audiosSet.FirstOrDefault(x => x.AudioDtoID == audio.Id || (x.Name==audio.Name && x.AuthorName==audio.AuthorName ));
                    if (audioDto == null)
                    {
                        List<AudioCategoryDto> audioCategoryDtos = new List<AudioCategoryDto>();
                       
                        audioDto = new AudioDto(){
                            AuthorName = audio.AuthorName,
                            Name = audio.Name,
                            Duration = audio.Duration,
                            UrlAudio = audio.UrlAudio,
                            UrlImage = audio.UrlImage        
                        };
                        if (audio.Categories != null)
                        {
                            foreach (var categoryaudio in audio.Categories)
                            {
                                audioCategoryDtos.Add(new AudioCategoryDto()
                                {
                                    AudioDto = audioDto,
                                    CategoryDto = new CategoryMapper().DomainToDto(categoryaudio, context)
                                });
                            }
                        }

                        if (categories != null)
                        {
                            foreach (var category in categories)
                            {
                                audioCategoryDtos.Add(new AudioCategoryDto()
                                {
                                    AudioDto = audioDto,
                                    CategoryDto = new CategoryMapper().DomainToDto(category, context)
                                });
                            }
                        }
                        audioDto.AudiosCategoriesDto = audioCategoryDtos;
                    }
                    audiosDto.Add(audioDto);
                }
            }
            return audiosDto;
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
                context.Entry(playlistDto).Collection("PlaylistAudiosDto").Load();
                context.Entry(playlistDto).Collection("PlaylistCategoriesDto").Load();
                context.Entry(playlistDto).State = EntityState.Modified;
            }
            
            List<AudioDto> audios= createAudios(obj.Audios, obj.Categories, context);
            playlistDto.PlaylistAudiosDto = new List<PlaylistAudioDto>();
            foreach (var audioDto in audios)
            {
                playlistDto.PlaylistAudiosDto.Add(new PlaylistAudioDto(){PlaylistDto = playlistDto, AudioDto = audioDto});
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
            AudioMapper audioMapper = new AudioMapper();
            List<Audio> audios = new List<Audio>();
            context.Entry(obj).Collection("PlaylistAudiosDto").Load();
            if (!(obj.PlaylistAudiosDto is null))
            {
                foreach (PlaylistAudioDto playlistAudioDto in obj.PlaylistAudiosDto)
                { 
                    Audio audio=audioMapper.GetById(context,playlistAudioDto.AudioID);
                    audios.Add(audio);
                    
                }
            }
            return new Playlist()
            {
                Description = obj.Description,
                Name = obj.Name,
                Categories= categories,
                Audios = audios,
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
            AudioMapper audioMapper = new AudioMapper();
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Description = updatedObject.Description;
            objToUpdate.UrlImage = updatedObject.UrlImage;
            if (objToUpdate.PlaylistAudiosDto == null)
            {
                objToUpdate.PlaylistAudiosDto = new List<PlaylistAudioDto>();
            }
            if (objToUpdate.PlaylistCategoriesDto == null)
            {
                objToUpdate.PlaylistCategoriesDto = new List<PlaylistCategoryDto>(); 
            }
            var diffListOldValuesCategory = UpdatePlaylistCategory(objToUpdate, updatedObject, context, categoryMapper);
            objToUpdate.PlaylistCategoriesDto = diffListOldValuesCategory;
            var diffListOldValuesAudio = UpdatePlaylistAudios(objToUpdate, updatedObject, context, audioMapper);
            objToUpdate.PlaylistAudiosDto = diffListOldValuesAudio;
            return objToUpdate;
        }

        private static List<PlaylistAudioDto> UpdatePlaylistAudios(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context,
            AudioMapper audioMapper)
        {
            List<PlaylistAudioDto> diffListOldValuesAudios =
                objToUpdate.PlaylistAudiosDto
                    .Where(
                        x => updatedObject.Audios.Contains(audioMapper.DtoToDomain(x.AudioDto, context))
                    ).ToList();
            
            IEnumerable<Audio> diffListNewValuesAudio = updatedObject.Audios
                .Where(
                    x => !objToUpdate.PlaylistAudiosDto.Contains(
                        new PlaylistAudioDto() {AudioDto = audioMapper.DomainToDto(x, context)}
                        )
                    );

            diffListOldValuesAudios.AddRange(diffListNewValuesAudio.Select(x => new PlaylistAudioDto()
                {AudioDto = audioMapper.DomainToDto(x, context)}));
            
            List<AudioDto> audioToDelete = new List<AudioDto>();
            
            objToUpdate.PlaylistAudiosDto.Where(x => !diffListOldValuesAudios.Contains(x)).ToList();
            if (audioToDelete != null)
            {
                foreach (AudioDto audioDto in audioToDelete)
                {
                    context.Entry(audioDto).State = EntityState.Deleted;
                }
            }

            return diffListOldValuesAudios;
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