using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [Route("api/Login")]
    [FilterExceptions]
    public class LoginController: ControllerBase
    {
        private readonly IAdministratorService administratorService;

        public LoginController(IAdministratorService administratorService)
        {
            this.administratorService = administratorService;
        }
        
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            return Ok(administratorService.Login(email, password));
        }
    }
}