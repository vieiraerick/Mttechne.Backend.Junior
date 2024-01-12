using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosEntreValores(decimal min, decimal max);
    List<Produto> GetListaValoresMaximos();
    List<Produto> GetListaValoresMinimos();
    List<Produto> GetListaOrdenada(string ordem);
}