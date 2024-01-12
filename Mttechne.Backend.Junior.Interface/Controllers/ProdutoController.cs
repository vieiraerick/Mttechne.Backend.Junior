using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;

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
    public async Task<IActionResult> GetListaProdutos() => Ok(_service.GetListaProdutos());

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosPorNome([FromRoute] string nome)
    {
        try
        {
            return Ok(_service.GetListaProdutosPorNome(nome));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ordenado/{ehCrescente}")]
    public IActionResult GetListaProdutosOrdenadaPorValor([FromRoute] bool ehCrescente = true)
    {
        return Ok(_service.GetListaProdutosOrdenadaPorValor(ehCrescente));
    }

    [HttpGet("faixa-de-preco/{valorMinimo}/{valorMaximo}")]
    public IActionResult GetListaProdutosPorFaixaDePreco([FromRoute] int valorMinimo, [FromRoute] int valorMaximo)
    {
        return Ok(_service.GetListaProdutosPorFaixaDePreco(valorMinimo, valorMaximo));
    }

    [HttpGet("maximos")]
    public IActionResult GetProdutosValoresMaximos()
    {
        return Ok(_service.GetProdutosValoresMaximos());
    }

    [HttpGet("minimos")]
    public IActionResult GetProdutosValoresMinimos()
    {
        return Ok(_service.GetProdutosValoresMinimos());
    }
}