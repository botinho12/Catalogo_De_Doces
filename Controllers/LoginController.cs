using CatalogoDeDoces.Models;
using CatalogoDeDoces.Database; 
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    public class LoginController : Controller
    {
        private readonly DocesContext _context;

        public LoginController(DocesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioModel login)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioNome", usuario.NomeUsuario);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Email ou senha inválidos.";
            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
