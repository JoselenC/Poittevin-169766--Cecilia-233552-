namespace MSP.BetterCalm.DataAccess.DtoObjects
{
    public class PlaylistContentDto
    {
        public int ContentId { get; set; }
        
        public ContentDto ContentDto{ get; set; }

        public int PlaylistId { get; set; }

        public PlaylistDto PlaylistDto { get; set; }
    }
}