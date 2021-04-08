using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess
{
    public class SongDto
    {
        public int SongDtoID { get; set; }
        
        public virtual List<CategoryDto> Categories {get; set; }

        public string Name {get; set; }
        
        public int Duration {get; set; }
        
        public string AuthorName {get; set; }
        
        public string UrlImage {get; set; }
        
        public string UrlAudio {get; set; }
     
        public int? PlaylistDtoID { get; set; }
        
        public virtual PlaylistDto PlaylistDto { get; set; }
    }
}