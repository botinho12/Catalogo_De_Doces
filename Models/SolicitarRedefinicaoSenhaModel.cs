using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class SolicitarRedefinicaoSenhaModel
    {
        [Required(ErrorMessage = "Digite o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;
    }
}
