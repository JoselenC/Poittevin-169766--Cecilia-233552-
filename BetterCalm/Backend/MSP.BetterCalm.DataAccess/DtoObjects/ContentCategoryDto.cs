namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class ContentCategoryDto
    {
        public int ContentId { get; set; }
        
        public ContentDto ContentDto{ get; set; }
        
        public int CategoryId { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}