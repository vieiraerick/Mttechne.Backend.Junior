using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Model;
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

    [HttpGet("Preço")]
    public async Task<IActionResult> GetListaProdutosPorPreço([FromQuery] int? order)
    {
        if(order.HasValue)
        {
            return Ok(_service.GetProdutosPorValor(order.Value, _service.GetListaProdutos()));
        }

        return Ok(_service.GetProdutosPorValor(0,_service.GetListaProdutos()));
    }

    [HttpGet("Faixa")]
    public async Task<IActionResult> GetProdutosFaixaPreço(double valor_inicial, double valor_final)
    {
        return Ok(_service.GetProdutosFaixa(valor_inicial, valor_final, _service.GetListaProdutos()));
    }

    [HttpGet("MaiorValor")]
    public async Task<IActionResult> GetProdutosMaiorValor()
    {
        return Ok(_service.ValoresExtremos(1, _service.GetListaProdutos()));
    }

    [HttpGet("MenorValor")]
    public async Task<IActionResult> GetProdutosMenorValor()
    {
        return Ok(_service.ValoresExtremos(0, _service.GetListaProdutos()));
    }
}