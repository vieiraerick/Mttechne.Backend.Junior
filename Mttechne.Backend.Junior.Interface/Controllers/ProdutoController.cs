using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetListaProdutos() => Ok(_service.GetListaProdutos());

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosProNome([FromRoute] string nome)
    {
        try
        {
            if (string.IsNullOrEmpty(nome))
                return UnprocessableEntity();

            return Ok(_service.GetListaProdutosPorNome(nome));

        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/ProdutosOrdenados/{crescente}")]
    public async Task<IActionResult> GetListaProdutosOrdenadoValor([FromRoute] bool crescente)
    {
        try
        {
            return Ok(_service.GetListaProdutosOrdenadosPorValor(crescente));
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/ProdutosPorFaixaPreco/{minimo}/{maximo}")]
    public async Task<IActionResult> GetListaProdutosPorFaixaPreco([FromRoute] int minimo, int maximo)
    {
        try
        {
            if (maximo < minimo)
                return BadRequest("Valor máximo está abaixo do valor mínimo");

            return Ok(_service.GetListaProdutosEntreFaixaValor(maximo, minimo));

        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/ProdutosPeloValorMaximo")]
    public async Task<IActionResult> GetListaProdutosValorMaximo()
    {
        try
        {
            return Ok(_service.GetListaValoresMaximosCadaProduto());

        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("/ProdutosPeloValorMinimo")]
    public async Task<IActionResult> GetListaProdutosValorMinimo()
    {
        try
        {
            return Ok(_service.GetListaValoresMinimosCadaProduto());

        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}