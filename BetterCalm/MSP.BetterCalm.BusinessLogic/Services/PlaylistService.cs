using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PlaylistService:IPlaylistService
    {
        private ManagerPlaylistRepository repository;
        private ManagerAudioRepository _repositoryAudio;
        public PlaylistService(ManagerPlaylistRepository vRepository,ManagerAudioRepository vRepositoryAudio)
        {
            _repositoryAudio = vRepositoryAudio;
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

            if (playlists.Count == 0)
                throw new NotFoundPlaylist();
            return playlists;
        }

        public List<Playlist> GetPlaylistByAudioName(string audioName)
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in repository.Playlists.Get())
            {
                if(playlist.IsSameAudioName(audioName))
                    playlists.Add(playlist);
            }
            if (playlists.Count == 0)
                throw new NotFoundPlaylist();
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
                throw new NotFoundPlaylist();
            return playlists;
        }

        public void UpdatePlaylist(Playlist playlistToUpdate, Playlist newPlaylist)
        {
            repository.Playlists.Update(playlistToUpdate, newPlaylist);
        }

        public void UpdatePlaylistById(int id, Playlist newPlaylist)
        {
            try
            {
                Playlist playlistToUpdate = repository.Playlists.FindById(id);
                repository.Playlists.Update(playlistToUpdate, newPlaylist);
            }
            catch (KeyNotFoundException)
            {
                throw new ObjectWasNotUpdated();
            }
        }

        public void DeletePlaylistByName(string name)
        {
            Playlist playlistToDelete=repository.Playlists.Find(x => x.IsSamePlaylistName(name));
            DeletePlaylist(playlistToDelete.Id);
        }

        public void DeletePlaylist(int id)
        {
            try
            {
                Playlist playlistToDelete = repository.Playlists.FindById(id);
                repository.Playlists.Delete(playlistToDelete);
            }
            catch (KeyNotFoundException)
            {
                throw new ObjectWasNotDeleted();
            }
        }

        public void AddNewAudioToPlaylist(Audio audio, int idPlaylist)
        {
            Playlist playlist = repository.Playlists.FindById(idPlaylist);
            Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
            playlist.Audios.Add(audio);
            repository.Playlists.Update(oldPlaylist, playlist);
        }

        public void  AssociateAudioToPlaylist(int idAudio, int idPlaylist)
        {
            Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
            Playlist playlist = repository.Playlists.FindById(idPlaylist);
            Audio audio = _repositoryAudio.Audios.FindById(idAudio);
            playlist.Audios.Add(audio);
            repository.Playlists.Update(oldPlaylist, playlist);
        }

        public Playlist GetPlaylistById(int id)
        {
            try{
            return repository.Playlists.FindById(id);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }

    }
}