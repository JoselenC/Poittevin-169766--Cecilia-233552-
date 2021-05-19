using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public interface IVideoService 
    {
        public List<Video> GetVideos();
        public Video SetVideo(Video video);
        public List<Video> GetVideosByName(string videoName);
        public List<Video> GetVideosByAuthor(string authorName);
        public List<Video> GetVideosByCategoryName(string categoryName);
        public void DeleteVideo(int id);
        public Video GetVideoById(int id);
        public void UpdateVideoById(int id, Video videoUpdated);
    }
}