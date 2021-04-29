﻿using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PlaylistService:IPlaylistService
    {
        private ManagerPlaylistRepository repository;
        private ManagerSongRepository repositorySong;
        public PlaylistService(ManagerPlaylistRepository vRepository,ManagerSongRepository vRepositorySong)
        {
            repositorySong = vRepositorySong;
            repository = vRepository;
        }
        
        public List<Playlist> GetPlaylist()
        {
            return repository.Playlists.Get();
        }

        public void AddPlaylist(Playlist playlist)
        {
            AddCategoryToPlaylist(playlist);

            repository.Playlists.Add(playlist);
        }

        private static void AddCategoryToPlaylist(Playlist playlist)
        {
            for (int i = 0; i < playlist.Songs.Count; i++)
            {
                if (playlist.Songs[i].Categories != null)
                {
                    foreach (var category in playlist.Songs[i].Categories)
                    {
                        if (!playlist.Categories.Contains(category))
                        {
                            playlist.Categories.Add(category);
                        }
                    }
                }
            }
        }

        public List<Playlist> GetPlaylistByName(string playlistName)
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in repository.Playlists.Get())
            {
                if(playlist.IsSamePlaylistName(playlistName))
                    playlists.Add(playlist);
            }

            if (playlists.Count == 0)
                throw new KeyNotFoundException();
            return playlists;
        }

        public List<Playlist> GetPlaylistBySongName(string songName)
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in repository.Playlists.Get())
            {
                if(playlist.IsSameSongName(songName))
                    playlists.Add(playlist);
            }
            if (playlists.Count == 0)
                throw new KeyNotFoundException();
            return playlists;
        }

        public List<Playlist> GetPlaylistByCategoryName(string categoryName)
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in repository.Playlists.Get())
            {
                if(playlist.IsSameCategoryName(categoryName))
                    playlists.Add(playlist);
            }

            if (playlists.Count == 0)
                throw new KeyNotFoundException();
            return playlists;
        }

        public void UpdatePlaylist(Playlist playlistToUpdate, Playlist newPlaylist)
        {
            repository.Playlists.Update(playlistToUpdate, newPlaylist);
        }
        
        public void UpdatePlaylistById(int id, Playlist newPlaylist)
        {
  
            Playlist playlistToUpdate = repository.Playlists.FindById(id);
            repository.Playlists.Update(playlistToUpdate, newPlaylist);

        }
        
        public void DeletePlaylistByName(string name)
        {
            Playlist playlistToDelete=repository.Playlists.Find(x => x.IsSamePlaylistName(name));
            DeletePlaylist(playlistToDelete.Id);
        }
        
        public void DeletePlaylist(int id)
        {

            Playlist playlistToDelete =repository.Playlists.FindById(id);
            repository.Playlists.Delete(playlistToDelete);

        }

        public void AddNewSongToPlaylist(Song song, int idPlaylist)
        {
            Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
            Playlist playlist = repository.Playlists.FindById(idPlaylist);
            playlist.Songs.Add(song);
            if (song.Categories != null)
            {
                foreach (var category in song.Categories)
                {
                    if (!playlist.Categories.Contains(category))
                        playlist.Categories.Add(category);
                }
            }
            repository.Playlists.Update(oldPlaylist, playlist);
        }

        public void  AssociateSongToPlaylist(int idSong, int idPlaylist)
        {
            Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
            Playlist playlist = repository.Playlists.FindById(idPlaylist);
            Song song = repositorySong.Songs.FindById(idSong);
            playlist.Songs.Add(song);
            repository.Playlists.Update(oldPlaylist, playlist);
        }

        public Playlist GetPlaylistById(int id)
        {
            return repository.Playlists.FindById(id);
        }

    }
}