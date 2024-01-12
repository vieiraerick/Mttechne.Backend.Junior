using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosOrdenadaPorValor(bool ehCrescente);
    List<Produto> GetListaProdutosPorFaixaDePreco(int valorMinimo, int valorMaximo);
    List<Produto> GetProdutosValoresMaximos();
    List<Produto> GetProdutosValoresMinimos();
}