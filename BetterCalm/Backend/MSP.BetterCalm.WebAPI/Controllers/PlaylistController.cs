using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Dtos;
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
            List<Playlist> playlists = _playlistService.GetPlaylist();
            return Ok(playlists);
        }

        [HttpGet("name")]
        public IActionResult GetPlaylistByName([FromQuery] string name)
        {
            List<Playlist> playlists = _playlistService.GetPlaylistByName(name);
            return Ok(playlists);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlaylistById([FromRoute] int id)
        {
            Playlist playlists = _playlistService.GetPlaylistById(id);
            return Ok(playlists);
        }

        [HttpGet("category")]
        public IActionResult GetPlaylistByCategoryName([FromQuery] string name)
        {
            List<Playlist> playlists = _playlistService.GetPlaylistByCategoryName(name);
            return Ok(playlists);
        }

        [HttpGet("content")]
        public IActionResult GetPlaylistByContentName([FromQuery] string name)
        {
            List<Playlist> playlists = _playlistService.GetPlaylistByContentName(name);
            return Ok(playlists);
        }

        [HttpPost]
        public IActionResult CreatePlaylist([FromBody] PlaylistDto playlist)
        {
            Playlist playlistAdded = _playlistService.SetPlaylist(playlist.CreatePlaylist());
            return Created($"api/Playlist/{playlistAdded.Name}", playlistAdded);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlaylist([FromRoute] int id)
        {
            _playlistService.DeletePlaylist(id);
            return Ok("Element removed");
        }

        [HttpPost ("{id}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult AddNewContentToPlaylist([FromBody] ContentDto content, [FromRoute] int id)
        {
            Playlist playlist = _playlistService.GetPlaylistById(id);
            Content contentAdded = _playlistService.AddNewContentToPlaylist(content.CreateContent(), id);
            return Created($"api/Playlist/{playlist.Name}/Content/{contentAdded.Name}", contentAdded);
        }
        
        [ServiceFilter(typeof(FilterAuthentication))]
        [HttpPut ("{idPlaylist}/Contents/{id}")]
        public IActionResult AssociateContentToPlaylist([FromRoute] int id, int idPlaylist)
        {
            Playlist playlist = _playlistService.AssociateContentToPlaylist(id,idPlaylist);
            return Created($"api/Playlist/{idPlaylist}/Content/{id}", playlist);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlaylist([FromRoute] int id, [FromBody] PlaylistDto newPlaylist)
        {
            _playlistService.UpdatePlaylistById(id, newPlaylist.CreatePlaylist());
            return Ok("The content was updated");
        }

    }
}