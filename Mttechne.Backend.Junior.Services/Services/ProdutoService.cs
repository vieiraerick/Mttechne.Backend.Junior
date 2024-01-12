using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Data;
using Mttechne.Backend.Junior.Services.Extensions;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Strategies;
using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{

    private readonly AppDbContext _appDbContext;
    private readonly IAttributeValidationStrategy _attributeValidationStrategy;
    private readonly ProductValidationStrategy _produtoValidationStrategy;


    public string Erros => _attributeValidationStrategy.RetornarErros() + _produtoValidationStrategy.RetornarErros();

    public ProdutoService(AppDbContext appDbContext , IAttributeValidationStrategy attributeValidationStrategy, IObjectValidationStrategy<Produto> objectValidationStrategy)
    {
        _appDbContext = appDbContext;
        _attributeValidationStrategy = attributeValidationStrategy;
        _produtoValidationStrategy = (ProductValidationStrategy)objectValidationStrategy;
    }
    public async Task<List<Produto>> GetListaProdutos() => await _appDbContext.Produtos.ToListAsync();
    public async Task<List<Produto>> GetListaProdutosPorNome(string nome)
    {

        if (!_attributeValidationStrategy.IsNameValid(nome))
            return null;

        return (await GetListaProdutos()).Where(x => x.Nome.RemoverAcentuacao().IndexOf(nome.RemoverAcentuacao(), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }
       

    public async Task<List<Produto>> GetListaValorOrdenado(bool crescente) => crescente ?
        (await GetListaProdutos()).OrderBy(x => x.Valor).ToList() : (await GetListaProdutos()).OrderByDescending(x => x.Valor).ToList();

        
    public async Task<List<Produto>> GetListaFaixaValor(decimal minimo,decimal maximo)
    {
        if(!_produtoValidationStrategy.IsMaximoMinimoValid(minimo,maximo))
              return null;         

        return (await GetListaProdutos()).Where(x => x.Valor >= minimo && x.Valor <= maximo).OrderBy(x => x.Valor).ToList();
    }
        

    public async Task<List<Produto>> GetListaMinValor() =>
        (await GetListaProdutos()).OrderBy(p => p.Valor).Take(1).ToList();
    
    public async Task<List<Produto>> GetListaMaxValor() =>
        (await GetListaProdutos()).OrderByDescending(p => p.Valor).Take(1).ToList();

}