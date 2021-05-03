using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{    
    [ApiController]
    [FilterExceptions]
    [Route("api/Administrator")]
    public class AdministratorController: ControllerBase
    {
        private IAdministratorService administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            this.administratorService = administratorService;
        }

        [HttpGet]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult GetAll()
        {
            IEnumerable<Administrator> administratores = administratorService.GetAdministrators();
            return Ok(administratores);
        }

        [HttpPost]
        public CreatedResult AddAdministrator(Administrator administrator)
        {
            administrator = administratorService.AddAdministrator(administrator);
            return Created($"api/Administrator/{administrator.Name}", administrator);
        }
        
        [HttpGet("{administratorId}")]
        [ServiceFilter(typeof(FilterAuthentication))]
        public IActionResult GetAdministratorById(int administratorId)
        {
            Administrator administrator = administratorService.GetAdministratorsById(administratorId);
            return Ok(administrator);
        }

        [HttpDelete("{administratorId}")]
        public OkObjectResult DeleteAdministratorById(int administratorId)
        {
            administratorService.DeleteAdministratorById(administratorId);
            return Ok("Entity removed");
        }

        [HttpPut("{administratorId}")]
        public IActionResult UpdateAdministrator(
            [FromBody] Administrator administrator, 
            [FromRoute] int administratorId)
        {
            Administrator updatedAdministrator = administratorService.UpdateAdministrator(administrator, administratorId);
            return Ok(updatedAdministrator);
        }
    }
}