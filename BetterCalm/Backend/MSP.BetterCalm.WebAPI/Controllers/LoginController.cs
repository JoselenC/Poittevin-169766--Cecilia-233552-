using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Services;
using MSP.BetterCalm.BusinessLogicInterface;
using MSP.BetterCalm.WebAPI.Dtos;
using MSP.BetterCalm.WebAPI.Filters;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [ApiController]
    [FilterExceptions]
    [Route("api/Login")]
    public class LoginController: ControllerBase
    {
        private readonly IAdministratorService administratorService;

        public LoginController(IAdministratorService administratorService)
        {
            this.administratorService = administratorService;
        }
        
        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            loginDto.token = administratorService.Login(loginDto.email, loginDto.password);
            return Ok(loginDto);
        }
    }
}