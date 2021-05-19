namespace MSP.BetterCalm.DataAccess
{
    public class PlaylistAudioDto
    {
        public int AudioID { get; set; }
        
        public AudioDto AudioDto{ get; set; }

        public int PlaylistID { get; set; }

        public PlaylistDto PlaylistDto { get; set; }
    }
}