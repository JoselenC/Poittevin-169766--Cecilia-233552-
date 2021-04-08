using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Playlist")]
    public class PlaylistController : ControllerBase
    {

        private IPlaylistLogic playlistLogic;

        public PlaylistController(IPlaylistLogic playlistLogic)
        {
            this.playlistLogic = playlistLogic;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Playlist> songs = this.playlistLogic.GetPlaylist();
            return Ok(songs);
        }
        
        [HttpGet("playListName/{Name}")]
        public IActionResult GetPlaylistByName([FromRoute]string Name)
        {
            List<Playlist> playlists = this.playlistLogic.GetPlaylistByName(Name);
            return Ok(playlists);
        }
        
        [HttpGet("categoryName/{Name}")]
        public IActionResult GetPlaylistByCategoryName([FromRoute]string Name)
        {
            List<Playlist> playlists = this.playlistLogic.GetPlaylistByCategoryName(Name);
            return Ok(playlists);
        }
        
        [HttpGet("songName/{Name}")]
        public IActionResult GetPlaylistBySongName([FromRoute]string Name)
        {
            List<Playlist> playlists = this.playlistLogic.GetPlaylistBySongName(Name);
            return Ok(playlists);
        }
        
        [HttpPost]
        public IActionResult CreatePlaylist([FromBody] Playlist playlist)
        {
            playlistLogic.AddPlaylist(playlist);
            return Ok("Playlist created");
        }
        
        [HttpDelete()]
        public IActionResult DeletePlaylist([FromBody] Playlist playlist)
        {
            playlistLogic.DeletePlaylist(playlist);
            return Ok("Element removed");
        }

       
    }
}