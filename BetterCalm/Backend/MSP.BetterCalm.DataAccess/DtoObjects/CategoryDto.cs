using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class CategoryDto
    {
        public int CategoryDtoId { get; set; } 
        public string Name { get; set; }
        
        public ICollection<PlaylistCategoryDto> PlaylistCategoriesDto { get; set; }
        
        public ICollection<ContentCategoryDto> ContentsCategoriesDto { get; set; }
    }
}