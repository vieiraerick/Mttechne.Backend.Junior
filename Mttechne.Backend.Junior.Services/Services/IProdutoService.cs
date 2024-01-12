using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    Task<List<Produto>> GetListaProdutos();
    Task<List<Produto>> GetListaProdutosPorNome(string nome);
    Task<List<Produto>> GetListaValorCresceste();
    Task<List<Produto>> GetListaValorDecresceste();
    Task<List<Produto>> GetListaMinValor();
    Task<List<Produto>> GetListaMaxValor();
    Task<List<Produto>> GetListaFaixaValor(decimal minimo,decimal maximo);

}