using CatalogoDeDoces.Models;

namespace CatalogoDeDoces.Services.Interfaces
{
    public interface IJwtService
    {
        string GerarToken(UsuarioModel usuario);
    }
}
