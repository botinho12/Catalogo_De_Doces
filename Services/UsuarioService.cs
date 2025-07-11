using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using CatalogoDeDoces.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace CatalogoDeDoces.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task AtualizarSenhaAsync(UsuarioModel usuario, string novaSenhaHash)
        {
            usuario.Senha = novaSenhaHash;
            usuario.TokenRedefinicaoSenha = null;
            usuario.ExpiracaoToken = null;

            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task<UsuarioModel> BuscarUsuarioPorEmailAsync(string email)
        {
            return await _usuarioRepository.BuscarUsuarioPorEmailAsync(email);
        }

        public async Task<UsuarioModel?> BuscarUsuarioPorTokenAsync(string token)
        {
            return await _usuarioRepository.BuscarUsuarioPorTokenAsync(token);
        }

        public async Task<UsuarioModel> CriarAsync(UsuarioModel usuario)
        {
            usuario.SetSenhaHash();
            return await _usuarioRepository.CreateAsync(usuario);
        }

        public async Task SalvarAlteracoesAsync()
        {
            await _usuarioRepository.SalvarAlteracoesAsync();
        }
    }
}
