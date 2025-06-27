using CatalogoDeDoces.Models;

namespace CatalogoDeDoces.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepositoryGeneric<UsuarioModel>
    {
        Task<UsuarioModel> BuscarUsuarioPorEmailAsync(string email);
    }
}