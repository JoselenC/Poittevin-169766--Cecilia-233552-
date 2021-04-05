using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Song")]
    public class SongController : ControllerBase
    {

        private ISongLogic songLogic;

        public SongController(ISongLogic songLogic)
        {
            this.songLogic = songLogic;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Song> songs = this.songLogic.GetSongs();
            return Ok(songs);
        }
        
        [HttpGet("{Name}")]
        public IActionResult GetSongByName([FromRoute]string Name)
        {
            Song songs = this.songLogic.GetSongByName(Name);
            return Ok(songs);
        }
        
        [HttpGet("{authorName}")]
        public IActionResult GetSongByAuthor([FromRoute]string authorName)
        {
            Song songs = this.songLogic.GetSongByAuthor(authorName);
            return Ok(songs);
        }
        
        [HttpPost]
        public IActionResult CreateSong([FromBody] Song song)
        {
            songLogic.SetSong(song);
            return Ok();
        }
        
    }
}