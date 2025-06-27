using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using CatalogoDeDoces.Services.Interfaces;

namespace CatalogoDeDoces.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioModel> CriarAsync(UsuarioModel usuario)
        {
            return await _usuarioRepository.CreateAsync(usuario);
        }
    }
}
