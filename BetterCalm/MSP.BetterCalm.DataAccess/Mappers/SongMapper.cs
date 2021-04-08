using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
      public class SongMapper: IMapper<Song,SongDto>
      {
          private List<CategoryDto> createCategories(List<Category> categories, ContextDB context)
          {
            List<CategoryDto> CategoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> CategoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoriesDto = new CategoryDto()
                        {
                            Name = category.Name
                        };
                    CategoriesDto.Add(categoriesDto);
                }
            }

            return CategoriesDto;
        }
        public SongDto DomainToDto(Song obj, ContextDB context)
        {
            SongDto songDto = context.Songs
                .Where(x => x.Duration == obj.Duration)
                .Where(x => x.AuthorName == obj.AuthorName)
                .Where(x => x.UrlImage == obj.UrlImage)
                .Where(x => x.UrlAudio == obj.UrlAudio)
                .FirstOrDefault(x => x.Name == obj.Name);
            if (songDto is null)
            {
                songDto = new SongDto()
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
                context.Entry(songDto).Collection("Categories").Load();
                context.Entry(songDto).State = EntityState.Modified;
            }

            songDto.Categories = createCategories(obj.Categories, context);
             
            return songDto;
        }

        public Song DtoToDomain(SongDto obj, ContextDB context)
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

            return new Song()
            {
                AuthorName = obj.AuthorName,
                Name = obj.Name,
                Categories= categories,
                Duration = obj.Duration,
                UrlAudio = obj.UrlAudio,
                UrlImage = obj.UrlImage
            };
        }

        public SongDto UpdateDtoObject(SongDto objToUpdate, Song updatedObject, ContextDB context)
        {
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Duration = updatedObject.Duration;
            objToUpdate.UrlAudio = updatedObject.UrlAudio;
            objToUpdate.UrlImage = updatedObject.UrlImage;
            if (objToUpdate.Categories == null)
            {
                objToUpdate.Categories = new List<CategoryDto>();
            }

            List<CategoryDto> diffListOldValues =
                objToUpdate.Categories.Where(x => updatedObject.Categories.Contains(new Category() { Name=x.Name})).ToList();
            List<Category> diffListNewValues = updatedObject.Categories
                    .Where(x => !objToUpdate.Categories.Contains(new CategoryDto() {Name = x.Name })).ToList();
            diffListOldValues.AddRange(diffListNewValues.Select(x => new CategoryDto() {Name = x.Name}));
            List<CategoryDto> categoryoDelete =
                objToUpdate.Categories.Where(x => !diffListOldValues.Contains(x)).ToList();
            if (categoryoDelete != null)
            {
                foreach (CategoryDto categoryDto in categoryoDelete)
                {
                    context.Entry(categoryDto).State = EntityState.Deleted;
                }
            }

            objToUpdate.Categories = diffListOldValues;
            return objToUpdate;
        }
    }
}
