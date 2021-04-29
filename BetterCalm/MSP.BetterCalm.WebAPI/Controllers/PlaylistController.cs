using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
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
            IEnumerable<Playlist> songs = _playlistService.GetPlaylist();
            return Ok(songs);
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

        [HttpGet("song/name")]
        public IActionResult GetPlaylistBySongName([FromQuery] string name)
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetPlaylistBySongName(name);
                return Ok(playlists);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Not found playlist by this song name");
            }
        }

        [HttpPost]
        public IActionResult CreatePlaylist([FromBody] Playlist playlist)
        {
            try
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
        public IActionResult AddNewSongToPlaylist([FromBody] Song song, [FromRoute] int id)
        {

            _playlistService.AddNewSongToPlaylist(song, id);
            return Ok("New song was added to the playlist");
        }
        
        [HttpPost ("{idPlaylist}/Songs/{id}")]
        public IActionResult AssociateSongToPlaylist([FromRoute] int id, int idPlaylist)
        {
           
            _playlistService.AssociateSongToPlaylist(id,idPlaylist);
            return Ok("The song was added to the playlist");
        }
        
        [HttpPut ("{id}")]
        public IActionResult UpdatePlaylist([FromRoute] int id, [FromBody] Playlist newPlaylist)
        {
            try
            {
                _playlistService.UpdatePlaylistById(id,newPlaylist);
                return Ok("The song was updated");
            }
            catch (Exception e)
            {
                return NotFound("This playlist not registered in the system");
            }
            
        }
       
    }
}