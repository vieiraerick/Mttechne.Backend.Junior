using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;
using System.Runtime.Intrinsics.Arm;

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
        if(string.IsNullOrEmpty(nome))
        {
            return BadRequest("Por favor, insira um nome!");
        }
        
        return Ok(_service.GetListaProdutosPorNome(nome));
    }

    [HttpGet("{min}/{max}")]
    public async Task<IActionResult> GetListaProdutosEntreValores([FromRoute] decimal min, [FromRoute] decimal max)
    {
        return Ok(_service.GetListaProdutosEntreValores(min, max));
    }

    [HttpGet("/ValoresMaximos")]
    public async Task<IActionResult> GetValoresMaximos()
    {
        return Ok(_service.GetListaValoresMaximos());
    }

    [HttpGet("/ValoresMinimos")]
    public async Task<IActionResult> GetValoresMinimos()
    {
        return Ok(_service.GetListaValoresMinimos());
    }

    [HttpGet("/GetListaOrdenada/{ordem}")]
    public async Task<IActionResult> GetListaOrdenada([FromRoute] string ordem)
    {
        if (string.IsNullOrEmpty(ordem) || (ordem != "asc" && ordem != "desc"))
        {
            return BadRequest("Por favor, a ordem deve ser especificada como 'asc' ou 'desc'.");
        }

        return Ok(_service.GetListaOrdenada(ordem));
    }
}