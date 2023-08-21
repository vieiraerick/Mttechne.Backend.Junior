using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosByName(string nome);
    List<Produto> GetListaProdutosByPriceAscendinge();
    List<Produto> GetListaProdutosByPriceDescending();
    List<Produto> GetListaProdutosInPriceRange(int minPrice, int maxPrice);
    List<Produto> GetListaProdutosPerMaxValue();
    List<Produto> GetListaProdutosPerMinValue();
}