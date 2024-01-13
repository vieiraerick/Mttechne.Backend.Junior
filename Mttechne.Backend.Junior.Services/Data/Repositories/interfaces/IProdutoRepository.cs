using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Data.Repositories.interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetListaProdutos();
        Task<List<Produto>> GetListaProdutosPorNome(string nome);
        Task<List<Produto>> GetListaValorOrdenado(bool crescente);
        Task<List<Produto>> GetListaMinValor();
        Task<List<Produto>> GetListaMaxValor();
        Task<List<Produto>> GetListaFaixaValor(decimal minimo,decimal maximo);
    }
}