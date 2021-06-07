using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Mappers
{
      public class ContentMapper: IMapper<Content,ContentDto>
      { 
          
          private List<CategoryDto> CreateCategoriesContentsDto(List<Category> categories, ContextDb context)
          {
              List<CategoryDto> categoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> categoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoryDto= categoriesSet.FirstOrDefault(
                        x => x.CategoryDtoId == category.Id || x.Name==category.Name
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
        public ContentDto DomainToDto(Content obj, ContextDb context)
        {
            ContentDto contentDto = context.Contents.FirstOrDefault(x => x.ContentDtoId == obj.Id);
         
            if (contentDto is null)
            {
                contentDto = new ContentDto()
                {
                    ContentDtoId = obj.Id,
                    Name = obj.Name,
                    Duration = obj.Duration,
                    AuthorName = obj.CreatorName ?? "",
                    UrlArchive = obj.UrlArchive ?? "",
                    UrlImage = obj.UrlImage ?? "",
                    Type = obj.Type  ?? ""
                };
            }
            else
            {
                context.Entry(contentDto).Collection("ContentsCategoriesDto").Load();
                context.Entry(contentDto).State = EntityState.Modified;
            }
            
            List<CategoryDto> categories= CreateCategoriesContentsDto(obj.Categories, context);
            contentDto.ContentsCategoriesDto = new List<ContentCategoryDto>();
            foreach (var category in categories)
            {
                contentDto.ContentsCategoriesDto.Add(new ContentCategoryDto(){CategoryDto = category, ContentDto = contentDto});
            }
            return contentDto;
        }

        public Content DtoToDomain(ContentDto obj, ContextDb context)
        {
            List<Category> categories = new List<Category>();
            CategoryMapper categoryMapper = new CategoryMapper();
            context.Entry(obj).Collection("ContentsCategoriesDto").Load();
            if (!(obj.ContentsCategoriesDto is null))
            {
                foreach (ContentCategoryDto contentCategoryDto in obj.ContentsCategoriesDto)
                {
                    Category category = categoryMapper.GetById(context, contentCategoryDto.CategoryId);
                    categories.Add(category);
                }
            }

            var content = CreateContentDomain(obj, context, categories);

            return content;
        }

        private static Content CreateContentDomain(ContentDto obj, ContextDb context, List<Category> categories)
        {
            DbSet<PlaylistContentDto> playlistContentSet = context.Set<PlaylistContentDto>();
            DbSet<PlaylistCategoryDto> playlistCategorySet = context.Set<PlaylistCategoryDto>();
            PlaylistContentDto playlistContentDto = playlistContentSet.FirstOrDefault(x => x.ContentId == obj.ContentDtoId);
            Content content = new Content()
            {
                Id = obj.ContentDtoId,
                CreatorName = obj.AuthorName,
                Name = obj.Name,
                Categories = categories,
                Duration = obj.Duration,
                UrlArchive = obj.UrlArchive,
                UrlImage = obj.UrlImage,
                Type = obj.Type
            };
            if (playlistContentDto == null)
                content.AssociatedToPlaylist = false;
            else
            {
                List<PlaylistContentDto> playlistsContents = playlistContentSet.Where(x => x.ContentId == obj.ContentDtoId).ToList();
                for (int i = 0; i < playlistsContents.Count(); i++)
                {
                    List<PlaylistCategoryDto> playlistsCategories =playlistCategorySet.Where(x =>
                        x.PlaylistId == playlistsContents[i].PlaylistId).ToList();

                    for (int j = 0; j < playlistsCategories.Count(); j++)
                    {
                        CategoryDto categoryDto=context.Categories.FirstOrDefault(x => x.CategoryDtoId == playlistsCategories[j].CategoryId);
                        Category category = new CategoryMapper().DtoToDomain(categoryDto, context);
                        if (categories.Contains(category))
                        {
                            content.AssociatedToPlaylist = true;
                            return content;
                        }
                    }
                }
            }
            return content;
        }

        public Content GetById(ContextDb context, int id)
        {
            ContentDto contentDto = context.Contents.Include(x=>x.ContentsCategoriesDto)
                .FirstOrDefault(m => m.ContentDtoId == id);
            if (contentDto != null)
                return DtoToDomain(contentDto, context);
            return null;
        }

        public ContentDto UpdateDtoObject(ContentDto objToUpdate, Content updatedObject, ContextDb context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();

            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Duration = updatedObject.Duration;
            objToUpdate.UrlArchive = updatedObject.UrlArchive ?? objToUpdate.UrlArchive;
            objToUpdate.UrlImage = updatedObject.UrlImage ?? objToUpdate.UrlImage;
            objToUpdate.AuthorName = updatedObject.CreatorName ?? objToUpdate.AuthorName;
            objToUpdate.Type = updatedObject.Type ?? objToUpdate.Type;
            objToUpdate.ContentsCategoriesDto= UpdateContentCategories(objToUpdate, updatedObject, context, categoryMapper);
            return objToUpdate;
        }

        private List<ContentCategoryDto> UpdateContentCategories(ContentDto objToUpdate, Content updatedObject, ContextDb context, CategoryMapper categoryMapper)
        {
            List<ContentCategoryDto> categoriesToDelete = objToUpdate.ContentsCategoriesDto.Where(x =>
                x.ContentId == objToUpdate.ContentDtoId).ToList();
            foreach (ContentCategoryDto contentCategory in categoriesToDelete)
            {
                context.Set<ContentCategoryDto>().Remove(contentCategory);
                context.SaveChanges();
            }
            List<Category> newCategoriesToAdd = new List<Category>();
            List<ContentCategoryDto> contentsCategoriesToAdd = new List<ContentCategoryDto>();
            if (updatedObject.Categories != null)
            {
                foreach (var category in updatedObject.Categories)
                {
                    Category categoryToAdd = categoryMapper.DtoToDomain(context.Categories
                        .FirstOrDefault(x => x.CategoryDtoId == category.Id || x.Name == category.Name), context);
                    newCategoriesToAdd.Add(categoryToAdd);
                }

                contentsCategoriesToAdd.AddRange(newCategoriesToAdd.Select(x => new ContentCategoryDto() {
                    CategoryDto = categoryMapper.DomainToDto(x, context), CategoryId = x.Id,
                    ContentDto = objToUpdate, ContentId = objToUpdate.ContentDtoId}));
            }
            return contentsCategoriesToAdd;;
        }
      }
}
