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
    public async Task<IActionResult> GetListaProdutos()
    {
        try
        {
            return Ok(_service.GetListaProdutos());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosPorNome([FromRoute] string nome)
    {
        try
        {
            var data = _service.GetListaProdutosPorNome(nome);

            if (data.Count() == 0)
                return NoContent();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("BuscaProdutoOrderByValor/{order}")]
    public async Task<IActionResult> GetListaProdutosOrdenada([FromRoute] string order)
    {
        try
        {
            return order.ToLower().Equals("asc") ? Ok(_service.GetListaProdutos().OrderBy(x => x.Valor)) : Ok(_service.GetListaProdutos().OrderByDescending(x => x.Valor));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("BuscaProdutoEntreValores/{valorInicial}/{valorFinal}")]
    public async Task<IActionResult> GetListaProdutosEntreValores([FromRoute] double valorInicial, double valorFinal)
    {
        try
        {
            if (valorFinal <= valorInicial)
                return Conflict("Os valores do filtro estão inválidos");
            return Ok(_service.GetListaProdutosPorIntervaloValores(valorInicial, valorFinal));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("BuscaProdutoValorMaximo")]
    public async Task<IActionResult> GetListaProdutosPorValorMaximo()
    {
        try
        {
            return Ok(_service.GetListaProdutosPorValorMaximo());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("BuscaProdutoValorMinimo")]
    public async Task<IActionResult> GetListaProdutosPorValorMinimo()
    {
        try
        {
            return Ok(_service.GetListaProdutosPorValorMinimo());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}