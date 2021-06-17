using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.Importer;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/import")]
    public class ImportController:ControllerBase 
    {
        private readonly IImportService importService;
        public ImportController(IImportService importService)
        {
            this.importService = importService;
        }

        [HttpGet("name")]
        public IActionResult GetNames()
        {
           List<string> importers= importService.GetImportersName();
           return Ok(importers);
        }

        [HttpGet("parameters")]
        public IActionResult GetParameters()
        {
            List<Parameter> parameters =importService.GetParameters();
            return Ok(parameters);
        }

        [HttpPost] 
        public IActionResult ImportContent([FromBody] ImportDto importDto)
        {
            Import import = new Import() {Name = importDto.Name, 
                Path = importDto.Path ,Parameters = importService.GetParameters()};
            string message = importService.ImportContent(import);
            return Ok(message);
        }
    }
}