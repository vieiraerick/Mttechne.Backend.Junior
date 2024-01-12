using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Domain.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosOrdenado(bool? OrdemCrescente, bool? OrdemDescrecente);
    List<Produto> GetListaRangeValoresProduto(int ValorMIn, int ValorMax);
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetProdutosMaiorEMenorValor(bool valida);
}
