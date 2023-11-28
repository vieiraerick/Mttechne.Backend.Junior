using Mttechne.Backend.Junior.Services.Context;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{
    private AppDBContext _ctx;
    public ProdutoService(AppDBContext ctx) => _ctx = ctx;
    public List<Produto> GetListaProdutos()
    {
        List<Produto> produtosCadastrados = _ctx.Produtos.ToList();

        return produtosCadastrados;
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.Where(x => x.Nome == nome).ToList();
    }

    public List<Produto> GetListaProdutosPorIntervaloValores(double valorInicial, double valorFinal)
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.Where(x => x.Valor >= valorInicial && x.Valor <= valorFinal).ToList();
    }

    public List<Produto> GetListaProdutosPorValorMaximo()
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.OrderByDescending(x => x.Valor).DistinctBy(x => x.Nome).ToList();
    }

    public List<Produto> GetListaProdutosPorValorMinimo()
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.OrderBy(x => x.Valor).DistinctBy(x => x.Nome).ToList();
    }
}