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

    [HttpGet("produtos-valor-crescente")]
    public async Task<IActionResult> GetListaProdutosPorValorCrescente()
    {
        return Ok(_service.GetListaProdutos().OrderBy(x => x.Valor));
    }

    [HttpGet("produtos-valor-decrescente")]
    public async Task<IActionResult> GetListaProdutosPorValorDecrescente()
    {
        return Ok(_service.GetListaProdutos().OrderByDescending(x => x.Valor));
    }

    [HttpGet("produtos-valor-maximo")]
    public async Task<IActionResult> GetListaProdutosPorValorMaximo()
    {
        return Ok(_service.GetListaProdutosPorValorMaximo());
    }

    [HttpGet("produtos-valor-minimo")]
    public async Task<IActionResult> GetListaProdutosPorValorMinimo()
    {
        return Ok(_service.GetListaProdutosPorValorMinimo());
    }

    [HttpGet("produtos-valor-intervalo/{inicial}/{final}")]
    public async Task<IActionResult> GetListaProdutosPorValorInterva([FromRoute] int inicial, int final)
    {
        if (inicial < 0)
            return BadRequest("Favor informar um valor inicial maior que 0");

        return Ok(_service.GetListaProdutosPorIntervalo(inicial, final));
    }

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosPorNome([FromRoute] string nome)
    {
        if (string.IsNullOrEmpty(nome))
            return BadRequest("Favor informar um valor para o nome");

        return Ok(_service.GetListaProdutosPorNome(nome));
    }


}