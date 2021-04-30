using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/Song")]
    public class SongController : ControllerBase
    {

        private ISongService _songService;

        public SongController(ISongService songService)
        {
            this._songService = songService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Song> songs = _songService.GetSongs();
            return Ok(songs);
        }

        [HttpGet("name")]
        public IActionResult GetSongsByName([FromQuery] string name)
        {
            List<Song> songs = _songService.GetSongsByName(name);
            return Ok(songs);
        }

        [HttpGet("author")]
        public IActionResult GetSongsByAuthor([FromQuery] string author)
        {
            List<Song> songs = _songService.GetSongsByAuthor(author);
            return Ok(songs);
        }


        [HttpGet("category/name")]
        public IActionResult GetSongsByCategoryName([FromQuery] string name)
        {
            List<Song> songs = _songService.GetSongsByCategoryName(name);
            return Ok(songs);
        }


        [HttpGet("{id}")]
        public IActionResult GetSongById([FromRoute] int id)
        {
            Song songById = _songService.GetSongById(id);
            SongDto song = new SongDto().CreateSongDto(songById);
            return Ok(song);
        }

        
        [HttpPost]
        public IActionResult CreateSong([FromBody] SongDto song)
        {
            _songService.AddSong(song.CreateSong());
            return Ok("Song created");
        }

        [HttpDelete()]
        public IActionResult DeleteSong([FromBody] Song song)
        {
            _songService.DeleteSong(song.Id);
            return Ok("Song removed");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteSong([FromRoute] int id)
        {
            _songService.DeleteSong(id);
            return Ok("Song removed");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSong([FromRoute] int id, [FromBody] Song songUpdated)
        {
            _songService.UpdateSongById(id, songUpdated);
            return Ok("Song Updated");
        }
    }
}