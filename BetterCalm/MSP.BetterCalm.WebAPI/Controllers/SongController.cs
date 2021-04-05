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
            Song song = this.songLogic.GetSongByName(Name);
            return Ok(song);
        }
        
        [HttpGet("{authorName}")]
        public IActionResult GetSongByAuthor([FromRoute]string authorName)
        {
            Song song = this.songLogic.GetSongByAuthor(authorName);
            return Ok(song);
        }
        
        [HttpGet("{categoryName}")]
        public IActionResult GetSongByCategoryName([FromRoute]string categoryName)
        {
            List<Song> songs = this.songLogic.GetSongsByCategoryName(categoryName);
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