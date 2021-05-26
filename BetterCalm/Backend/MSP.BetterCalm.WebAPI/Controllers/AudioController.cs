using System.Collections.Generic;
using System.Linq;
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
            List<AudioDto> audioDtos = Audios.Select(audio => new AudioDto().CreateAudioDto(audio)).ToList();
            return Ok(audioDtos);
        }

        [HttpGet("name")]
        public IActionResult GetAudiosByName([FromQuery] string name)
        {
            List<Audio> Audios = _audioService.GetAudiosByName(name);
            List<AudioDto> audioDtos = Audios.Select(audio => new AudioDto().CreateAudioDto(audio)).ToList();
            return Ok(audioDtos);
        }

        [HttpGet("author")]
        public IActionResult GetAudiosByAuthor([FromQuery] string author)
        {
            List<Audio> Audios = _audioService.GetAudiosByAuthor(author);
            List<AudioDto> audioDtos = Audios.Select(audio => new AudioDto().CreateAudioDto(audio)).ToList();
            return Ok(audioDtos);        }


        [HttpGet("Category")]
        public IActionResult GetAudiosByCategoryName([FromQuery] string name)
        {
            List<Audio> Audios = _audioService.GetAudiosByCategoryName(name);
            List<AudioDto> audioDtos = Audios.Select(audio => new AudioDto().CreateAudioDto(audio)).ToList();
            return Ok(audioDtos);
        }


        [HttpGet("{id}")]
        public IActionResult GetAudioById([FromRoute] int id)
        {
            Audio audioById = _audioService.GetAudioById(id);
            AudioDto audio = new AudioDto().CreateAudioDto(audioById);
            return Ok(audio);
        }

        
        [HttpPost]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult CreateAudio([FromBody] AudioDto audio)
        {
            Audio audioAdded = _audioService.SetAudio(audio.CreateAudio());
            AudioDto audioDto = new AudioDto().CreateAudioDto(audioAdded);
            return Created($"api/Audio/{audioAdded.Name}", audioDto);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult DeleteAudio([FromRoute] int id)
        {
            _audioService.DeleteAudio(id);
            return Ok("Audio removed");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult UpdateAudio([FromRoute] int id, [FromBody] AudioDto audioUpdated)
        {
            _audioService.UpdateAudioById(id, audioUpdated.CreateAudio());
            return Ok("Audio Updated");
        }
    }
}