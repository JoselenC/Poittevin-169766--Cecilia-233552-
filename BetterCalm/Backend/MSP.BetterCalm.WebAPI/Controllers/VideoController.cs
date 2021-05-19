using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/Video")]
    public class VideoController : ControllerBase
    {
        private IVideoService _videoService;
        public VideoController(IVideoService VideoService)
        {
            this._videoService = VideoService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Video> videos = _videoService.GetVideos();
            List<VideoDto> videoDtos = videos.Select(video => new VideoDto().CreateVideoDto(video)).ToList();
            return Ok(videoDtos);
        }

        [HttpGet("name")]
        public IActionResult GetVideosByName([FromQuery] string name)
        {
            List<Video> videos = _videoService.GetVideosByName(name);
            List<VideoDto> videoDtos = videos.Select(video => new VideoDto().CreateVideoDto(video)).ToList();
            return Ok(videoDtos);
        }

        [HttpGet("author")]
        public IActionResult GetVideosByAuthor([FromQuery] string author)
        {
            List<Video> videos = _videoService.GetVideosByAuthor(author);
            List<VideoDto> videoDtos = videos.Select(video => new VideoDto().CreateVideoDto(video)).ToList();
            return Ok(videoDtos);        
        }


        [HttpGet("Category")]
        public IActionResult GetVideosByCategoryName([FromQuery] string name)
        {
            List<Video> videos = _videoService.GetVideosByCategoryName(name);
            List<VideoDto> videoDtos = videos.Select(video => new VideoDto().CreateVideoDto(video)).ToList();
            return Ok(videoDtos);
        }


        [HttpGet("{id}")]
        public IActionResult GetVideoById([FromRoute] int id)
        {
            Video videoById = _videoService.GetVideoById(id);
            VideoDto video = new VideoDto().CreateVideoDto(videoById);
            return Ok(video);
        }

        
        [HttpPost]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult CreateVideo([FromBody] VideoDto video)
        {
            Video videoAdded = _videoService.SetVideo(video.CreateVideo());
            VideoDto videoDto = new VideoDto().CreateVideoDto(videoAdded);
            return Created($"api/Video/{videoAdded.Name}", videoDto);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult DeleteVideo([FromRoute] int id)
        {
            _videoService.DeleteVideo(id);
            return Ok("Video removed");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult UpdateVideo([FromRoute] int id, [FromBody] VideoDto videoUpdated)
        {
            _videoService.UpdateVideoById(id, videoUpdated.CreateVideo());
            return Ok("Video Updated");
        }
    }
}