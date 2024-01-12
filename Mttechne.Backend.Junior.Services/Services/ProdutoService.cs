using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Service.Helpers;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services.Data;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{
    private readonly ApplicationDbContext _dbContext;
    public ProdutoService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Produto> GetListaProdutos()
    {
        var produtosCadastrados = _dbContext
            .Produtos
            .AsNoTracking()
            .ToList();

        return produtosCadastrados;
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        var listaProdutos = GetListaProdutos();

        nome = RemoveDiacritcsHelper
             .RemoveDiacritics(nome)
             .ToLower();

        return listaProdutos
            .Where(
                x => RemoveDiacritcsHelper
                .RemoveDiacritics(x.Nome)
                .ToLower()
                .Contains(nome)
            )
            .ToList();
    }

    public List<Produto> GetListaProdutosEntreValores(decimal min, decimal max)
    {
        var listaProdutos = _dbContext.Produtos;

        return listaProdutos
            .Where(x => x.Valor >= min && x.Valor <= max)
            .AsNoTracking()
            .ToList();
    }

    public List<Produto> GetListaValoresMaximos()
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos
            .GroupBy(x => x.Nome)
            .Select(x => x.MaxBy(p => p.Valor))
            .ToList();
    }

    public List<Produto> GetListaValoresMinimos()
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos
            .GroupBy(x => x.Nome)
            .Select(x => x.MinBy(p => p.Valor))
            .ToList();
    }

    public List<Produto> GetListaOrdenada(string ordem)
    {
        var listaProdutos = _dbContext.Produtos;

        if (ordem == "asc")
            return listaProdutos.OrderBy(x => x.Valor).ToList();
        else
            return listaProdutos.OrderByDescending(x => x.Valor).ToList();
    }
}