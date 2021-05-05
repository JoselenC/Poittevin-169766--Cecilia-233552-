using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Audio
    {
        public int Id { get; set; }
        public List<Category> Categories {get; set; }

        public bool AssociatedToPlaylist { get; set; }
        
        
        private string name;
        public string Name {get=>name; set=>SetName(value); }
        
        private void SetName(string vName)
        {
            if (vName.Length>0)
                name=vName;
            else
                throw new InvalidNameLength();
        }
        public double Duration { get; set; }
        
        public string AuthorName {get; set; }
        
        private bool IsUrlValid(string url)
        {

            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }
        
        private string urlImage;
        public string UrlImage {get=>urlImage; set=>SetUrlImage(value); }
        
        private void SetUrlImage(string vUrl)
        {
            if (IsUrlValid(vUrl) || vUrl=="")
                urlImage=vUrl;
            else
                throw new InvalidUrl();
        }
        
        private string urlAudio;
        public string UrlAudio {get=>urlAudio; set=>SetUrlAudio(value); }
        
        private void SetUrlAudio(string vUrl)
        {
            if (IsUrlValid(vUrl) || vUrl=="")
                urlAudio=vUrl;
            else
                throw new InvalidUrl();
        }
        
        public bool IsSameAudioName(string audioName)
        {
            return Name.ToLower() == audioName.ToLower();
        }
        
        public bool IsSameAuthorName(string authorName)
        {
            return authorName.ToLower() == AuthorName.ToLower();
        }
        
        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((Audio) obj).Id;
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