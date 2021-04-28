namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistSongDto
    {
        public int SongID { get; set; }
        
        public SongDto SongDto{ get; set; }

        public int PlaylistID { get; set; }

        public PlaylistDto PlaylistDto { get; set; }
    }
}