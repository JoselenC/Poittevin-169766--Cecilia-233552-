using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Playlist
    {
        public int Id { get; set; }
        public List<Category> Categories {get; set; }
        public List<Audio> Audios {get; set; }
        
        private string name;
        public string Name {get=>name; set=>SetName(value); }
        
        private string description;
        
        public string Description {get=>description; set=>SetDescription(value); }

        private string urlImage;
        public string UrlImage {get=>urlImage; set=>SetUrlImage(value); }

        public void SetName(string vName)
        {
            if (vName.Length > 0)
                name=vName;
            else
                throw new InvalidNameLength();
        }
        
        private bool IsUrlValid(string url)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }
        private void SetUrlImage(string vUrl)
        {
            if (IsUrlValid(vUrl) || vUrl == "")
                urlImage=vUrl;
            else
                throw new InvalidUrl();
        }
        private void SetDescription(string vDescription)
        {
            if (vDescription.Length < 150)
                description = vDescription;
            else
             throw new InvalidDescriptionLength();
        }
        public bool IsSamePlaylistName(string name)
        {
            return Name.ToLower() == name.ToLower();
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
        public bool IsSameAudioName(string name)
        {
            foreach (var song in Audios)
            {
                if (song.Name.ToLower() == name.ToLower())
                    return true;
            }
            return false;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((Playlist) obj).Id;
        }
    }
}