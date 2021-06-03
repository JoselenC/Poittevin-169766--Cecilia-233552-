using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain.Exceptions;

namespace MSP.BetterCalm.Domain
{
    public class Content
    {
        public int Id { get; set; }
        
        private string _name;
        public string Name {get=>_name; set=>SetName(value); }
        private void SetName(string vName)
        {
            if (vName.Length>0)
                _name = vName;
            else
                throw new InvalidNameLength();
        }
        public double Duration { get; set; }

        private string _urlImage;
        public string UrlImage {get=>_urlImage; set=>SetUrlImage(value); }   
        
        private string _urlArchive;
        public string UrlArchive {get=>_urlArchive; set=>SetUrlContent(value); }

        private string _type;
        public string Type { get => _type; set => SetType(value); }

        private void SetType(string value)
        {
            if (value == "audio" || value == "video")
            {
                _type=value;
            }
            else
            {
                throw new InvalidContentType();
            }
        }


        private bool IsUrlValid(string url)
        {
            string pattern =
                @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        private void SetUrlImage(string vUrl)
        {
            if (IsUrlValid(vUrl) || vUrl == "")
                _urlImage=vUrl;
            else
                throw new InvalidUrl();
        }
        
        private void SetUrlContent(string vUrl)
        {
            if (IsUrlValid(vUrl) || vUrl == "")
                _urlArchive=vUrl;
            else
                throw new InvalidUrl();
        }
        public List<Category> Categories {get; set; }
        public bool AssociatedToPlaylist { get; set; }
        public string CreatorName {get; set; }

        
        public bool IsSameContentName(string contentName)
        {
            return Name.ToLower() == contentName.ToLower();
        }
        
        public bool IsSameAuthorName(string authorName)
        {
            return authorName.ToLower() == CreatorName.ToLower();
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((Content) obj).Id;
        }

        public bool IsSameCategoryName(string categoryName)
        {
            foreach (var category in Categories)
            {
                if (category.IsSameCategoryName(categoryName))
                    return true;
            }
            return false;
        }
    }
}