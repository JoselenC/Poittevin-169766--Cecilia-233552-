using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PlaylistLogic:IPlaylistLogic
    {
        private ManagerPlaylistRepository repository;

        public PlaylistLogic(ManagerPlaylistRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Playlist> GetPlaylist()
        {
            return repository.Playlists.Get();
        }

        public void AddPlaylist(Playlist playlist)
        {
           repository.Playlists.Add(playlist);
        }

        public List<Playlist> GetPlaylistByName(string playlistName)
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in repository.Playlists.Get())
            {
                if(playlist.IsSamePlaylistName(playlistName))
                    playlists.Add(playlist);
            }
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
            return playlists;
        }

        public void UpdatePlaylist(Playlist playlistToUpdate, Playlist newPlaylist)
        {
            repository.Playlists.Update(playlistToUpdate, newPlaylist);
        }
        
        public void DeletePlaylistByName(string name)
        {
            Playlist playlistToDelete=repository.Playlists.Find(x => x.IsSamePlaylistName(name));
            repository.Playlists.Delete(playlistToDelete);
        }
        
        public void DeletePlaylist(Playlist playlistToDelete)
        {
            repository.Playlists.Delete(playlistToDelete);
        }
    }
}