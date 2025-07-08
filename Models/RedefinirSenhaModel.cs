using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Nome de Usuário")]
        public required string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Digite o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Digite a nova senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public required string NovaSenha { get; set; }

        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não coincidem")]
        [DataType(DataType.Password)]
        public required string ConfirmarSenha { get; set; }
    }
}
