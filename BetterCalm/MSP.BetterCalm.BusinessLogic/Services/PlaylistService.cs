using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public Playlist SetPlaylist(Playlist playlist)
        {
            return repository.Playlists.Add(playlist);
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
                Playlist playlist = CreateNewPlaylist(id, newPlaylist);
                repository.Playlists.Update(playlistToUpdate, playlist);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundPlaylist();
            }
        }

        private Playlist CreateNewPlaylist(int id, Playlist newPlaylist)
        {
            Playlist playlist = new Playlist();
            playlist.Name = newPlaylist.Name;
            playlist.Description = newPlaylist.Description;
            playlist.Id = id;
            playlist.UrlImage = newPlaylist.UrlImage;
            playlist.Audios = new List<Audio>();
            playlist.Categories = newPlaylist.Categories;
            if (newPlaylist.Audios != null)
            {
                foreach (var audio in newPlaylist.Audios)
                {
                    if (audio.Id == 0)
                    {
                        Audio audioAdd = _repositoryAudio.Audios.Add(audio);
                        playlist.Audios.Add(audioAdd);
                    }
                    else
                        playlist.Audios.Add(audio);
                }
            }
            return playlist;
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
                throw new NotFoundPlaylist();
            }
        }

        public Audio AddNewAudioToPlaylist(Audio audio, int idPlaylist)
        {
            try
            {
                Playlist playlist = repository.Playlists.FindById(idPlaylist);
                if (playlist.Categories != null)
                {
                    if (audio.Categories == null) audio.Categories = new List<Category>();
                    foreach (var category in playlist.Categories)
                    {
                        audio.Categories.Add(category);
                    }
                }

                Audio audioToadd = _repositoryAudio.Audios.Add(audio);
                Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
                oldPlaylist.Audios.Add(audioToadd);
                UpdatePlaylist(playlist, oldPlaylist);
                return _repositoryAudio.Audios.FindById(audioToadd.Id);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }

        public void  AssociateAudioToPlaylist(int idAudio, int idPlaylist)
        {
            try
            {
                Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
                Playlist playlist = repository.Playlists.FindById(idPlaylist);
                Audio audioById = _repositoryAudio.Audios.FindById(idAudio);
                playlist.Audios.Add(audioById);
                repository.Playlists.Update(oldPlaylist, playlist);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }

        public Playlist GetPlaylistById(int id)
        {
            try
            {
                return repository.Playlists.FindById(id);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }

    }
}