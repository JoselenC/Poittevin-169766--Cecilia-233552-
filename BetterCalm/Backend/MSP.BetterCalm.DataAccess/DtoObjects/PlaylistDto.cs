using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class PlaylistDto
    {
        public int PlaylistDtoId { get; set; }
        
        public string Name {get; set; }
        
        public string UrlImage {get; set; }
        
        public string Description {get; set; }
        
        public ICollection<PlaylistCategoryDto> PlaylistCategoriesDto { get; set; }
        
        public ICollection<PlaylistContentDto> PlaylistContentsDto { get; set; }
    }
}