using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorValorMaximo();
    List<Produto> GetListaProdutosPorValorMinimo();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosPorIntervalo(int inicial, int final);
}