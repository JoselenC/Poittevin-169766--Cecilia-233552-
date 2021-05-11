using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.DataAccess
{
    public class VideoMapper: IMapper<Video,VideoDto>
      { 
          
          private List<CategoryDto> CreateCategoriesVideosDto(List<Category> categories, ContextDB context)
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
        public VideoDto DomainToDto(Video obj, ContextDB context)
        {
            VideoDto VideoDto = context.Videos.FirstOrDefault(x => x.VideoDtoID == obj.Id);
         
            if (VideoDto is null)
            {
                VideoDto = new VideoDto()
                {
                    VideoDtoID = obj.Id,
                    Name = obj.Name,
                    Duration = obj.Duration,
                    CreatorName = obj.CreatorName ?? "",
                    UrlArchive = obj.UrlArchive ?? ""
                };
            }
            else
            {
                context.Entry(VideoDto).Collection("VideosCategoriesDto").Load();
                context.Entry(VideoDto).State = EntityState.Modified;
            }
            
            List<CategoryDto> categories= CreateCategoriesVideosDto(obj.Categories, context);
            VideoDto.VideosCategoriesDto = new List<VideoCategoryDto>();
            foreach (var category in categories)
            {
                VideoDto.VideosCategoriesDto.Add(new VideoCategoryDto(){CategoryDto = category, VideoDto = VideoDto});
            }
            return VideoDto;
        }

        public Video DtoToDomain(VideoDto obj, ContextDB context)
        {
            List<Category> categories = new List<Category>();
            CategoryMapper categoryMapper = new CategoryMapper();
            context.Entry(obj).Collection("VideosCategoriesDto").Load();
            if (!(obj.VideosCategoriesDto is null))
            {
                foreach (VideoCategoryDto VideoCategoryDto in obj.VideosCategoriesDto)
                {
                    Category category = categoryMapper.GetById(context, VideoCategoryDto.CategoryID);
                    categories.Add(category);
                }
            }

            var Video = CreateVideoDomain(obj, context, categories);

            return Video;
        }

        private static Video CreateVideoDomain(VideoDto obj, ContextDB context, List<Category> categories)
        {
            DbSet<PlaylistVideoDto> playlistVideoSet = context.Set<PlaylistVideoDto>();
            DbSet<PlaylistCategoryDto> playlistCategorySet = context.Set<PlaylistCategoryDto>();
            PlaylistVideoDto playlistVideoDto = playlistVideoSet.FirstOrDefault(x => x.VideoID == obj.VideoDtoID);
            Video Video = new Video()
            {
                Id = obj.VideoDtoID,
                CreatorName = obj.CreatorName,
                Name = obj.Name,
                Categories = categories,
                Duration = obj.Duration,
                UrlArchive = obj.UrlArchive
            };
            if (playlistVideoDto == null)
                Video.AssociatedToPlaylist = false;
            else
            {
                List<PlaylistVideoDto> playlistsVideos = playlistVideoSet.Where(x => x.VideoID == obj.VideoDtoID).ToList();
                for (int i = 0; i < playlistsVideos.Count(); i++)
                {
                    List<PlaylistCategoryDto> playlistsCategories =playlistCategorySet.Where(x =>
                        x.PlaylistID == playlistsVideos[i].PlaylistID).ToList();

                    for (int j = 0; j < playlistsCategories.Count(); j++)
                    {
                        CategoryDto categoryDto=context.Categories.FirstOrDefault(x => x.CategoryDtoID == playlistsCategories[j].CategoryID);
                        Category category = new CategoryMapper().DtoToDomain(categoryDto, context);
                        if (categories.Contains(category))
                        {
                            Video.AssociatedToPlaylist = true;
                            return Video;
                        }
                    }
                }
            }
            return Video;
        }

        public Video GetById(ContextDB context, int id)
        {
            VideoDto VideoDto = context.Videos.Include(x=>x.VideosCategoriesDto)
                .FirstOrDefault(m => m.VideoDtoID == id);
            if (VideoDto != null)
                return DtoToDomain(VideoDto, context);
            return null;
        }

        public VideoDto UpdateDtoObject(VideoDto objToUpdate, Video updatedObject, ContextDB context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();

            objToUpdate.Name = updatedObject.Name;
            objToUpdate.Duration = updatedObject.Duration;
            objToUpdate.UrlArchive = updatedObject.UrlArchive ?? objToUpdate.UrlArchive;
            objToUpdate.CreatorName = updatedObject.CreatorName ?? objToUpdate.CreatorName;
            objToUpdate.VideosCategoriesDto= UpdateVideoCategories(objToUpdate, updatedObject, context, categoryMapper);
            return objToUpdate;
        }

        private List<VideoCategoryDto> UpdateVideoCategories(VideoDto objToUpdate, Video updatedObject, ContextDB context, CategoryMapper categoryMapper)
        {
            List<VideoCategoryDto> categoriesToDelete = objToUpdate.VideosCategoriesDto.Where(x =>
                x.VideoID == objToUpdate.VideoDtoID).ToList();
            foreach (VideoCategoryDto VideoCategory in categoriesToDelete)
            {
                context.Set<VideoCategoryDto>().Remove(VideoCategory);
                context.SaveChanges();
            }
            List<Category> newCategoriesToAdd = new List<Category>();
            List<VideoCategoryDto> VideosCategoriesToAdd = new List<VideoCategoryDto>();
            if (updatedObject.Categories != null)
            {
                foreach (var category in updatedObject.Categories)
                {
                    Category categoryToAdd = categoryMapper.DtoToDomain(context.Categories
                        .FirstOrDefault(x => x.CategoryDtoID == category.Id || x.Name == category.Name), context);
                    newCategoriesToAdd.Add(categoryToAdd);
                }

                VideosCategoriesToAdd.AddRange(newCategoriesToAdd.Select(x => new VideoCategoryDto() {
                    CategoryDto = categoryMapper.DomainToDto(x, context), CategoryID = x.Id,
                    VideoDto = objToUpdate, VideoID = objToUpdate.VideoDtoID}));
            }
            return VideosCategoriesToAdd;;
        }
      }
}
