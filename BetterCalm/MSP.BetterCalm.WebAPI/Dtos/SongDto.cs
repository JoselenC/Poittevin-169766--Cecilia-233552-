using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Dtos
{
    public class SongDto
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
        
        private int duration { get; set; }

        public string Duration { get; set; }
        
        public string AuthorName {get; set; }
        
        public string UrlImage {get; set; }
        
        public string UrlAudio {get; set; }

        
        private int SetDuration(string vDuration)
        {
            if (vDuration.Contains('h'))
                return Int32.Parse(vDuration.Split('h')[0])*60*60;
            else if (vDuration.Contains('m'))
                return Int32.Parse(vDuration.Split('m')[0])*60;
            else if (vDuration.Contains('s'))
                return Int32.Parse(vDuration.Split('s')[0]);
            else
                throw new InvalidDurationFormat();
        }

        public Song CreateSong()
        {
            Song song = new Song()
            {
                Name = Name, Categories = Categories, Duration = SetDuration(Duration), AuthorName = AuthorName,
                UrlAudio = UrlAudio, UrlImage = UrlImage
            };
            return song;
        }
        
        public SongDto CreateSongDto(Song song)
        {
            SongDto songReturn = new SongDto()
            {
                Name = song.Name, Categories = song.Categories, Duration = song.Duration.ToString()+"h", AuthorName = song.AuthorName,
                UrlAudio = song.UrlAudio, UrlImage = song.UrlImage
            };
            return songReturn;
        }
    }
}