using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/Playlist")]
    public class PlaylistController : ControllerBase
    {

        private IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Playlist> Audios = _playlistService.GetPlaylist();
            return Ok(Audios);
        }

        [HttpGet("name")]
        public IActionResult GetPlaylistByName([FromQuery] string name)
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetPlaylistByName(name);
                return Ok(playlists);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found playlist by this name");
            }

        }
        
        [HttpGet("{id}")]
        public IActionResult GetPlaylistById([FromRoute] int id)
        {
            try
            {
                Playlist playlists = _playlistService.GetPlaylistById(id);
                return Ok(playlists);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found playlist by this id");
            }

        }

        [HttpGet("category/name")]
        public IActionResult GetPlaylistByCategoryName([FromQuery] string name)
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetPlaylistByCategoryName(name);
                return Ok(playlists);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found playlist by this category name");
            }

        }

        [HttpGet("audio/name")]
        public IActionResult GetPlaylistByAudioName([FromQuery] string name)
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetPlaylistByAudioName(name);
                return Ok(playlists);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found playlist by this audio name");
            }
        }

        [HttpPost]
        public IActionResult CreatePlaylist([FromBody] Playlist playlist)
        {
            try
            {
                _playlistService.AddPlaylist(playlist);
                return Ok("Playlist created");
            }
            catch (InvalidNameLength)
            {
                return Conflict("Cannot add a playlist with an empty name");
            }
            catch (InvalidDescriptionLength)
            {
                return Conflict("You cannot add a playlist with an empty description or a length greater than 150");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlaylist([FromRoute] int id)
        {
            try
            {
                _playlistService.DeletePlaylist(id);
                return Ok("Element removed");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("This playlist not registered in the system");
            }
        }

        [HttpPost ("{id}")]
        public IActionResult AddNewAudioToPlaylist([FromBody] Audio audio, [FromRoute] int id)
        {

            _playlistService.AddNewAudioToPlaylist(audio, id);
            return Ok("New audio was added to the playlist");
        }
        
        [HttpPost ("{idPlaylist}/Audios/{id}")]
        public IActionResult AssociateAudioToPlaylist([FromRoute] int id, int idPlaylist)
        {
           
            _playlistService.AssociateAudioToPlaylist(id,idPlaylist);
            return Ok("The audio was added to the playlist");
        }
        
        [HttpPut ("{id}")]
        public IActionResult UpdatePlaylist([FromRoute] int id, [FromBody] Playlist newPlaylist)
        {
            try
            {
                _playlistService.UpdatePlaylistById(id,newPlaylist);
                return Ok("The audio was updated");
            }
            catch (Exception e)
            {
                return NotFound("This playlist not registered in the system");
            }
            
        }
       
    }
}