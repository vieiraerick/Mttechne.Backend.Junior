using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Data;
using Mttechne.Backend.Junior.Services.Data.Repositories.interfaces;
using Mttechne.Backend.Junior.Services.Extensions;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Strategies;
using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{

    private readonly IProdutoRepository _productRepository;
    private readonly IAttributeValidationStrategy _attributeValidationStrategy;
    private readonly ProductValidationStrategy _produtoValidationStrategy;


    public string Erros => _attributeValidationStrategy.RetornarErros() + _produtoValidationStrategy.RetornarErros();

    public ProdutoService(IProdutoRepository iRepository , IAttributeValidationStrategy attributeValidationStrategy)
    {
        _productRepository = iRepository;
        _attributeValidationStrategy = attributeValidationStrategy;
        _produtoValidationStrategy = new ProductValidationStrategy(new AttributeValidationStrategy());
    }
    public async Task<List<Produto>> GetListaProdutos() => await _productRepository.GetListaProdutos();
    public async Task<List<Produto>> GetListaProdutosPorNome(string nome)
    {

        if (!_attributeValidationStrategy.IsNameValid(nome))
        {
            return new List<Produto>();
        }
            

        return await _productRepository.GetListaProdutosPorNome(nome);
    }
       

    public async Task<List<Produto>> GetListaValorOrdenado(bool crescente) => crescente ?
        await _productRepository.GetListaValorOrdenado(true) :  await _productRepository.GetListaValorOrdenado(false);

        
    public async Task<List<Produto>> GetListaFaixaValor(decimal minimo,decimal maximo)
    {
        if(!_produtoValidationStrategy.IsMaximoMinimoValid(minimo,maximo))
              return new List<Produto>();         

        return await _productRepository.GetListaFaixaValor(minimo,maximo);
    }
        

    public async Task<List<Produto>> GetListaMinValor() =>
        await _productRepository.GetListaMinValor();
    
    public async Task<List<Produto>> GetListaMaxValor() =>
        await _productRepository.GetListaMaxValor();

}