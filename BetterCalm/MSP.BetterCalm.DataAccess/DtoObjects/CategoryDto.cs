using System.ComponentModel.DataAnnotations.Schema;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryDto
    {
        public int CategoryDtoID { get; set; } 
        public string Name { get; set; }
        
        public int? SongDtoID { get; set; }
        public virtual SongDto SongDto { get; set; }
        
        public int? PlaylistDtoID { get; set; }
        public virtual PlaylistDto PlaylistDto { get; set; }
    }
}