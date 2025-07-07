using CatalogoDeDoces.Models;
using CatalogoDeDoces.Database;
using Microsoft.AspNetCore.Mvc;
using CatalogoDeDoces.Services.Interfaces;
using CatalogoDeDoces.Helper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
        public async Task<IActionResult> Login(UsuarioModel login)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == login.Email);
            if (usuario == null || !CriptografiaSenha.VerifyPassword(login.Senha, usuario.Senha))
            {
                ViewBag.Erro = "Email ou senha inválidos.";
                return View("Index");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.NomeUsuario),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim("EhAdministrador", usuario.EhAdministrador ? "true" : "false")              
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
                
            return RedirectToAction("Index", "Home");
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
