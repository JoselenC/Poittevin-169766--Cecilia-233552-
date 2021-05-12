using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Video
    {
        public int Id { get; set; }
        
        public List<Category> Categories {get; set; }
        
        public bool AssociatedToPlaylist { get; set; }
        
        private string name;
        public string Name {get=>name; set=>SetName(value); }
        
        public double Duration { get; set; }
        
        public string CreatorName {get; set; }
        
        private string urlArchive;
        public string UrlArchive {get=>urlArchive; set=>SetUrlArchive(value); }   
        
        private void SetName(string vName)
        {
            if (vName.Length>0)
                name = vName;
            else
                throw new InvalidNameLength();
        }

        private bool IsUrlValid(string url)
        {
            string pattern =
                @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        private void SetUrlArchive(string vUrl)
        {
            if (IsUrlValid(vUrl) || vUrl == "")
                urlArchive=vUrl;
            else
                throw new InvalidUrl();
        }
        
        public bool IsSameVideoName(string videoName)
        {
            return Name.ToLower() == videoName.ToLower();
        }
        
        public bool IsSameCreatorName(string creatorName)
        {
            return CreatorName.ToLower() == creatorName.ToLower();
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((Video) obj).Id;
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