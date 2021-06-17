namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class PlaylistCategoryDto
    {
        public int CategoryId { get; set; }
        
        public CategoryDto CategoryDto{ get; set; }

        public int PlaylistId { get; set; }

        public PlaylistDto PlaylistDto { get; set; }


    }
}