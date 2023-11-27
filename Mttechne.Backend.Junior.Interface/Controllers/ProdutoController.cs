using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;
using System.Globalization;
using System.Text;

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
        => Ok(_service.GetListaProdutos());

    [HttpGet("{nome}")]
    public async Task<IActionResult> GetListaProdutosPorNome([FromRoute] string nome)
        => Ok(_service.GetListaProdutosByName(nome));

    [HttpGet("ascendinge")]
    public async Task<IActionResult> GetListaProdutosByPriceAscendinge() 
        => Ok(_service.GetListaProdutosByPriceAscendinge());

    [HttpGet("descending")]
    public async Task<IActionResult> GetListaProdutosByPriceDescending()
        => Ok(_service.GetListaProdutosByPriceDescending());

    [HttpGet("price/{minPrice}/{maxPrice}")]
    public async Task<IActionResult> GetListaProdutosInPriceRange([FromRoute] int minPrice, int maxPrice) 
        => Ok(_service.GetListaProdutosInPriceRange(minPrice, maxPrice));

    [HttpGet("maxValue")]
    public async Task<IActionResult> GetListaProdutosPerMaxValue()
        => Ok(_service.GetListaProdutosPerMaxValue());

    [HttpGet("minValue")]
    public async Task<IActionResult> GetListaProdutosPerMinValue()
        => Ok(_service.GetListaProdutosPerMinValue());
}