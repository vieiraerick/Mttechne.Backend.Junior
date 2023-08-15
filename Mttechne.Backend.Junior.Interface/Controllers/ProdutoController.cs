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
    public async Task<IActionResult> GetListaProdutosPorNome([FromRoute] string nome) => Ok(_service.GetListaProdutosPorNome(nome));

    [HttpGet("valorCrescente")]
    public async Task<IActionResult> GetListaProdutosValorCrescente() => Ok(_service.GetListaProdutosValorCrescente());

    [HttpGet("valorDecrescente")]
    public async Task<IActionResult> GetListaProdutosValorDecrescente() => Ok(_service.GetListaProdutosValorDecrescente());

    [HttpGet("faixaDePreco")]
    public async Task<IActionResult> GetListaProdutosFaixaDePreco(decimal? valorMinimo, decimal? valorMaximo) => 
        Ok(_service.GetListaProdutosFaixaDePreco(valorMinimo, valorMaximo));

    [HttpGet("maiorValor")]
    public async Task<IActionResult> GetListaProdutosMaiorValor() => Ok(_service.GetListaProdutosMaiorValor());

    [HttpGet("menorValor")]
    public async Task<IActionResult> GetListaProdutosMenorValor() => Ok(_service.GetListaProdutosMenorValor());
}