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

        [HttpGet("Category/name")]
        public IActionResult GetPlaylistByCategoryName([FromQuery] string name)
        {
            List<Playlist> playlists = _playlistService.GetPlaylistByCategoryName(name);
            return Ok(playlists);
        }

        [HttpGet("Audio/name")]
        public IActionResult GetPlaylistByAudioName([FromQuery] string name)
        {
            List<Playlist> playlists = _playlistService.GetPlaylistByAudioName(name);
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
        public IActionResult AddNewAudioToPlaylist([FromBody] AudioDto audio, [FromRoute] int id)
        {
            Playlist playlist = _playlistService.GetPlaylistById(id);
            Audio audioAdded = _playlistService.AddNewAudioToPlaylist(audio.CreateAudio(), id);
            return Created($"api/Playlist/{playlist.Name}/Audio/{audioAdded.Name}", audioAdded);
        }
        
        [ServiceFilter(typeof(FilterAuthentication))]
        [HttpPut ("{idPlaylist}/Audios/{id}")]
        public IActionResult AssociateAudioToPlaylist([FromRoute] int id, int idPlaylist)
        {
            Playlist playlist = _playlistService.AssociateAudioToPlaylist(id,idPlaylist);
            return Created($"api/Playlist/{idPlaylist}/Audio/{id}", playlist);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlaylist([FromRoute] int id, [FromBody] PlaylistDto newPlaylist)
        {
            _playlistService.UpdatePlaylistById(id, newPlaylist.CreatePlaylist());
            return Ok("The audio was updated");
        }

    }
}