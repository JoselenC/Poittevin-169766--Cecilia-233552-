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
            List<Song> songs = this.songLogic.GetSongsByName(Name);
            return Ok(songs);
        }
        
        [HttpGet("authorName/{author}")]
        public IActionResult GetSongByAuthor([FromRoute]string author)
        {
            List<Song> songs = this.songLogic.GetSongsByAuthor(author);
            return Ok(songs);
        }
        
        [HttpGet("authorName/{author}/songName/{name}")]
        public IActionResult GetSongByAuthorAndName([FromRoute]string name,string author)
        {
            Song song = this.songLogic.GetSongByNameAndAuthor(name,author);
            return Ok(song);
        }
        
        [HttpGet("categoryName/{name}")]
        public IActionResult GetSongByCategoryName([FromRoute]string name)
        {
            List<Song> songs = this.songLogic.GetSongsByCategoryName(name);
            return Ok(songs);
        }
        
        [HttpPost]
        public IActionResult CreateSong([FromBody] Song song)
        {
            songLogic.SetSong(song);
            return Ok("Song created");
        }
          
        [HttpDelete()]
        public IActionResult DeleteSong([FromBody] Song song)
        {
            songLogic.DeleteSong(song);
            return Ok("Song removed");
        }

        [HttpGet("song/{name}/author/{author}")]
        public IActionResult DeleteSongByNameAndAuthor([FromRoute] string name,string author)
        {
            songLogic.DeleteSongByNameAndAuthor(name,author);
            return Ok("Song removed");
        }

        [HttpGet("songName/{name}/authorName/{author}")]
        public IActionResult UpdateSong([FromRoute] string name,string author,[FromBody] Song songUpdated)
        {
            Song songToUpdate = songLogic.GetSongByNameAndAuthor(name, author);
            songLogic.UpdateSong(songToUpdate,songUpdated);
            return Ok("Song Updated");
        }
        
    }
}