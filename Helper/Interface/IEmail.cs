namespace CatalogoDeDoces.Helper.Interface
{
    public interface IEmail
    {
        bool EnviarEmail(string email, string assunto, string mensagem);
    }
}
