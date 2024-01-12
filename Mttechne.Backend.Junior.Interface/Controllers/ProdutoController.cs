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

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetListaProdutos() => Ok(await _service.GetListaProdutos());

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosProNome([FromRoute] string nome)
    {
        
        var resultado = await _service.GetListaProdutosPorNome(nome);

        if(resultado == null)
            return BadRequest(_service.Erros);

        return Ok(resultado);
    }

    [HttpGet]
    [Route("ValorCrescente")]
    public async Task<IActionResult> GetListaValorCrescente()
    {
        return Ok(await _service.GetListaValorOrdenado(true));
    }

    [HttpGet]
    [Route("ValorDecrescente")]
    public async Task<IActionResult> GetListaValorDecrescente()
    {
        return Ok(await _service.GetListaValorOrdenado(false));
    }

    [HttpGet]
    [Route("EntreValores")]
    public async Task<IActionResult> GetListaProdutosEntreValores([FromQuery] decimal minimo, [FromQuery] decimal maximo)
    {
         var resultado = await _service.GetListaFaixaValor(minimo, maximo);
        
        if(resultado == null)
            return BadRequest(_service.Erros);

        return Ok(resultado);
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