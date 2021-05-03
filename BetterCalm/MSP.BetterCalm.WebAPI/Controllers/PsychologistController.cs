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
            IEnumerable<Psychologist> patientes = psychologistService.GetPsychologists();
            return Ok(patientes);
        }

        public IActionResult AddPsychologist(Psychologist psychologist)
        {
            psychologistService.SetPsychologist(psychologist);
            return Created($"api/psychologist/{psychologist.Name}", psychologist);
        }
    }
}