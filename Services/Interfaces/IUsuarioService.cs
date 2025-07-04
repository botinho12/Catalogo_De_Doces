﻿using CatalogoDeDoces.Models;

namespace CatalogoDeDoces.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> CriarAsync(UsuarioModel usuario);
        Task<UsuarioModel> BuscarUsuarioPorEmailAsync(string email);
    }
}
