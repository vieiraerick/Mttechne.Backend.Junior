using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Interface;

public interface IProdutoService
{
    IList<Produto> GetListaProdutos();
    IList<Produto> GetListaProdutosPorNome(string nome);

    IList<Produto> GetListaOrdenadaPorValorCrescente();

    IList<Produto> GetListaOrdenadaPorValorDecrescente();
    IList<Produto> GetFaixaDePreco(decimal valorMin, decimal valorMax);

    IList<Produto> GetValorMaximo();

    IList<Produto> GetValorMinimo();
}