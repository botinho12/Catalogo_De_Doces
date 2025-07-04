﻿using CatalogoDeDoces.Database;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using CatalogoDeDoces.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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