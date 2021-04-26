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
            catch (ValueNotFound)
            {
                return false;
            }
                
        }
        public void SetSong(Song song)
        {
            try
            {
                if (!AlreadyExistThisSong(song))
                    repository.Songs.Add(song);
                else
                    throw new AlreadyExistThisSong();
            }
            catch (InvalidNameLength)
            {
                throw new InvalidNameLength();
            }

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
                throw new ValueNotFound();
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
                throw new ValueNotFound();
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
                throw new ValueNotFound();
            return songs;
        }

        public Song GetSongByNameAndAuthor(string name, string author)
        {
            try
            {
                return repository.Songs.Find(x => x.IsSameSongName(name) && x.IsSameAuthorName(author));
            }
            catch (ValueNotFound)
            {
                throw new ValueNotFound();
            }
        }
        
        public void UpdateSongById(int id, Song songUpdated)
        {
            try
            {
                Song songToUpdate = repository.Songs.FindById(id);
                repository.Songs.Update(songToUpdate, songUpdated);
            }
            catch (ValueNotFound)
            {
                throw new ValueNotFound();
            }
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
            try
            {
                Song songToDelete = repository.Songs.FindById(id);
                repository.Songs.Delete(songToDelete);
            }
            catch (ValueNotFound)
            {
                throw new ValueNotFound();
            }
        }
       
        public Song GetSongById(int id)
        {
            try
            {
                return repository.Songs.FindById(id);
            }
            catch (ValueNotFound)
            {
                throw new ValueNotFound();
            }

        }
    }
}
    