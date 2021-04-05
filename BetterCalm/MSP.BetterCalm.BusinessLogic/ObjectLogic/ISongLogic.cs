using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface ISongLogic
    {
        public List<Song> GetSongs();

        public void SetSong(Song song);
        
        public void UpdateSong(Song oldSong, Song newSong);

        public Song GetSongByName(string songName);
        public Song GetSongByAuthor(string authorName);
    }
}