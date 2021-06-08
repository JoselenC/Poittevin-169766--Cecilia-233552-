using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.Importer.Models
{
    public class PlaylistModel
    {
        public string Name {get; set; }
        
        public string Description {get; set; }
        
        public string UrlImage {get; set; }
        
        public List<Category> Categories {get; set; }
    }
}