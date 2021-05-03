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
    [Route("api/Audio")]
    public class AudioController : ControllerBase
    {

        private IAudioService _audioService;

        public AudioController(IAudioService audioService)
        {
            this._audioService = audioService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Audio> Audios = _audioService.GetAudios();
            return Ok(Audios);
        }

        [HttpGet("name")]
        public IActionResult GetAudiosByName([FromQuery] string name)
        {
            List<Audio> Audios = _audioService.GetAudiosByName(name);
            return Ok(Audios);
        }

        [HttpGet("author")]
        public IActionResult GetAudiosByAuthor([FromQuery] string author)
        {
            List<Audio> Audios = _audioService.GetAudiosByAuthor(author);
            return Ok(Audios);
        }


        [HttpGet("category/name")]
        public IActionResult GetAudiosByCategoryName([FromQuery] string name)
        {
            List<Audio> Audios = _audioService.GetAudiosByCategoryName(name);
            return Ok(Audios);
        }


        [HttpGet("{id}")]
        public IActionResult GetAudioById([FromRoute] int id)
        {
            Audio audioById = _audioService.GetAudioById(id);
            AudioDto audio = new AudioDto().CreateAudioDto(audioById);
            return Ok(audio);
        }

        
        [HttpPost]
        public IActionResult CreateAudio([FromBody] AudioDto audio)
        {
            Audio audioAdded=_audioService.SetAudio(audio.CreateAudio());
            return Created($"api/Audio/{audioAdded.Name}","Audio created");
        }

        [HttpDelete()]
        public IActionResult DeleteAudio([FromBody] AudioDto audio)
        {
            _audioService.DeleteAudio(audio.Id);
            return Ok("Audio removed");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAudio([FromRoute] int id)
        {
            _audioService.DeleteAudio(id);
            return Ok("Audio removed");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAudio([FromRoute] int id, [FromBody] AudioDto audioUpdated)
        {
            _audioService.UpdateAudioById(id, audioUpdated.CreateAudio());
            return Ok("Audio Updated");
        }
    }
}