using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Playlist
    {
        public List<Category> Categories {get; set; }

        public List<Song> Songs {get; set; }
        
        public string Name {get; set; }
        
        public string UrlImage {get; set; }
        
        public string Description {get; set; }

        public bool IsSamePlaylistName(string name)
        {
            return Name == name;
        }
        
        public bool IsSameCategoryName(string name)
        {
            foreach (var category in Categories)
            {
                if (category.Name == name)
                    return true;
            }
            return false;
        }
        
        public bool IsSameSongName(string name)
        {
            foreach (var song in Songs)
            {
                if (song.Name == name)
                    return true;
            }
            return false;
        }
        
        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Playlist) obj).Name 
                   && Description == ((Playlist) obj).Description
                   && UrlImage == ((Playlist) obj).UrlImage;
        }
    }
}