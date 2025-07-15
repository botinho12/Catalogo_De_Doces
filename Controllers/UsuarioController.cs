using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDoces.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DocesContext _docesContext;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(DocesContext docesContext, IUsuarioService usuarioService)
        {
            _docesContext = docesContext;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioExistente = await _usuarioService.BuscarUsuarioPorEmailAsync(usuario.Email);

                    if (usuarioExistente != null)
                    {
                        TempData["MensagemErro"] = "Email já cadastrado, tente outro email!";
                        return RedirectToAction("Index", "Login");
                    }

                    await _usuarioService.CriarAsync(usuario);

                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso! ";

                    return RedirectToAction("Index", "Login");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops , nao conseguimos cadastrar seu usuario , tente novamente , detalhe do erro:{erro.Message}";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}