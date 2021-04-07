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
        
        [HttpGet("{authorName}")]
        public IActionResult GetSongByAuthor([FromRoute]string authorName)
        {
            List<Song> songs = this.songLogic.GetSongsByAuthor(authorName);
            return Ok(songs);
        }
        
        [HttpGet("{Name}{authorName}")]
        public IActionResult GetSongByAuthorAndName([FromRoute]string name,string authorName)
        {
            Song song = this.songLogic.GetSongByNameAndAuthor(name,authorName);
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
          
        [HttpDelete()]
        public IActionResult DeleteSong([FromBody] Song song)
        {
            songLogic.DeleteSong(song);
            return Ok("Element removed");
        }

        [HttpDelete("{name}{author}")]
        public IActionResult DeleteSongByNameAndAuthor([FromRoute] string name,string author)
        {
            songLogic.DeleteSongByNameAndAuthor(name,author);
            return Ok("Element removed");
        }

        [HttpPut("{name}{author}")]
        public IActionResult UpdateSong([FromRoute] string name,string author,[FromBody] Song songUpdated)
        {
            Song songToUpdate = songLogic.GetSongByNameAndAuthor(name, author);
            songLogic.UpdateSong(songToUpdate,songUpdated);
            return Ok("Element Updated");
        }
        
    }
}