using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Importer.Models
{
    public class ContentModel
    {
        
        public string Name {get; set; }
      
        public string Duration { get; set; }
        
        public string CreatorName {get; set; }
        
        public string UrlImage {get; set; }  
        
        public string UrlArchive {get; set; }
        
        public string Type { get; set; }
        
        public List<Category> Categories { get; set; }
        
        public List<PlaylistModel> Playlists { get; set; }
        
        
    
       
    }
}