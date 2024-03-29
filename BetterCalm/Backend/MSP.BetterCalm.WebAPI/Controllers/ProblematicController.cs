﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
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
        Problematic problematicByName = _problematicService.GetProblematicByName(name);
        return Ok(problematicByName);
    }

    [HttpGet("{id}")]
    public IActionResult GetProblematicById([FromRoute] int id)
    {
        Problematic problematicById = _problematicService.GetProblematicById(id);
        return Ok(problematicById);
    }

    }
}