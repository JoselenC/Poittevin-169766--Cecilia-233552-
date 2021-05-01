using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    
    [ApiController]
    [FilterExceptions]
    [Route("api/Psychologist")]
    public class PsychologistController: ControllerBase
    {
        
        private IPsychologistService psychologistService;

        public PsychologistController(IPsychologistService psychologistService)
        {
            this.psychologistService = psychologistService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Psychologist> psychologists = psychologistService.GetPsychologists();
            return Ok(psychologists);
        }
        
        [HttpGet("{psychologistId}")]
        public IActionResult GetPsychologistById(int psychologistId)
        {
            Psychologist psychologist = psychologistService.GetPsychologistsById(psychologistId);
            return Ok(psychologist);
        }

        [HttpPost]
        public IActionResult AddPsychologist(Psychologist psychologist)
        {
            psychologistService.AddPsychologist(psychologist);
            return Created($"api/psychologist/{psychologist.Name}", psychologist);
        }

        [HttpDelete("{psychologistId}")]
        public OkObjectResult DeletePsychologistById(int psychologistId)
        {
            psychologistService.DeletePsychologistById(psychologistId);
            return Ok("Entity removed");
        }

        [HttpPut("{psychologistId}")]
        public IActionResult UpdatePsychologist(
            [FromBody] Psychologist psychologist, 
            [FromRoute] int psychologistId)
        {
            Psychologist updatedPsychologist = psychologistService.UpdatePsychologist(psychologist, psychologistId);
            return Ok(updatedPsychologist);
        }
    }
}