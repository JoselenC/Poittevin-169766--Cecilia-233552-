﻿using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Dtos
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        
        public List<Category> Categories {get; set; }
        
        public List<Content> Contents {get; set; }
        
        public string Name {get; set; }
        
        public string UrlImage {get; set; }

        public string Description {get; set; }

        public Playlist CreatePlaylist()
        {
            Playlist playlist= new Playlist()
            {
                Id=Id,Name = Name, Categories = Categories, Description = Description, UrlImage = UrlImage,
                Contents = Contents
            };
            return playlist;
        }
    }
}