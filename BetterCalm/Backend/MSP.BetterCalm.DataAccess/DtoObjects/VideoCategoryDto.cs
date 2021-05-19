namespace MSP.BetterCalm.DataAccess
{
    public class VideoCategoryDto
    {
        public int VideoID { get; set; }
        
        public VideoDto VideoDto{ get; set; }
        
        public int CategoryID { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}