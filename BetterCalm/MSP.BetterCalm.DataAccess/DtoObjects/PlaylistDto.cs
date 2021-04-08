using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistDto
    {
        public int PlaylistDtoID { get; set; }
        
        public virtual List<CategoryDto> Categories {get; set; }

        public virtual List<SongDto> Songs {get; set; }
        
        public string Name {get; set; }
        
        public string UrlImage {get; set; }
        
        public string Description {get; set; }
    }
}