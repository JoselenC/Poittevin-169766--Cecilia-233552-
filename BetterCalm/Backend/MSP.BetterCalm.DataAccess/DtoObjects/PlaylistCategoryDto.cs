namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistCategoryDto
    {
        public int CategoryID { get; set; }
        
        public CategoryDto CategoryDto{ get; set; }

        public int PlaylistID { get; set; }

        public PlaylistDto PlaylistDto { get; set; }


    }
}