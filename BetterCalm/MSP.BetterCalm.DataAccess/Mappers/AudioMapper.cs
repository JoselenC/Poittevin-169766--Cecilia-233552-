using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
      public class AudioMapper: IMapper<Audio,AudioDto>
      { 
          
          private List<CategoryDto> CreateCategoriesAudiosDto(List<Category> categories, ContextDB context)
          {
              List<CategoryDto> categoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> categoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoryDto= categoriesSet.FirstOrDefault(
                        x => x.CategoryDtoID == category.Id || x.Name==category.Name
                        );
                    if (categoryDto == null)
                    {
                        throw new InvalidCategory();
                    }
                    categoriesDto.Add(categoryDto);
                }
            }
            return categoriesDto;
        }
        public AudioDto DomainToDto(Audio obj, ContextDB context)
        {
            AudioDto audioDto = context.Audios.FirstOrDefault(x => x.AudioDtoID == obj.Id);
         
            if (audioDto is null)
            {
                if (obj.AuthorName == null) obj.AuthorName = "";
                if (obj.UrlImage == null) obj.UrlImage = "";
                if (obj.UrlAudio == null) obj.UrlAudio = "";
                
                audioDto = new AudioDto()
                {
                    AudioDtoID = obj.Id,
                    Name = obj.Name,
                    Duration = obj.Duration,
                    AuthorName = obj.AuthorName,
                    UrlAudio = obj.UrlAudio,
                    UrlImage = obj.UrlImage
                    
                };
            }
            else
            {
                context.Entry(audioDto).Collection("AudiosCategoriesDto").Load();
                context.Entry(audioDto).State = EntityState.Modified;
            }
            
            List<CategoryDto> categories= CreateCategoriesAudiosDto(obj.Categories, context);
            audioDto.AudiosCategoriesDto = new List<AudioCategoryDto>();
            foreach (var category in categories)
            {
                audioDto.AudiosCategoriesDto.Add(new AudioCategoryDto(){CategoryDto = category, AudioDto = audioDto});
            }
            return audioDto;
        }

        public Audio DtoToDomain(AudioDto obj, ContextDB context)
        {
            List<Category> categories = new List<Category>();
            CategoryMapper categoryMapper = new CategoryMapper();
            context.Entry(obj).Collection("AudiosCategoriesDto").Load();
            if (!(obj.AudiosCategoriesDto is null))
            {
                foreach (AudioCategoryDto audioCategoryDto in obj.AudiosCategoriesDto)
                {
                    Category category = categoryMapper.GetById(context, audioCategoryDto.CategoryID);
                    categories.Add(category);
                }
            }

            var audio = CreateAudioDomain(obj, context, categories);

            return audio;
        }

        private static Audio CreateAudioDomain(AudioDto obj, ContextDB context, List<Category> categories)
        {
            DbSet<PlaylistAudioDto> playlistAudioSet = context.Set<PlaylistAudioDto>();
            DbSet<PlaylistCategoryDto> playlistCategoriesSet = context.Set<PlaylistCategoryDto>();
            PlaylistAudioDto playlistAudioDto = playlistAudioSet.FirstOrDefault(x => x.AudioID == obj.AudioDtoID);
            Audio audio = new Audio()
            {
                Id = obj.AudioDtoID,
                AuthorName = obj.AuthorName,
                Name = obj.Name,
                Categories = categories,
                Duration = obj.Duration,
                UrlAudio = obj.UrlAudio,
                UrlImage = obj.UrlImage
            };
            if (playlistAudioDto == null)
                audio.AssociatedToPlaylist = false;
            else
            {
                for (int i = 0; i < playlistAudioSet.Count(); i++)
                {
                    if (playlistAudioSet.ToArray()[i].AudioID == obj.AudioDtoID)
                    {
                        PlaylistDto playlist = context.Playlists.FirstOrDefault(x =>
                            x.PlaylistDtoID == playlistAudioSet.ToArray()[i].PlaylistID);
                        for (int j = 0; j < playlistCategoriesSet.Count(); j++)
                        {
                            if (playlistCategoriesSet.ToArray()[j].PlaylistID == playlist.PlaylistDtoID)
                            {
                                CategoryDto category;
                                category = context.Categories.FirstOrDefault(x =>
                                    x.CategoryDtoID == playlistCategoriesSet.ToArray()[j].CategoryID);
                                if (categories.Contains(new CategoryMapper().DtoToDomain(category, context)))
                                    audio.AssociatedToPlaylist = true;
                            }
                        }

                    }
                }
            }

            return audio;
        }

        public Audio GetById(ContextDB context, int id)
        {
            AudioDto audioDto = context.Audios.Include(x=>x.AudiosCategoriesDto)
                .FirstOrDefault(m => m.AudioDtoID == id);
            if (audioDto != null)
                return DtoToDomain(audioDto, context);
            return null;
        }

        public AudioDto UpdateDtoObject(AudioDto objToUpdate, Audio updatedObject, ContextDB context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            
            if (updatedObject.UrlImage == null) updatedObject.UrlImage = "";
            if (updatedObject.UrlAudio == null) updatedObject.UrlAudio = "";
            if (updatedObject.AuthorName == null) updatedObject.AuthorName = "";
            
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Duration = updatedObject.Duration;
            objToUpdate.UrlAudio = updatedObject.UrlAudio;
            objToUpdate.UrlImage = updatedObject.UrlImage;
            objToUpdate.AuthorName = updatedObject.AuthorName;
            objToUpdate.AudiosCategoriesDto= UpdateAudioCategories(objToUpdate, updatedObject, context, categoryMapper);
            return objToUpdate;
        }

        private List<AudioCategoryDto> UpdateAudioCategories(AudioDto objToUpdate, Audio updatedObject, ContextDB context, CategoryMapper categoryMapper)
        {
            List<AudioCategoryDto> diffListOldValuesCategory = objToUpdate.AudiosCategoriesDto.Where(x =>
                updatedObject.Categories.Contains(categoryMapper.DtoToDomain(x.CategoryDto, context))).ToList();
            List<Category> diffListNewValuesCategory = new List<Category>();

            if (updatedObject.Categories != null)
            {
                foreach (var category in updatedObject.Categories)
                {
                    Category categoryToAdd = categoryMapper.DtoToDomain(context.Categories.
                        FirstOrDefault(x => x.CategoryDtoID == category.Id || x.Name == category.Name), context);
                  diffListNewValuesCategory.Add(categoryToAdd);
                }

                diffListOldValuesCategory.AddRange(diffListNewValuesCategory.Select(x => new AudioCategoryDto() {
                    CategoryDto = categoryMapper.DomainToDto(x, context), CategoryID = x.Id,
                    AudioDto = objToUpdate, AudioID = objToUpdate.AudioDtoID}));
            }
            return diffListOldValuesCategory;
        }
      }
}
