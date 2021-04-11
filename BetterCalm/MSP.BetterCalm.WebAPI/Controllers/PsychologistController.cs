using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    
    [ApiController]
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
            psychologistService.AddPsychologist(psychologist);
            return Created($"api/psychologist/{psychologist.Name}", psychologist);
        }
    }
}