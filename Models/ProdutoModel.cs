using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string? Descricao { get; set; }

        public string? ImagemUrl { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public int CategoriaId { get; set; }
        public virtual CategoriaModel? Categoria { get; set; }
    }
}
