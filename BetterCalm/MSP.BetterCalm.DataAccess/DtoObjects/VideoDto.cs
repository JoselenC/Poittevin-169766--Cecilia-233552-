using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess
{
    public class VideoDto
    {
        public int VideoDtoID { get; set; }
        
        public string Name {get; set; }
        
        public double Duration {get; set; }
        
        public string CreatorName {get; set; }
        
        public string UrlArchive {get; set; }
        
        public ICollection<PlaylistVideoDto> PlaylistVideosDto { get; set; }
        
        public ICollection<VideoCategoryDto> VideosCategoriesDto { get; set; }
    }
}