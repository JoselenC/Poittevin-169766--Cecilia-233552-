using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface ISongLogic
    {
        public List<Song> GetSongs();
        public void SetSong(Song song);
        public List<Song> GetSongsByName(string songName);
        public List<Song> GetSongsByAuthor(string authorName);
        public List<Song> GetSongsByCategoryName(string categoryName);
        public void DeleteSong(Song song);
        public void DeleteSongByNameAndAuthor(string name,string authorName);
        public Song GetSongByNameAndAuthor(string name, string author);
        public void UpdateSong(Song songToUpdate, Song songUpdated);
        void DeleteSongs(List<Song> playlistSongs);
    }
}