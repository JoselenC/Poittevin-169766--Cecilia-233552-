using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSP.BetterCalm.DataAccess
{
    public class CategoryDto
    {
        public int CategoryDtoID { get; set; } 
        public string Name { get; set; }
        
        public ICollection<PlaylistCategoryDto> PlaylistCategoriesDto { get; set; }
        
        public ICollection<SongCategoryDto> SongsCategoriesDto { get; set; }
    }
}