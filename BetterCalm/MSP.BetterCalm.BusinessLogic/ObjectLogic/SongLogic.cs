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
        
        public void UpdateSong(Song oldSong,Song newSong)
        {
            repository.Songs.Update(oldSong,newSong);
        }
        
        public Song GetSongByName(string songName)
        {
            try{
            return repository.Songs.Find(x=>x.IsSameSongName(songName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindSongByName();
            }
        }

        public Song GetSongByAuthor(string authorName)
        {
            try{
            return repository.Songs.Find(x=>x.IsSameAuthorName(authorName));
            }
            catch (ValueNotFound)
            {
                throw new NoFindSongByAuthor();
            }
        }
    }
}
    