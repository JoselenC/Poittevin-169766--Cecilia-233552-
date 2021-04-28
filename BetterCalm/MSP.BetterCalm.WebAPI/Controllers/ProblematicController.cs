using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
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

    [HttpGet("name")]
    public IActionResult GetProblematicByName([FromQuery] string name)
    {
        try{
        Problematic problematicByName = _problematicService.GetProblematicByName(name);
        return Ok(problematicByName);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Not found problematic by this name");
        }
    }
    
    [HttpGet("{id}")]
    public IActionResult GetProblematicById([FromRoute] int id)
    {
        try
        {
            Problematic problematicById = _problematicService.GetProblematicById(id);
            return Ok(problematicById);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Not found problematic by this id");
        }
    }

    }
}