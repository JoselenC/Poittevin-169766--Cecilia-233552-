using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface ISongService
    {
        public List<Song> GetSongs();
        public void SetSong(Song song);
        public List<Song> GetSongsByName(string songName);
        public List<Song> GetSongsByAuthor(string authorName);
        public List<Song> GetSongsByCategoryName(string categoryName);
        public void DeleteSong(int id);
        public Song GetSongByNameAndAuthor(string name, string author);
        void DeleteSongs(List<Song> playlistSongs);
        public Song GetSongById(int id);
        public void UpdateSongById(int id, Song songUpdated);
    }
}