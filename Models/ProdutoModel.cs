using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "A descrição deve ter no máximo 50 caracteres.")]
        public string? Descricao { get; set; }

        public string? ImagemUrl { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Informe um preço válido.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public int CategoriaId { get; set; }

        public virtual CategoriaModel? Categoria { get; set; }
    }
}
