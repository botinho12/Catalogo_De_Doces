using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoDeDoces.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [StringLength(300, ErrorMessage = "A descrição deve ter no máximo 300 caracteres.")]
        public string? Descricao { get; set; }

        public int? Quantidade { get; set; }

        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um preço válido.")]
        public decimal Preco { get; set; }

        [NotMapped]
        public IFormFile? ArquivoImagem { get; set; }

        public int? CategoriaId { get; set; }

        public virtual CategoriaModel? Categoria { get; set; }
    }
}
