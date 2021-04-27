using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PlaylistService:IPlaylistService
    {
        private ManagerPlaylistRepository repository;

        public PlaylistService(ManagerPlaylistRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Playlist> GetPlaylist()
        {
            return repository.Playlists.Get();
        }

        public void AddPlaylist(Playlist playlist)
        {
            try
            {
                try
                {
                    Playlist newPlaylist = playlist;
                    if (playlist.Songs != null)
                    {
                        AddSongCategories(playlist.Songs, newPlaylist);
                    }

                    repository.Playlists.Add(newPlaylist);
                }
                catch (InvalidNameLength)
                {
                    throw new InvalidNameLength();
                }
            }
            catch (InvalidDescriptionLength)
            {
                throw new InvalidDescriptionLength();
            }
        }

        private void AddSongCategories(List<Song> playlistSongs,Playlist newPlaylist)
        {
            foreach (var song in playlistSongs)
            {
                
                if (song.Categories != null)
                {
                    foreach (var category in song.Categories)
                    {
                        if (newPlaylist.Categories.Contains(category))
                            newPlaylist.Categories.Add(category);
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
        
        public void DeletePlaylistByName(string name)
        {
            Playlist playlistToDelete=repository.Playlists.Find(x => x.IsSamePlaylistName(name));
            DeletePlaylist(playlistToDelete);
        }
        
        public void DeletePlaylist(Playlist playlistToDelete)
        {
            repository.Playlists.Delete(playlistToDelete);
        }
    }
}