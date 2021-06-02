using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class ContentDto
    {
        public int ContentDtoId { get; set; }
        public string Name {get; set; }
        
        public double Duration {get; set; }
        
        public string UrlImage {get; set; }
        
        public string UrlArchive {get; set; }
        
        public string AuthorName {get; set; }
        
        public string Type { get; set; }
     
        public ICollection<PlaylistContentDto> PlaylistContentsDto { get; set; }
        
        public ICollection<ContentCategoryDto> ContentsCategoriesDto { get; set; }
    }
}