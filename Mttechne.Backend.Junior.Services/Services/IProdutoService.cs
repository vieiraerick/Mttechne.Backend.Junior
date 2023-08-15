using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosValorCrescente();
    List<Produto> GetListaProdutosValorDecrescente();
    List<Produto> GetListaProdutosFaixaDePreco(decimal? valorMinimo, decimal? valorMaximo);
    List<Produto> GetListaProdutosMaiorValor();
    List<Produto> GetListaProdutosMenorValor();
}