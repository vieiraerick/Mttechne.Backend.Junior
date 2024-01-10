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


    /*
     * Aqui criei uma rota nova para Ordernação, sempre dando prioridade para a Crescente
     * daria para usar a mesma do GetListaProdutos mas a GetListaProdutosProNome usa ela preferi
     * criar a interface, metódo e Endpoint tudo novo
     */
    [HttpGet("Ordenado")]
    public async Task<IActionResult> GetListaProdutosOrdenado(bool? OrdemCrescente, bool? OrdemDescrecente) => Ok(_service.GetListaProdutosOrdenado(OrdemCrescente, OrdemDescrecente));

    /*
     * Range Valores
    */
    [HttpGet("RangeValores")]
    public async Task<IActionResult> GetListaRangeValoresProduto(int ValorMin, int ValorMax)
    {
        if (ValorMin > ValorMax)
        {
            return BadRequest("Valor minimo não pode ser maior que o máximo");
        }

        var resultado = _service.GetListaRangeValoresProduto(ValorMin, ValorMax);

        if (resultado.Count() > 0)
            return Ok(resultado);
        else
            return BadRequest("Produtos com esse Range de valores não encontrado");
    }

    /*
   * Maior valor de cada produto
  */
    [HttpGet("MaiorValor")]
    public async Task<IActionResult> MaiorValor() => Ok(_service.GetProdutosMaiorEMenorValor(true));

    /*
    * Maior valor de cada produto
    */
    [HttpGet("MenorValor")]
    public async Task<IActionResult> MenorValor() => Ok(_service.GetProdutosMaiorEMenorValor(false));
}