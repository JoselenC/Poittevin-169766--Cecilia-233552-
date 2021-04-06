using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface ISongLogic
    {
        public List<Song> GetSongs();
        public void SetSong(Song song);
        public Song GetSongByName(string songName);
        public Song GetSongByAuthor(string authorName);
        List<Song> GetSongsByCategoryName(string categoryName);
    }
}