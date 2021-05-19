using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Dtos
{
    public class VideoDto
    {
         public int Id { get; set; }
       
        public List<Category> Categories {get; set; }

        private string name;
        public string Name { get;set; }
        
        public string Duration { get; set; }
        
        public string CreatorName {get; set; }
        
        public string UrlArchive {get; set; }

        private bool IsDurationValid(string duration)
        {
            string pattern = @"^([0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9]?[0-9])[hms]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(duration);
        }
        private int SetDuration()
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

        public Video CreateVideo()
        {
            Video Video = new Video()
            {
                Id=Id,
                Name = Name, 
                Categories = Categories, 
                Duration = SetDuration(), 
                CreatorName = CreatorName,
                UrlArchive = UrlArchive
            };
            return Video;
        }
        
        public VideoDto CreateVideoDto(Video video)
        {
            double duration = 0;
            string durationFormat = "0m";
            if (video.Duration != 0)
            {
                duration = (video.Duration / 60);
                if (duration <= 60)
                {
                    durationFormat = duration.ToString() + "m";
                }
                else
                {
                    duration = (video.Duration / 60) / 60;
                    durationFormat = duration.ToString() + "h";
                }
            }
            VideoDto videoReturn = new VideoDto()
            {
                Id = video.Id,
                Name = video.Name, 
                Categories = video.Categories, 
                Duration = durationFormat, 
                CreatorName = video.CreatorName,
                UrlArchive = video.UrlArchive
            };
            return videoReturn;
        }
        
        public override bool Equals(object obj)
        {
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((VideoDto) obj).Id;
        }
    }
}