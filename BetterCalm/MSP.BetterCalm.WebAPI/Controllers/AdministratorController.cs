using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.WebAPI.Controllers
{    [ApiController]
    [Route("api/Administrator")]
    public class AdministratorController: ControllerBase
    {
        private IAdministratorService administratorService;

        public AdministratorController(IAdministratorService administratorService)
        {
            this.administratorService = administratorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Administrator> administratores = administratorService.GetAdministrators();
            return Ok(administratores);
        }
    }
}