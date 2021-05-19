namespace MSP.BetterCalm.DataAccess
{
    public class AudioCategoryDto
    {
        public int AudioID { get; set; }
        
        public AudioDto AudioDto{ get; set; }
        
        public int CategoryID { get; set; }

        public CategoryDto CategoryDto { get; set; }
    }
}