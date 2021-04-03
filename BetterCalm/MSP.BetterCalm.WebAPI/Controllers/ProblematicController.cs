using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Problematic")]
    public class ProblematicController : ControllerBase
    {

    private IProblematicLogic problematicLogic;

    public ProblematicController(IProblematicLogic problematicLogic)
    {
        this.problematicLogic = problematicLogic;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Problematic> problematics = this.problematicLogic.GetProblematics();
        return Ok(problematics);
    }

    [HttpGet("{name}")]
    public IActionResult GetProblematicByName([FromQuery] string problematicName)
    {
        Problematic problematicByName = problematicLogic.GetProblematicByName(problematicName);
        return Ok(problematicByName);
    }

    }
}