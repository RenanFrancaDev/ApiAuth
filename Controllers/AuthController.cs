using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
