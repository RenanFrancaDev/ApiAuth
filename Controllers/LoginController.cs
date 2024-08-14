using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAuth.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserModel model)
        {
            //Recuperar o usuário
            var user = UserRepository.Get(model.Email, model.Password);

            //Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário e senha inválidos" });

            //Gera o Token
            var token = TokenService.GenerateToken(user);

            //Ocultar senha
            user.Password = "";

            //Retorna ops dados

            return new {  user,  token };
        }
    }
}
