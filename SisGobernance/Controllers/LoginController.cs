using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisGobernance.Contexto;


namespace SisGobernance.Controllers
{
    public class LoginController : Controller
    {
        private MiContext _context;
        public LoginController(MiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var usuario = await _context.Usuarios
                                    .Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
                                    

            if (usuario != null)
            {
                //await SetUserCookie(usuario);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o password incorrecto!";
                return RedirectToAction("Index");
            }
        }


    }
}
