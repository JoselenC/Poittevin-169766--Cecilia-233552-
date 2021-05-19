using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess
{
    public class AudioDto
    {
        public int AudioDtoID { get; set; }
        
        public string Name {get; set; }
        
        public double Duration {get; set; }
        
        public string AuthorName {get; set; }
        
        public string UrlImage {get; set; }
        
        public string UrlAudio {get; set; }
     
        public ICollection<PlaylistAudioDto> PlaylistAudiosDto { get; set; }
        
        public ICollection<AudioCategoryDto> AudiosCategoriesDto { get; set; }
    }
}