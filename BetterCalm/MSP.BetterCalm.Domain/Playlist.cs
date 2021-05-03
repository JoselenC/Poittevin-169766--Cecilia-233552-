﻿using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
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
        
        public void SetName(string vName)
        {
            if (vName.Length>0)
                name=vName;
            else
                throw new InvalidNameLength();
        }
        public string UrlImage {get; set; }

        private string description;
        public string Description {get=>description; set=>SetDescription(value); }

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
            if (obj==null) return false;
            if (obj.GetType() != GetType()) return false;
            return Id == ((Playlist) obj).Id;
        }
    }
}