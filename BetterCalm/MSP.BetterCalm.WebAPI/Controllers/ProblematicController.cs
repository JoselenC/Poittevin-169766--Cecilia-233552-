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

    private IProblematicService _problematicService;

    public ProblematicController(IProblematicService problematicService)
    {
        this._problematicService = problematicService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Problematic> problematics = this._problematicService.GetProblematics();
        return Ok(problematics);
    }

    [HttpGet("{name}")]
    public IActionResult GetProblematicByName([FromQuery] string problematicName)
    {
        Problematic problematicByName = _problematicService.GetProblematicByName(problematicName);
        return Ok(problematicByName);
    }

    }
}