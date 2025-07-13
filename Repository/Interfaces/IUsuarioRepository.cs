using CatalogoDeDoces.Models;

namespace CatalogoDeDoces.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepositoryGeneric<UsuarioModel>
    {
        Task<UsuarioModel> BuscarUsuarioPorEmailAsync(string email);
        Task<UsuarioModel?> BuscarUsuarioPorTokenAsync(string token);
        Task SalvarAlteracoesAsync();
    }
}