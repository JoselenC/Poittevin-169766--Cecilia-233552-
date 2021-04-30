using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
      public class AudioMapper: IMapper<Audio,AudioDto>
      {
          private List<CategoryDto> createCategoriesAudiosDto(List<Category> categories, ContextDB context)
          {
              
            List<CategoryDto> CategoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> CategoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoryDto= CategoriesSet.FirstOrDefault(
                        x => x.CategoryDtoID == category.Id || x.Name==category.Name
                        );
                    if (categoryDto == null)
                    {
                        throw new InvalidCategory();
                    }
                    CategoriesDto.Add(categoryDto);
                }
            }
            return CategoriesDto;
        }
        public AudioDto DomainToDto(Audio obj, ContextDB context)
        {
            AudioDto audioDto = context.Audios
                .Where(x => x.Duration == obj.Duration)
                .Where(x => x.AuthorName == obj.AuthorName)
                .Where(x => x.UrlImage == obj.UrlImage)
                .Where(x => x.UrlAudio == obj.UrlAudio)
                .FirstOrDefault(x => x.Name == obj.Name);
            if (audioDto is null)
            {
                audioDto = new AudioDto()
                {
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
            
            List<CategoryDto> categories= createCategoriesAudiosDto(obj.Categories, context);
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
                    Category category=categoryMapper.GetById(context,audioCategoryDto.CategoryID);
                    categories.Add(category);
                    
                }
            }
            
            DbSet<PlaylistAudioDto> PlaylistAudioSet = context.Set<PlaylistAudioDto>();
            PlaylistAudioDto playlistAudioDto= PlaylistAudioSet.FirstOrDefault(x=>x.AudioID==obj.AudioDtoID);
            if(playlistAudioDto==null)
            return new Audio()
            {
                Id=obj.AudioDtoID,
                AuthorName = obj.AuthorName,
                Name = obj.Name,
                Categories= categories,
                Duration = obj.Duration,
                UrlAudio = obj.UrlAudio,
                UrlImage = obj.UrlImage
            };
            return null;
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
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Duration = updatedObject.Duration;
            objToUpdate.UrlAudio = updatedObject.UrlAudio;
            objToUpdate.UrlImage = updatedObject.UrlImage;
            

            if (updatedObject.Categories != null && updatedObject.Categories.Count>0)
            {
                List<AudioCategoryDto> diffListOldValues =
                    objToUpdate.AudiosCategoriesDto.Where(x =>
                        updatedObject.Categories.Contains(categoryMapper.DtoToDomain(x.CategoryDto, context))).ToList();
                IEnumerable<Category> diffListNewValues = updatedObject.Categories
                    .Where(x => !objToUpdate.AudiosCategoriesDto.Contains(new AudioCategoryDto()
                        {CategoryDto = categoryMapper.DomainToDto(x, context)}));
                diffListOldValues.AddRange(diffListNewValues.Select(x => new AudioCategoryDto()
                    {CategoryDto = categoryMapper.DomainToDto(x, context)}));
                List<CategoryDto> categoryoDelete = new List<CategoryDto>();
                objToUpdate.AudiosCategoriesDto.Where(x => !diffListOldValues.Contains(x)).ToList();
                if (categoryoDelete != null)
                {
                    foreach (CategoryDto categoryDto in categoryoDelete)
                    {
                        context.Entry(categoryDto).State = EntityState.Deleted;
                    }
                }

                objToUpdate.AudiosCategoriesDto = diffListOldValues;
            }
            else
            {
                objToUpdate.AudiosCategoriesDto = null;
            }

            return objToUpdate;
        }
    }
}
