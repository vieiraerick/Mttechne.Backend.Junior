using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Interface.Controllers;
using Mttechne.Backend.Junior.Services.Context;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    public static DbContextOptions<AppDBContext> dbContextOptions { get;}

    private AppDBContext _appDBContext;
    public static string connString = "Server=localhost;DataBase=ProjetoMttechne;Uid=root;Pwd=SENHA";
    private static IProdutoService _produtoService;

    static ProdutoTest()
    {
        dbContextOptions = new DbContextOptionsBuilder<AppDBContext>()
            .UseMySql(connString, ServerVersion.AutoDetect(connString))
            .Options;
    }

    public ProdutoTest()
    {
        _appDBContext = new AppDBContext(dbContextOptions);
        _produtoService = new ProdutoService(_appDBContext);
    }

    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };
        
        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }

    [Fact]
    public async void GetListaProdutosWithSuccess()
    {
        var controller = new ProdutoController(_produtoService);

        var data =  controller.GetListaProdutos();

        Assert.IsType<OkObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosWithBadRequest()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutos();

        Assert.IsType<BadRequestObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosPorNomeWithSuccess()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosPorNome("Memória");

        Assert.IsType<OkObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosPorNomeWithBadRequest()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosPorNome("Memória");

        Assert.IsType<BadRequestObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosPorNomeWithNoContent()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosPorNome("teste sem resultado");

        Assert.IsType<NoContentResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosOrdenadaWithSuccess()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosOrdenada("asc");

        Assert.IsType<OkObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosOrdenadaWithBadRequest()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosOrdenada("asc");

        Assert.IsType<BadRequestObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosEntreValoresWithSuccess()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosEntreValores(1, 3000);

        Assert.IsType<OkObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosEntreValoresWithConflict()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosEntreValores(3000, 1000);

        Assert.IsType<ConflictObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosEntreValoresWithBadRequest()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosEntreValores(1, 3000);

        Assert.IsType<BadRequestObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosPorValorMaximoWithSuccess()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosPorValorMaximo();

        Assert.IsType<OkObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosPorValorMaximoWithBadRequest()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosPorValorMaximo();

        Assert.IsType<BadRequestObjectResult>(data.Result);
    }

    [Fact]
    public async void GetListaProdutosPorValorMinimoWithSuccess()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosPorValorMinimo();

        Assert.IsType<OkObjectResult>(data.Result);
    }
    [Fact]
    public async void GetListaProdutosPorValorMinimoWithBadRequest()
    {
        var controller = new ProdutoController(_produtoService);

        var data = controller.GetListaProdutosPorValorMinimo();

        Assert.IsType<BadRequestObjectResult>(data.Result);
    }



}