using CatalogoDeDoces.Models;

namespace CatalogoDeDoces.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> CriarAsync(UsuarioModel usuario);
        Task<UsuarioModel> BuscarUsuarioPorEmailAsync(string email);
        Task<UsuarioModel?> BuscarUsuarioPorTokenAsync(string token);
        Task AtualizarSenhaAsync(UsuarioModel usuario, string novaSenhaHash);
        Task SalvarAlteracoesAsync();
    }
}
