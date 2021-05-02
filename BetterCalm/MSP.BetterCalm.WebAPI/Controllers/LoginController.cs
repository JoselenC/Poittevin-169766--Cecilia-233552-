using Microsoft.AspNetCore.Mvc;

namespace MSP.BetterCalm.WebAPI.Controllers
{
    [Route("api/Login")]
    public class LoginController: ControllerBase
    {
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}