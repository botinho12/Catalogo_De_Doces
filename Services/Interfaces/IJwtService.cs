namespace CatalogoDeDoces.Services.Interfaces
{
    public interface IJwtService
    {
        string GerarToken(string userId, string userRole);
    }
}
