using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class SongService:ISongService
    {
        private ManagerSongRepository repository;

        public SongService(ManagerSongRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Song> GetSongs()
        {
            return repository.Songs.Get();
        }

        private bool AlreadyExistThisSong(Song song)
        {
            try
            {
                repository.Songs.FindById(song.Id);
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
                
        }

        public void AddSong(Song song)
        {
            if (!AlreadyExistThisSong(song))
                repository.Songs.Add(song);
            else
                throw new AlreadyExistThisSong();
        }

        public List<Song> GetSongsByName(string songName)
        {
            List<Song> songs = new List<Song>();
            foreach (var song in repository.Songs.Get())
            {
                if(song.IsSameSongName(songName))
                    songs.Add(song);
            }

            if (songs.Count == 0)
                throw new KeyNotFoundException();
            return songs;
        }

        public List<Song> GetSongsByAuthor(string authorName)
        {
            List<Song> songs = new List<Song>();
            foreach (var song in repository.Songs.Get())
            {
                if(song.IsSameAuthorName(authorName))
                    songs.Add(song);
            }
            if (songs.Count == 0)
                throw new KeyNotFoundException();
            return songs;
        }

        public List<Song> GetSongsByCategoryName(string categroyName)
        {
            List<Song> songs = new List<Song>();
            foreach (Song song in repository.Songs.Get())
            {
                if(song.IsSameCategoryName(categroyName))
                    songs.Add(song);
            }
            if (songs.Count == 0)
                throw new KeyNotFoundException();
            return songs;
        }

        public Song GetSongByNameAndAuthor(string name, string author)
        {
            return repository.Songs.Find(x => x.IsSameSongName(name) && x.IsSameAuthorName(author));
        }
        
        public void UpdateSongById(int id, Song songUpdated)
        {

            Song songToUpdate = repository.Songs.FindById(id);
            repository.Songs.Update(songToUpdate, songUpdated);

        }
        public void DeleteSongs(List<Song> playlistSongs)
        {
            if (playlistSongs != null)
            {
                foreach (var song in playlistSongs)
                {
                    DeleteSong(song.Id);
                }
            }
        }

       public void DeleteSong(int id)
        {

            Song songToDelete = repository.Songs.FindById(id);
            repository.Songs.Delete(songToDelete);

        }
       
        public Song GetSongById(int id)
        {
            return repository.Songs.FindById(id);
        }
    }
}
    