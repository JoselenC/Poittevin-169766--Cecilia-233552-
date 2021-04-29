using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
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
        public IActionResult GetSongsByName([FromQuery]string name)
        {
            try
            {
                List<Song> songs = _songService.GetSongsByName(name);
                return Ok(songs);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found songs by this name");
            }
        }
        
        [HttpGet("author")]
        public IActionResult GetSongsByAuthor([FromQuery]string author)
        {
            try
            {
                List<Song> songs = _songService.GetSongsByAuthor(author);
                return Ok(songs);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found songs by this author name");
            }
        }
        
        
        [HttpGet("category/name")]
        public IActionResult GetSongsByCategoryName([FromQuery]string name)
        {
            try
            {
                List<Song> songs = _songService.GetSongsByCategoryName(name);
                return Ok(songs);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found song by category name");
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult GetSongById([FromRoute] int id)
        {
            try
            {
                Song songById = _songService.GetSongById(id);
                SongDto song = new SongDto().CreateSongDto(songById);
                return Ok(song);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found song by this id");
            }
        }

        [HttpPost]
        public IActionResult CreateSong([FromBody] SongDto song)
        {
            try
            {
                _songService.AddSong(song.CreateSong());
                return Ok("Song created");
            }
            catch (AlreadyExistThisSong)
            {
                return Conflict("This song is already registered in the system");
            }
            catch (InvalidNameLength)
            {
                return Conflict("Cannot add a song with an empty name ");
            }
            catch (InvalidDurationFormat)
            {
                return Conflict("Invalid duration format");
            }
        }

        [HttpDelete()]
        public IActionResult DeleteSong([FromBody] Song song)
        {
            try
            {
                _songService.DeleteSong(song.Id);
                return Ok("Song removed");
            }
            catch (KeyNotFoundException)
            {
                return Conflict("This song not registered in the system");
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteSong([FromRoute] int id)
        {
            try
            {
                _songService.DeleteSong(id);
                return Ok("Song removed");
            }
            catch (KeyNotFoundException)
            {
                return Conflict("This song not registered in the system");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSong([FromRoute] int id,[FromBody] Song songUpdated)
        {
            try
            {
                _songService.UpdateSongById(id,songUpdated);
                return Ok("Song Updated");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("This song not registered in the system");
            }
        }
    }
}