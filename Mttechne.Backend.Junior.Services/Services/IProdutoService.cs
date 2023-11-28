using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetListaProdutosPorIntervaloValores(double valorInicial, double valorFinal);
}