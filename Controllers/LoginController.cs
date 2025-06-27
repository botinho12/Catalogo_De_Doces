using CatalogoDeDoces.Models;
using CatalogoDeDoces.Database;
using Microsoft.AspNetCore.Mvc;
using CatalogoDeDoces.Services.Interfaces;

namespace CatalogoDeDoces.Controllers
{
    public class LoginController : Controller
    {
        private readonly DocesContext _context;
        private readonly IUsuarioService _usuarioService;

        public LoginController(DocesContext context, IUsuarioService usuarioService)
        {
            _context = context;
            _usuarioService = usuarioService;
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

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _usuarioService.BuscarUsuarioPorEmailAsync(redefinirSenhaModel.Email);

                    if (usuario != null)
                    {
                        TempData["SucessMensage"] = "Um link de redefinição foi enviado para o seu e-mail.";
                    }
                    else
                    {
                        TempData["MensagemErro"] = "E-mail não encontrado.";
                    }

                    return RedirectToAction("Index", "Login");
                }
                return View(redefinirSenhaModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao enviar link: {ex.Message}";
                return View(redefinirSenhaModel);
            }
        }
    }
}
