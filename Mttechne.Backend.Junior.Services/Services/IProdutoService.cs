using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetProdutosPorValor(int order, List<Produto> produtos);
    List<Produto> GetProdutosFaixa(double valor_inicial, double valor_final, List<Produto> produtos);
    List<Produto> ValoresExtremos(int i, List<Produto> produtos);
}