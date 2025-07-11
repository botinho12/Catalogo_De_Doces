using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string Email  { get; set; }

        [Required(ErrorMessage = "Digite a nova senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string NovaSenha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirme a nova senha")]
        [Compare("NovaSenha", ErrorMessage = "As senhas não coincidem")]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }

}
