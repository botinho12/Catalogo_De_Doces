using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatorio")]
        [StringLength(50)]
        public string NomeUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Insira um email valido")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessario inserir uma senha")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Insira o telefone do usuário")]
        [Phone]
        [StringLength(20)]
        public string Telefone { get; set; } = string.Empty;

        public bool EhAdministrador { get; set; }

        public void SetSenhaHash()
        {
            if (!string.IsNullOrEmpty(Senha))
            {
                Senha = Helper.CriptografiaSenha.GerarHash(Senha);
            }
        }
    }
}