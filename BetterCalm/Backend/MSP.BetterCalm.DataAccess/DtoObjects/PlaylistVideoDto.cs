namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistVideoDto
    {
        public int VideoID { get; set; }
        
        public VideoDto VideoDto{ get; set; }

        public int PlaylistID { get; set; }

        public PlaylistDto PlaylistDto { get; set; }
    }
}