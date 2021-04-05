using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Song
    {

        public List<Category> Categories {get; set; }

        public string Name {get; set; }
        
        public int Duration {get; set; }
        
        public string AuthorName {get; set; }
        
        public string UrlImage {get; set; }
        
        public string UrlAudio {get; set; }


        public bool IsSameSongName(string songName)
        {
            return Name == songName;
        }

        public bool IsSameAuthorName(string authorName)
        {
            return authorName == AuthorName;
        }
        
        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Name == ((Song)obj).Name && AuthorName==((Song)obj).AuthorName
                && UrlAudio==((Song)obj).UrlAudio && UrlImage==((Song)obj).UrlImage
                && Duration==((Song)obj).Duration;
        }

        public bool IsSameCategoryName(string categroyName)
        {
            foreach (var category in Categories)
            {
                if (category.IsSameCategoryName(categroyName))
                    return true;
            }
            return false;
        }
    }
}