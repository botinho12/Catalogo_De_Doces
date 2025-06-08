using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDoces.Models
{
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Nome { get; set; }

        public virtual ICollection<ProdutoModel> Produtos { get; set; }
    }
}
