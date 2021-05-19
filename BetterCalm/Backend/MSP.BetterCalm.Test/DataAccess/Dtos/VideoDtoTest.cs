using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.Test
{
    [TestClass]
    public class VideoDtoTest
    {
        
        [TestMethod]
        public void GetSetVideoId()
        {
            VideoDto Video = new VideoDto();
            Video.VideoDtoID = 1;
            Assert.AreEqual(1, Video.VideoDtoID);
        }
        
        [TestMethod]
        public void GetSetVideoName()
        {
            string VideoName = "Let it be";
            VideoDto Video = new VideoDto();
            Video.Name = "Let it be";
            string getVideoName = Video.Name;
            Assert.AreEqual(VideoName, getVideoName);
        }
        
        [TestMethod]
        public void GetSetVideoUrlArchive()
        {
            string UrlArchiveName = "UrlArchiveName";
            VideoDto Video = new VideoDto();
            Video.UrlArchive = "UrlArchiveName";
            string getVideoUrlArchive = Video.UrlArchive;
            Assert.AreEqual(UrlArchiveName, getVideoUrlArchive);
        }

        [TestMethod]
        public void GetSetVideoDuration()
        {
            double duration = 23 ;
            VideoDto Video = new VideoDto();
            Video.Duration = 23;
            double getVideoDuration = Video.Duration;
            Assert.AreEqual(duration, getVideoDuration);
        }
        
        [TestMethod]
        public void GetSetVideoCreatorName()
        {
            string CreatorName = "Paul McCartney";
            VideoDto Video = new VideoDto();
            Video.CreatorName = CreatorName;
            string getCreatorName= Video.CreatorName;
            Assert.AreEqual(CreatorName, getCreatorName);
        }
        
        [TestMethod]
        public void GetSetPlaylistVideoDto()
        {
            VideoDto video = new VideoDto();
            video.PlaylistVideosDto = new List<PlaylistVideoDto>();
            ICollection<PlaylistVideoDto> getPlaylistVideo= video.PlaylistVideosDto;
            CollectionAssert.AreEqual(getPlaylistVideo.ToList(), new List<PlaylistVideoDto>());
        }
    }
}