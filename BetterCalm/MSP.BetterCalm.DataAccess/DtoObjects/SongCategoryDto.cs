namespace MSP.BetterCalm.DataAccess
{
    public class SongCategoryDto
    {
        public int SongID { get; set; }
        
        public SongDto SongDto{ get; set; }
        
        public int CategoryID { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}