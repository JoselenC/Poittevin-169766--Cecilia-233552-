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
        private ISongService _songService;

        public PlaylistController(IPlaylistService playlistService,ISongService songService)
        {
            this._playlistService = playlistService;
            this._songService = songService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Playlist> songs = _playlistService.GetPlaylist();
            return Ok(songs);
        }

        [HttpGet("playListName/{name}")]
        public IActionResult GetPlaylistByName([FromRoute] string name)
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetPlaylistByName(name);
                return Ok(playlists);
            }
            catch (ValueNotFound)
            {
                return NotFound("Not found playlist by this name");
            }

        }

        [HttpGet("categoryName/{name}")]
        public IActionResult GetPlaylistByCategoryName([FromRoute] string name)
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetPlaylistByCategoryName(name);
                return Ok(playlists);
            }
            catch (ValueNotFound)
            {
                return NotFound("Not found playlist by this category name");
            }

        }

        [HttpGet("songName/{name}")]
        public IActionResult GetPlaylistBySongName([FromRoute] string name)
        {
            try
            {
                List<Playlist> playlists = _playlistService.GetPlaylistBySongName(name);
                return Ok(playlists);
            }
            catch (ValueNotFound)
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
                    _songService.DeleteSongs(playlist.Songs);
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


        [HttpDelete()]
        public IActionResult DeletePlaylist([FromBody] Playlist playlist)
        {
            try
            {
                _playlistService.DeletePlaylist(playlist);
                return Ok("Element removed");
            }
            catch (ValueNotFound)
            {
                return NotFound("This playlist not registered in the system");
            }
        }

        [HttpPost ("playlitName/{name}")]
        public IActionResult AddSongToPlaylist([FromBody] Song song, [FromRoute] string name)
        {
           
            List<Playlist> playlistsToUpdate = _playlistService.GetPlaylistByName(name);
            foreach (var playlistToUpdate in playlistsToUpdate)
            {
                Playlist playlist = playlistToUpdate;
                playlistToUpdate.Songs.Add(song);
                _playlistService.UpdatePlaylist(playlistToUpdate,playlist);
            }
          
            return Ok();
        }
       
    }
}