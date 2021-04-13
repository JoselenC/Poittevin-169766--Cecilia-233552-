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
            foreach (var songGet in repository.Songs.Get())
            {
                if (songGet.IsSameSongName(song.Name) && 
                    songGet.IsSameAuthorName(song.AuthorName))
                    return true;
            }

            return false;
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

        public void UpdateSong(Song songToUpdate, Song songUpdated)
        {
            try
            {
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
                    DeleteSong(song);
                }
            }
        }

        public void DeleteSong(Song song)
        {
            try
            {
                repository.Songs.Delete(song);
            }
            catch (ValueNotFound)
            {
                throw new ValueNotFound();
            }
        }

        public void DeleteSongByNameAndAuthor(string name,string authorName)
        {
            try
            {
                Song song = repository.Songs.Find(x => x.IsSameSongName(name) &&
                                                       x.IsSameAuthorName(authorName));
                repository.Songs.Delete(song);
            }
            catch (ValueNotFound)
            {
                throw new ValueNotFound();
            }
        }
    }
}
    