namespace CatalogoDeDoces.Dtos
{
    public class ProdutoListaDto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int? Quantidade { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
