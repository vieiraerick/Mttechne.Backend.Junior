using Mttechne.Backend.Junior.Services.Extensions;
using Mttechne.Backend.Junior.Services.Interface;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;

    }

    public IList<Produto> GetFaixaDePreco(decimal valorMin, decimal valorMax)
    {
        var lista = GetListaProdutos();
        return lista.Where(x => x.Valor >= valorMin && x.Valor <= valorMax).ToList();
    }

    public IList<Produto> GetListaOrdenadaPorValorCrescente()
    {
        var Lista = GetListaProdutos();
        return Lista.OrderBy(x => x.Valor).ToList();
    }

    public IList<Produto> GetListaOrdenadaPorValorDecrescente()
    {
        var Lista = GetListaProdutos();
        return Lista.OrderByDescending(x => x.Valor).ToList();
    }

    public IList<Produto> GetListaProdutos()
    {
        return _produtoRepository.GetListaProdutos();
    }

    public IList<Produto> GetListaProdutosPorNome(string nome)
    {
        var listaProdutos = GetListaProdutos();
        return listaProdutos.Where(x => x.Nome.ToUpper().RemoverAcentos().Contains(nome.ToUpper().RemoverAcentos())).ToList();
      

    }

    public IList<Produto> GetValorMaximo()
    {
        var lista = GetListaProdutos();
        return lista.OrderByDescending(x =>
        x.Valor).DistinctBy(x => x.Nome).ToList();
    }

    public IList<Produto> GetValorMinimo()
    {
        var lista = GetListaProdutos();
        return lista.OrderBy(x =>
        x.Valor).DistinctBy(x => x.Nome).ToList();
    }
}