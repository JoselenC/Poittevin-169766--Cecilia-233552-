using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
      public class SongMapper: IMapper<Song,SongDto>
      {
          private List<CategoryDto> createCategoriesSongsDto(List<Category> categories, ContextDB context)
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
                context.Entry(songDto).Collection("SongsCategoriesDto").Load();
                context.Entry(songDto).State = EntityState.Modified;
            }
            
            List<CategoryDto> categories= createCategoriesSongsDto(obj.Categories, context);
            songDto.SongsCategoriesDto = new List<SongCategoryDto>();
            foreach (var category in categories)
            {
                songDto.SongsCategoriesDto.Add(new SongCategoryDto(){CategoryDto = category, SongDto = songDto});
            }
             
            return songDto;
        }

        public Song DtoToDomain(SongDto obj, ContextDB context)
        {
            List<Category> categories = new List<Category>();
            CategoryMapper categoryMapper = new CategoryMapper();
            context.Entry(obj).Collection("SongsCategoriesDto").Load();
            if (!(obj.SongsCategoriesDto is null))
            {
                foreach (SongCategoryDto songCategoryDto in obj.SongsCategoriesDto)
                { 
                    Category category=categoryMapper.GetById(context,songCategoryDto.CategoryID);
                    categories.Add(category);
                    
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

        public Song GetById(ContextDB context, int id)
        {
            SongDto songDto = context.Songs.Include(x=>x.SongsCategoriesDto)
                .FirstOrDefault(m => m.SongDtoID == id);
            if (songDto != null)
                return DtoToDomain(songDto, context);
            return null;
        }

        public SongDto UpdateDtoObject(SongDto objToUpdate, Song updatedObject, ContextDB context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Duration = updatedObject.Duration;
            objToUpdate.UrlAudio = updatedObject.UrlAudio;
            objToUpdate.UrlImage = updatedObject.UrlImage;
            

            if (updatedObject.Categories != null && updatedObject.Categories.Count>0)
            {
                List<SongCategoryDto> diffListOldValues =
                    objToUpdate.SongsCategoriesDto.Where(x =>
                        updatedObject.Categories.Contains(categoryMapper.DtoToDomain(x.CategoryDto, context))).ToList();
                IEnumerable<Category> diffListNewValues = updatedObject.Categories
                    .Where(x => !objToUpdate.SongsCategoriesDto.Contains(new SongCategoryDto()
                        {CategoryDto = categoryMapper.DomainToDto(x, context)}));
                diffListOldValues.AddRange(diffListNewValues.Select(x => new SongCategoryDto()
                    {CategoryDto = categoryMapper.DomainToDto(x, context)}));
                List<CategoryDto> categoryoDelete = new List<CategoryDto>();
                objToUpdate.SongsCategoriesDto.Where(x => !diffListOldValues.Contains(x)).ToList();
                if (categoryoDelete != null)
                {
                    foreach (CategoryDto categoryDto in categoryoDelete)
                    {
                        context.Entry(categoryDto).State = EntityState.Deleted;
                    }
                }

                objToUpdate.SongsCategoriesDto = diffListOldValues;
            }
            else
            {
                objToUpdate.SongsCategoriesDto = null;
            }

            return objToUpdate;
        }
    }
}
