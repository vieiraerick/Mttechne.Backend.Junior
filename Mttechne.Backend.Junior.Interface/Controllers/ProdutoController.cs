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
    public async Task<IActionResult> GetListaProdutosProNome([FromRoute] string nome) => Ok(_service.GetListaProdutosPorNome(nome));

    [HttpGet("BuscaProdutoOrderByValor/{order}")]
    public async Task<IActionResult> GetListaProdutosOrdenada([FromRoute] string order) => order.ToLower().Equals("asc") ? Ok(_service.GetListaProdutos().OrderBy(x=>x.Valor)) : Ok(_service.GetListaProdutos().OrderByDescending(x => x.Valor));
}