using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Interface;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;

    }

    [HttpGet("Lista_Produtos")]
    public IActionResult GetListaProdutos()
    {
        try
        {
            return Ok(_produtoService.GetListaProdutos());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("Lista_Produtos_Por_Nome/{nome}")]
    public IActionResult GetListaProdutosPorNome([FromRoute] string nome)
    {
        try
        {
            var retorno = _produtoService.GetListaProdutosPorNome(nome);
            return (retorno.Count() == 0) ? Ok("Produto não encontrado!") : Ok(retorno);
           
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao consultar.", ex);
        }
    }

    [HttpGet("GetValorMaximo")]
    public IActionResult GetValorMaximo() => Ok(_produtoService.GetValorMaximo());

    [HttpGet("GetValorMinimo")]
    public IActionResult GetValorMinimo() => Ok(_produtoService.GetValorMinimo());


    [HttpGet("GetFaixaDePreco/{valorMin}/{valorMax}")]
    public IActionResult GetFaixaDePreco([FromRoute] decimal valorMin, decimal valorMax)
    {
        try
        { 
        return valorMax <= valorMin ?
          Conflict("O valor do filtro Valor minimo deve ser menor que o de valor máximo!"):
          Ok(_produtoService.GetFaixaDePreco(valorMin, valorMax));
        }
        catch(Exception ex)
        { return BadRequest(ex.Message); }
    }
       

    [HttpGet("GetListaOrdenadaPorValorDecrescente")]
    public IActionResult GetListaOrdenadaPorValorDecrescente() => Ok(_produtoService.GetListaOrdenadaPorValorDecrescente());

    [HttpGet("GetListaOrdenadaPorValorCrescente")]
    public IActionResult GetListaOrdenadaPorValorCrescente() => Ok(_produtoService.GetListaOrdenadaPorValorCrescente());
}