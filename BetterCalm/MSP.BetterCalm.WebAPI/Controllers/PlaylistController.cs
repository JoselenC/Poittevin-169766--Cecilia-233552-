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

        private IPlaylistLogic playlistLogic;
        private ISongLogic songLogic;

        public PlaylistController(IPlaylistLogic playlistLogic,ISongLogic songLogic)
        {
            this.playlistLogic = playlistLogic;
            this.songLogic = songLogic;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Playlist> songs = playlistLogic.GetPlaylist();
            return Ok(songs);
        }

        [HttpGet("playListName/{name}")]
        public IActionResult GetPlaylistByName([FromRoute] string name)
        {
            try
            {
                List<Playlist> playlists = playlistLogic.GetPlaylistByName(name);
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
                List<Playlist> playlists = playlistLogic.GetPlaylistByCategoryName(name);
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
                List<Playlist> playlists = playlistLogic.GetPlaylistBySongName(name);
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
                    songLogic.DeleteSongs(playlist.Songs);
                    playlistLogic.AddPlaylist(playlist);
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
                playlistLogic.DeletePlaylist(playlist);
                return Ok("Element removed");
            }
            catch (ValueNotFound)
            {
                return NotFound("This playlist not registered in the system");
            }
        }

        [HttpPost]
        public IActionResult AddSongToPlaylist([FromBody] Song song, [FromBody] Playlist playlist)
        {
           
            Playlist playlistToUpdate = playlist;
            playlist.Songs.Add(song);
            playlistLogic.UpdatePlaylist(playlistToUpdate,playlist);
            return Ok();
        }
       
    }
}