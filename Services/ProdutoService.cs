using System.Linq.Expressions;
using CatalogoDeDoces.Models;
using CatalogoDeDoces.Repository.Interfaces;
using CatalogoDeDoces.Services.Interfaces;

namespace CatalogoDeDoces.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoModel>> ObterTodosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<ProdutoModel> ObterPorIdAsync(Expression<Func<ProdutoModel, bool>> predicate)
        {
            return await _produtoRepository.GetAsync(predicate);
        }

        public async Task<ProdutoModel> CriarAsync(ProdutoModel produto)
        {
            return await _produtoRepository.CreateAsync(produto);
        }

        public async Task<ProdutoModel> AtualizarAsync(ProdutoModel produto)
        {
            return await _produtoRepository.UpdateAsync(produto);
        }

        public async Task<ProdutoModel> DeletarAsync(int Id)
        {
            var itemEcluir = await _produtoRepository.GetAsync(c => c.Id == Id);
            if (itemEcluir == null)
            {
                throw new Exception("Item não encontrado para exclusão");
            }
            else
            await _produtoRepository.DeleteAsync(itemEcluir);

            return itemEcluir;
        }
    }
}
