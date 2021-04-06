﻿using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IPlaylistLogic
    {
        public List<Playlist> GetPlaylist();
        public void AddPlaylist(Playlist playlist);
        public List<Playlist> GetPlaylistByName(string playlistName);
        public List<Playlist> GetPlaylistBySongName(string songName); 
        public List<Playlist> GetPlaylistByCategoryName(string categoryName);
        public void UpdatePlaylist(Playlist playlistToUpdate, Playlist newPlaylist);
        public void DeletePlaylist(Playlist playlistToDelete);
    }
}