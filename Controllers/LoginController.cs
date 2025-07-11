using CatalogoDeDoces.Models;
using CatalogoDeDoces.Database;
using Microsoft.AspNetCore.Mvc;
using CatalogoDeDoces.Services.Interfaces;
using CatalogoDeDoces.Helper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using CatalogoDeDoces.Services;

namespace CatalogoDeDoces.Controllers
{
    public class LoginController : Controller
    {
        private readonly DocesContext _context;
        private readonly IUsuarioService _usuarioService;
        private readonly EmailService _emailService;
        private readonly IJwtService _jwtService;

        public LoginController(DocesContext context, IUsuarioService usuarioService, EmailService emailService, IJwtService jwtService)
        {
            _context = context;
            _usuarioService = usuarioService;
            _emailService = emailService;
            _jwtService = jwtService;
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

            var token = _jwtService.GerarToken(usuario);

            Response.Cookies.Append("X-Access-Token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(2)
            });

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogoutAsync()
        {
            Response.Cookies.Delete("X-Access-Token");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarLinkParaRedefinirSenha(SolicitarRedefinicaoSenhaModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = await _usuarioService.BuscarUsuarioPorEmailAsync(model.Email);

            if (usuario == null)
            {
                TempData["MensagemErro"] = "E-mail não encontrado.";
                return View(model);
            }

            var token = Guid.NewGuid().ToString();
            usuario.TokenRedefinicaoSenha = token;
            usuario.ExpiracaoToken = DateTime.Now.AddHours(1);
            await _usuarioService.SalvarAlteracoesAsync();

            var link = Url.Action("NovaSenha", "Login", new { token }, Request.Scheme);
            var corpoEmail = $@"
            <h2>Redefinição de Senha</h2>
            <p>Olá {usuario.NomeUsuario},</p>
            <p>Clique no link abaixo para redefinir sua senha:</p>
            <p><a href='{link}'>Redefinir Senha</a></p>
            <p>Este link expira em 1 hora.</p>";

            await _emailService.EnviarEmailAsync(usuario.Email, "Redefinição de Senha", corpoEmail);

            TempData["MensagemSucesso"] = "Um link de redefinição foi enviado para o seu e-mail.";
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public async Task<IActionResult> NovaSenha(string token)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorTokenAsync(token);

            if (usuario == null)
            {
                TempData["MensagemErro"] = "Token inválido ou expirado.";
                return RedirectToAction("Index", "Login");
            }

            var model = new RedefinirSenhaModel
            {
                Email = usuario.Email
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> NovaSenha(RedefinirSenhaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = await _usuarioService.BuscarUsuarioPorEmailAsync(model.Email);

            if (usuario == null || usuario.ExpiracaoToken < DateTime.Now)
            {
                TempData["MensagemErro"] = "Token expirado ou usuário inválido.";
                return RedirectToAction("Index", "Login");
            }

            usuario.Senha = CriptografiaSenha.GerarHash(model.NovaSenha);
            usuario.TokenRedefinicaoSenha = null;
            usuario.ExpiracaoToken = null;

            await _usuarioService.SalvarAlteracoesAsync();

            TempData["MensagemSucesso"] = "Senha redefinida com sucesso!";
            return RedirectToAction("Index", "Login");
        }
    }
}
