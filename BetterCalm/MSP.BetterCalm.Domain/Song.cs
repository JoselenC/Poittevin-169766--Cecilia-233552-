using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Song
    {
        public int Id { get; set; }
        public List<Category> Categories {get; set; }

        private string name;
        public string Name {get=>name; set=>SetName(value); }
        
        private void SetName(string vName)
        {
            if (vName.Length>0)
                name=vName;
            else
                throw new InvalidNameLength();
        }
        
        private int duration;
        public int Duration {get=>duration; set=>SetDuration(value); }
        private void SetDuration(int vDuration)
        {
            if (vDuration>= 60)
                duration=vDuration/60;
            else
                duration = vDuration;
        }
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
            return Id == ((Song) obj).Id;
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