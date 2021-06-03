using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.DataAccess.DtoObjects;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess.Mappers
{
    public class PlaylistMapper:IMapper<Playlist,PlaylistDto>
    {
        
        private List<CategoryDto> createCategories(List<Category> categories, ContextDb context)
        {
              
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> categoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoryDto= categoriesSet.FirstOrDefault(x => x.CategoryDtoId == category.Id || x.Name==category.Name);
                    if (categoryDto == null)
                    {
                        throw new InvalidCategory();
                    }
                    categoriesDto.Add(categoryDto);
                }
            }
            return categoriesDto;
        }
        
        private List<ContentDto> createContents(List<Content> contents,  List<Category> categories,ContextDb context)
        {
              
            List<ContentDto> contentsDto = new List<ContentDto>();
            DbSet<ContentDto> contentsSet = context.Set<ContentDto>();
            if (!(contents is null))
            {
                foreach (Content content in contents)
                {
                    ContentDto contentDto= contentsSet.FirstOrDefault(x => x.ContentDtoId == content.Id || (x.Name==content.Name && x.AuthorName==content.CreatorName ));
                    if (contentDto == null)
                    {
                        if (!string.IsNullOrEmpty(content.Name))
                        {
                            contentDto = CreateContent(categories, context, content);
                        }
                        else
                        {
                            throw new InvalidNameLength();
                        }
                    }

                    contentsDto.Add(contentDto);
                }
            }
            return contentsDto;
        }

        private static ContentDto CreateContent(List<Category> categories, ContextDb context, Content content)
        {
            List<ContentCategoryDto> contentCategoryDtos = new List<ContentCategoryDto>();

            var contentDto = new ContentDto()
            {
                AuthorName = content.CreatorName ?? "",
                Name = content.Name,
                Duration = content.Duration,
                UrlArchive = content.UrlArchive ?? "",
                UrlImage = content.UrlImage ?? "",
                Type= content.Type ?? ""
            };
            if (content.Categories != null)
            {
                foreach (var categoryContent in content.Categories)
                {
                    if (categoryContent.Id != 0)
                    {
                        contentCategoryDtos.Add(new ContentCategoryDto()
                        {
                            ContentDto = contentDto,
                            CategoryDto = new CategoryMapper().DomainToDto(categoryContent, context)
                        });
                    }
                }
            }

            if (categories != null)
            {
                foreach (var category in categories)
                {
                    CategoryDto categoryToAdd = context.Categories
                        .FirstOrDefault(x => x.CategoryDtoId == category.Id || x.Name==category.Name);
                    contentCategoryDtos.Add(new ContentCategoryDto()
                    {
                        ContentDto = contentDto,
                        CategoryDto = categoryToAdd
                    });
                }
            }

            contentDto.ContentsCategoriesDto = contentCategoryDtos;
            return contentDto;
        }

        public PlaylistDto DomainToDto(Playlist obj, ContextDb context)
        {
            PlaylistDto playlistDto = context.Playlists
                .FirstOrDefault(x => x.PlaylistDtoId == obj.Id);
            
            if (playlistDto is null)
            {
                if (obj.UrlImage == null) obj.UrlImage = "";
                if (obj.Description == null) obj.Description = "";
                playlistDto = new PlaylistDto()
                {
                    Name = obj.Name,
                    Description = obj.Description,
                    UrlImage = obj.UrlImage
                };
            }
            else
            {
                context.Entry(playlistDto).Collection("PlaylistContentsDto").Load();
                context.Entry(playlistDto).Collection("PlaylistCategoriesDto").Load();
                context.Entry(playlistDto).State = EntityState.Modified;
            }
             
            List<ContentDto> contents= createContents(obj.Contents, obj.Categories, context);
            playlistDto.PlaylistContentsDto = new List<PlaylistContentDto>();
            foreach (var contentDto in contents)
            {
                playlistDto.PlaylistContentsDto.Add(new PlaylistContentDto(){PlaylistDto = playlistDto, ContentDto = contentDto});
            }
            
            List<CategoryDto> categories= createCategories(obj.Categories, context);
            playlistDto.PlaylistCategoriesDto = new List<PlaylistCategoryDto>();
            foreach (var categoryDto in categories)
            {
                playlistDto.PlaylistCategoriesDto.Add(new PlaylistCategoryDto(){PlaylistDto = playlistDto,CategoryDto = categoryDto});
            }
            
            return playlistDto;
        }

        public Playlist DtoToDomain(PlaylistDto obj, ContextDb context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            List<Category> categories = new List<Category>();
            context.Entry(obj).Collection("PlaylistCategoriesDto").Load();
            if (!(obj.PlaylistCategoriesDto is null))
            {
                foreach (PlaylistCategoryDto playlistCategoryDto in obj.PlaylistCategoriesDto)
                { 
                    Category category=categoryMapper.GetById(context,playlistCategoryDto.CategoryId);
                    if(category!=null)
                        categories.Add(category);
                }
            }
            ContentMapper contentMapper = new ContentMapper();
            List<Content> contents = new List<Content>();
            context.Entry(obj).Collection("PlaylistContentsDto").Load();
            if (!(obj.PlaylistContentsDto is null))
            {
                foreach (PlaylistContentDto playlistContentDto in obj.PlaylistContentsDto)
                { 
                    Content content=contentMapper.GetById(context,playlistContentDto.ContentId);
                    if(content!=null)
                        contents.Add(content);
                }
            }

            return new Playlist()
            {
                Id = obj.PlaylistDtoId,
                Description = obj.Description,
                Name = obj.Name,
                Categories = categories,
                Contents = contents,
                UrlImage = obj.UrlImage
            };
        }

        public Playlist GetById(ContextDb context, int id)
        {
            PlaylistDto playlistDto = context.Playlists.FirstOrDefault(x => x.PlaylistDtoId == id);
            if (playlistDto != null)
               return DtoToDomain(playlistDto, context);
            return null;
        }

        public PlaylistDto UpdateDtoObject(PlaylistDto objToUpdate, Playlist updatedObject, ContextDb context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            ContentMapper contentMapper = new ContentMapper();

            objToUpdate.Name = updatedObject.Name ?? objToUpdate.Name;
            objToUpdate.Description = updatedObject.Description ?? objToUpdate.Description;
            objToUpdate.UrlImage = updatedObject.UrlImage ?? objToUpdate.UrlImage;
            var diffListOldValuesCategory = UpdatePlaylistCategory(objToUpdate, updatedObject, context, categoryMapper);
            objToUpdate.PlaylistCategoriesDto = diffListOldValuesCategory;
            var diffListOldValuesContent = UpdatePlaylistContents(objToUpdate, updatedObject, context, contentMapper);
            objToUpdate.PlaylistContentsDto = diffListOldValuesContent;
            return objToUpdate;
        }

        private static List<PlaylistContentDto> UpdatePlaylistContents(PlaylistDto objToUpdate, Playlist updatedObject, ContextDb context,
            ContentMapper contentMapper)
        {
            List<PlaylistContentDto> contentsToDelete = objToUpdate.PlaylistContentsDto.Where(x =>
                x.PlaylistId == objToUpdate.PlaylistDtoId).ToList();
            foreach (PlaylistContentDto playlistContentDto in contentsToDelete)
            {
                context.Set<PlaylistContentDto>().Remove(playlistContentDto);
                context.SaveChanges();
            }
            List<Content> newContentsToAdd = new List<Content>();
            List<PlaylistContentDto> playlistsContentsToAdd = new List<PlaylistContentDto>();
            if (updatedObject.Contents != null)
            {
                foreach (var content in updatedObject.Contents)
                {
                    Content contentToAdd = contentMapper.DtoToDomain(context.Contents
                        .FirstOrDefault(x => x.ContentDtoId == content.Id || x.Name == content.Name), context);
                    newContentsToAdd.Add(contentToAdd);
                }

                playlistsContentsToAdd.AddRange(newContentsToAdd.Select(x => new PlaylistContentDto() {
                    ContentDto = contentMapper.DomainToDto(x, context), ContentId = x.Id,
                    PlaylistDto = objToUpdate, PlaylistId = objToUpdate.PlaylistDtoId}));
            }
            return playlistsContentsToAdd;
        }

        private static List<PlaylistCategoryDto> UpdatePlaylistCategory(PlaylistDto objToUpdate, Playlist updatedObject, ContextDb context,
            CategoryMapper categoryMapper)
        {
            List<PlaylistCategoryDto> categoriesToDelete = objToUpdate.PlaylistCategoriesDto.Where(x =>
                x.PlaylistId == objToUpdate.PlaylistDtoId).ToList();
            foreach (PlaylistCategoryDto playlistCategory in categoriesToDelete)
            {
                context.Set<PlaylistCategoryDto>().Remove(playlistCategory);
                context.SaveChanges();
            }
            List<Category> newCategoriesToAdd = new List<Category>();
            List<PlaylistCategoryDto> playlistsCategoriesToAdd = new List<PlaylistCategoryDto>();
            if (updatedObject.Categories != null)
            {
                foreach (var category in updatedObject.Categories)
                {
                    Category categoryToAdd = categoryMapper.DtoToDomain(context.Categories
                        .FirstOrDefault(x => x.CategoryDtoId == category.Id || x.Name == category.Name), context);
                    newCategoriesToAdd.Add(categoryToAdd);
                }

                playlistsCategoriesToAdd.AddRange(newCategoriesToAdd.Select(x => new PlaylistCategoryDto() {
                        CategoryDto = categoryMapper.DomainToDto(x, context), CategoryId = x.Id,
                        PlaylistDto = objToUpdate, PlaylistId = objToUpdate.PlaylistDtoId}));
            }
            return playlistsCategoriesToAdd;
        }
    }
}