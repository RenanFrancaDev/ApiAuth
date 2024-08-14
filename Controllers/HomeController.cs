
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Logging;

namespace ApiAuth.Controllers
{
    [ApiController]
 
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("anonimo")]
        public string Anonymous() => "Anonimo";

        [Authorize]
        [HttpGet]
        [Route("autenticado")]
        public IActionResult Authenticated(string titulo)
        {

            if (User.Identity.IsAuthenticated) {
                return Ok("token valido");
            } else   
            {
                return Unauthorized("não autorizado");
            } 
        }
    }
}








