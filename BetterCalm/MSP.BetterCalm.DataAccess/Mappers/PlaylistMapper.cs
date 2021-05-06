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
              
            List<CategoryDto> categoriesDto = new List<CategoryDto>();
            DbSet<CategoryDto> categoriesSet = context.Set<CategoryDto>();
            if (!(categories is null))
            {
                foreach (Category category in categories)
                {
                    CategoryDto categoryDto= categoriesSet.FirstOrDefault(x => x.CategoryDtoID == category.Id || x.Name==category.Name);
                    if (categoryDto == null)
                    {
                        throw new InvalidCategory();
                    }
                    categoriesDto.Add(categoryDto);
                }
            }
            return categoriesDto;
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
                        if (audio.Name != null && audio.Name != "")
                        {
                            audioDto = CreateAudio(categories, context, audio);
                        }
                        else
                        {
                            throw new InvalidNameLength();
                        }
                    }

                    audiosDto.Add(audioDto);
                }
            }
            return audiosDto;
        }

        private static AudioDto CreateAudio(List<Category> categories, ContextDB context, Audio audio)
        {
            AudioDto audioDto;
            List<AudioCategoryDto> audioCategoryDtos = new List<AudioCategoryDto>();

            audioDto = new AudioDto()
            {
                AuthorName = audio.AuthorName ?? "",
                Name = audio.Name,
                Duration = audio.Duration,
                UrlAudio = audio.UrlAudio ?? "",
                UrlImage = audio.UrlImage ?? ""
            };
            if (audio.Categories != null)
            {
                foreach (var categoryaudio in audio.Categories)
                {
                    if (categoryaudio.Id != 0)
                    {
                        audioCategoryDtos.Add(new AudioCategoryDto()
                        {
                            AudioDto = audioDto,
                            CategoryDto = new CategoryMapper().DomainToDto(categoryaudio, context)
                        });
                    }
                }
            }

            if (categories != null)
            {
                foreach (var category in categories)
                {
                    CategoryDto categoryToAdd = context.Categories
                        .FirstOrDefault(x => x.CategoryDtoID == category.Id || x.Name==category.Name);
                    audioCategoryDtos.Add(new AudioCategoryDto()
                    {
                        AudioDto = audioDto,
                        CategoryDto = categoryToAdd
                    });
                }
            }

            audioDto.AudiosCategoriesDto = audioCategoryDtos;
            return audioDto;
        }

        public PlaylistDto DomainToDto(Playlist obj, ContextDB context)
        {
            PlaylistDto playlistDto = context.Playlists
                .FirstOrDefault(x => x.PlaylistDtoID == obj.Id);
            
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
                    if(category!=null)
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
                    if(audio!=null)
                    audios.Add(audio);
                }
            }

            return new Playlist()
            {
                Id = obj.PlaylistDtoID,
                Description = obj.Description,
                Name = obj.Name,
                Categories = categories,
                Audios = audios,
                UrlImage = obj.UrlImage
            };
        }

        public Playlist GetById(ContextDB context, int id)
        {
            PlaylistDto playlistDto = context.Playlists.FirstOrDefault(x => x.PlaylistDtoID == id);
            if (playlistDto != null)
               return DtoToDomain(playlistDto, context);
            return null;
        }

        public PlaylistDto UpdateDtoObject(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            AudioMapper audioMapper = new AudioMapper();

            objToUpdate.Name = updatedObject.Name ?? objToUpdate.Name;
            objToUpdate.Description = updatedObject.Description ?? objToUpdate.Description;
            objToUpdate.UrlImage = updatedObject.UrlImage ?? objToUpdate.UrlImage;
            var diffListOldValuesCategory = UpdatePlaylistCategory(objToUpdate, updatedObject, context, categoryMapper);
            objToUpdate.PlaylistCategoriesDto = diffListOldValuesCategory;
            var diffListOldValuesAudio = UpdatePlaylistAudios(objToUpdate, updatedObject, context, audioMapper);
            objToUpdate.PlaylistAudiosDto = diffListOldValuesAudio;
            return objToUpdate;
        }

        private static List<PlaylistAudioDto> UpdatePlaylistAudios(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context,
            AudioMapper audioMapper)
        {
            List<PlaylistAudioDto> audiosToDelete = objToUpdate.PlaylistAudiosDto.Where(x =>
                x.PlaylistID == objToUpdate.PlaylistDtoID).ToList();
            foreach (PlaylistAudioDto playlistAudioDto in audiosToDelete)
            {
                context.Set<PlaylistAudioDto>().Remove(playlistAudioDto);
                context.SaveChanges();
            }
            List<Audio> newAudiosToAdd = new List<Audio>();
            List<PlaylistAudioDto> playlistsAudiosToAdd = new List<PlaylistAudioDto>();
            if (updatedObject.Audios != null)
            {
                foreach (var audio in updatedObject.Audios)
                {
                    Audio audioToAdd = audioMapper.DtoToDomain(context.Audios
                        .FirstOrDefault(x => x.AudioDtoID == audio.Id || x.Name == audio.Name), context);
                    newAudiosToAdd.Add(audioToAdd);
                }

                playlistsAudiosToAdd.AddRange(newAudiosToAdd.Select(x => new PlaylistAudioDto() {
                    AudioDto = audioMapper.DomainToDto(x, context), AudioID = x.Id,
                    PlaylistDto = objToUpdate, PlaylistID = objToUpdate.PlaylistDtoID}));
            }
            return playlistsAudiosToAdd;
        }

        private static List<PlaylistCategoryDto> UpdatePlaylistCategory(PlaylistDto objToUpdate, Playlist updatedObject, ContextDB context,
            CategoryMapper categoryMapper)
        {
            List<PlaylistCategoryDto> categoriesToDelete = objToUpdate.PlaylistCategoriesDto.Where(x =>
                x.PlaylistID == objToUpdate.PlaylistDtoID).ToList();
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
                        .FirstOrDefault(x => x.CategoryDtoID == category.Id || x.Name == category.Name), context);
                    newCategoriesToAdd.Add(categoryToAdd);
                }

                playlistsCategoriesToAdd.AddRange(newCategoriesToAdd.Select(x => new PlaylistCategoryDto() {
                        CategoryDto = categoryMapper.DomainToDto(x, context), CategoryID = x.Id,
                        PlaylistDto = objToUpdate, PlaylistID = objToUpdate.PlaylistDtoID}));
            }
            return playlistsCategoriesToAdd;
        }
    }
}