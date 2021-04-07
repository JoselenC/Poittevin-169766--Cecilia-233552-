using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class SongLogic:ISongLogic
    {
        private ManagerSongRepository repository;

        public SongLogic(ManagerSongRepository vRepository)
        {
            repository = vRepository;
        }
        
        public List<Song> GetSongs()
        {
            return repository.Songs.Get();
        }            

        public void SetSong(Song song)
        {
            repository.Songs.Add(song);
        }
        public List<Song> GetSongsByName(string songName)
        {
            List<Song> songs = new List<Song>();
            foreach (var song in repository.Songs.Get())
            {
                if(song.IsSameSongName(songName))
                    songs.Add(song);
            }
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
            return songs;
        }

        public Song GetSongByNameAndAuthor(string name, string author)
        {
            try
            {
                return repository.Songs.Find(x => x.IsSameSongName(name) &&
                                                  x.IsSameAuthorName(author));
            }
            catch (ValueNotFound)
            {
                throw new NoFindSongByNameAndAuthor();
            }
        }

        public void UpdateSong(Song songToUpdate, Song songUpdated)
        {
            repository.Songs.Update(songUpdated, songUpdated);
        }
        public void DeleteSong(Song song)
        {
            repository.Songs.Delete(song);
        }

        public void DeleteSongByNameAndAuthor(string name,string authorName)
        {
            Song song = repository.Songs.Find(x => x.IsSameSongName(name) && 
                                                   x.IsSameAuthorName(authorName));
            repository.Songs.Delete(song);
        }
    }
}
    