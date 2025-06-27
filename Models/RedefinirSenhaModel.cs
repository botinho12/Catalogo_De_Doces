using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Nome de Usuário")]
        public required string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        public required string Email { get; set; }
    }
}
