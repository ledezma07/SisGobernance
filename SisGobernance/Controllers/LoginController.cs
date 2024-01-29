using Microsoft.AspNetCore.Mvc;

namespace SisGobernance.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
