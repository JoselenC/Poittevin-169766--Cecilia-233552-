using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Managers;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Services
{
    public class PlaylistService:IPlaylistService
    {
        private ManagerPlaylistRepository repository;
        private ManagerContentRepository _repositoryContent;
        public PlaylistService(ManagerPlaylistRepository vRepository,ManagerContentRepository vRepositoryContent)
        {
            _repositoryContent = vRepositoryContent;
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

        public List<Playlist> GetPlaylistByContentName(string ContentName)
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in repository.Playlists.Get())
            {
                if(playlist.IsSameContentName(ContentName))
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
            playlist.Contents = new List<Content>();
            playlist.Categories = newPlaylist.Categories;
            if (newPlaylist.Contents != null)
            {
                foreach (var Content in newPlaylist.Contents)
                {
                    if (Content.Id == 0)
                    {
                        Content contentAdd = _repositoryContent.Contents.Add(Content);
                        playlist.Contents.Add(contentAdd);
                    }
                    else
                        playlist.Contents.Add(Content);
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

        public Content AddNewContentToPlaylist(Content content, int idPlaylist)
        {
            try
            {
                Playlist playlist = repository.Playlists.FindById(idPlaylist);
                AddCategoriesToSong(content, playlist);
                Content contentToadd = _repositoryContent.Contents.Add(content);
                Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
                oldPlaylist.Contents.Add(contentToadd);
                UpdatePlaylist(playlist, oldPlaylist);
                return _repositoryContent.Contents.FindById(contentToadd.Id);
            }
            catch (KeyNotFoundException)
            {
                throw new NotFoundId();
            }
        }

        private void AddCategoriesToSong(Content content, Playlist playlist)
        {
            if (playlist.Categories != null)
            {
                if (content.Categories == null) content.Categories = new List<Category>();
                foreach (var category in playlist.Categories)
                {
                    content.Categories.Add(category);
                }
            }
        }

        public Playlist AssociateContentToPlaylist(int idContent, int idPlaylist)
        {
            try
            {
                Playlist oldPlaylist = repository.Playlists.FindById(idPlaylist);
                Playlist playlist = repository.Playlists.FindById(idPlaylist);
                Content contentById = _repositoryContent.Contents.FindById(idContent);
                playlist.Contents.Add(contentById);
                return repository.Playlists.Update(oldPlaylist, playlist);
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