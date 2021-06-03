using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Dtos
{
    public class ContentDto
    {
        public int Id { get; set; }
        public List<Category> Categories {get; set; }
        public string AuthorName {get; set; }
        public string Name { get;set; }
        public string Duration { get; set; }
        public string UrlImage {get; set; }
        public string UrlArchive {get; set; }
        public string Type { get; set; }
        private bool IsDurationValid(string duration)
        {
            string pattern = @"^([0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9])[hms]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(duration);
        }

        public int SetDuration()
        {
            if (IsDurationValid(Duration.ToLower()))
            {
                if (Duration.ToLower().Contains('h'))
                    return Int32.Parse(Duration.ToLower().Split('h')[0]) * 60 * 60;
                else if (Duration.ToLower().Contains('m'))
                    return Int32.Parse(Duration.ToLower().Split('m')[0]) * 60;
                else if (Duration.ToLower().Contains('s'))
                    return Int32.Parse(Duration.ToLower().Split('s')[0]);
            }
            throw new InvalidDurationFormat();
        }
        public Content CreateContent()
        {
            Content content = new Content()
            {
                Name = Name, 
                Categories = Categories, 
                Duration = SetDuration(), 
                CreatorName = AuthorName,
                UrlArchive = UrlArchive, 
                UrlImage = UrlImage,
                Type= Type
            };
            return content;
        }
        
        public ContentDto CreateContentDto(Content content)
        {
            double duration = 0;
            string durationFormat = "0m";
            if (content.Duration != 0)
            {
                duration = (content.Duration / 60);
                if (duration <= 60)
                {
                    durationFormat = duration.ToString() + "m";
                }
                else
                {
                    duration = (content.Duration / 60) / 60;
                    durationFormat = duration.ToString() + "h";
                }
            }
            ContentDto contentReturn = new ContentDto()
            {
                Id = content.Id,
                Name = content.Name, 
                Categories = content.Categories, 
                Duration = durationFormat, 
                AuthorName = content.CreatorName,
                UrlArchive = content.UrlArchive, 
                UrlImage = content.UrlImage,
                Type=content.Type
            };
            return contentReturn;
        }
        
        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((ContentDto) obj).Id;
        }
    }
}