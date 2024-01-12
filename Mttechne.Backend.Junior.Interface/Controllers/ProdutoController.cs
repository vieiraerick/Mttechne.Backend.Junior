using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.Services.Strategies;
using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;
    private readonly IAttributeValidationStrategy _attributeValidationStrategy;
    private readonly ProductValidationStrategy _produtoValidationStrategy;

    public ProdutoController(IProdutoService service, IAttributeValidationStrategy attributeValidationStrategy, IObjectValidationStrategy<Produto> objectValidationStrategy)
    {
        _service = service;
        _attributeValidationStrategy = attributeValidationStrategy;
        _produtoValidationStrategy = (ProductValidationStrategy)objectValidationStrategy;
    }

    [HttpGet]
    public async Task<IActionResult> GetListaProdutos() => Ok(await _service.GetListaProdutos());

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosProNome([FromRoute] string nome)
    {
        if (!_attributeValidationStrategy.IsNameValid(nome))
            return BadRequest(_attributeValidationStrategy.RetornarErros());

        return Ok(await _service.GetListaProdutosPorNome(nome));
    }

    [HttpGet]
    [Route("ValorCrescente")]
    public async Task<IActionResult> GetListaValorCrescente()
    {
        return Ok(await _service.GetListaValorCresceste());
    }

    [HttpGet]
    [Route("ValorDecrescente")]
    public async Task<IActionResult> GetListaValorDecrescente()
    {
        return Ok(await _service.GetListaValorDecresceste());
    }

    [HttpGet]
    [Route("EntreValores")]
    public async Task<IActionResult> GetListaProdutosEntreValores([FromQuery] decimal minimo, [FromQuery] decimal maximo)
    {
        if(!_produtoValidationStrategy.IsMaximoMinimoValid(minimo,maximo))
            return BadRequest(_produtoValidationStrategy.RetornarErros());
            
        return Ok(await _service.GetListaFaixaValor(minimo, maximo));
    }

    [HttpGet]
    [Route("Maximo")]
    public async Task<IActionResult> GetListaProdutoValorMaximo()
    {
        return Ok(await _service.GetListaMaxValor());
    }

    [HttpGet]
    [Route("Minimo")]
    public async Task<IActionResult> GetListaProdutoValorMinimo()
    {
        return Ok(await _service.GetListaMinValor());
    }
}