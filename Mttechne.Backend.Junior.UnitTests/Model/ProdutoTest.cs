using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Mttechne.Backend.Junior.Service.Helpers;
using Mttechne.Backend.Junior.Services.Helpers;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.Services.Services.Data;
using Mttechne.Backend.Junior.UnitTests.Fixtures;
using System.Collections.Generic;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

[Collection(nameof(ProdutoCollection))]
public class ProdutoTest
{
    readonly ProdutoTestFixture _produtoFixture;

    public ProdutoTest(ProdutoTestFixture produtoFixture)
    {
        _produtoFixture = produtoFixture;
    }

    [Fact(DisplayName = "Create Produtos")]
    [Trait("Categoria", "Produtos")]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };
        
        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }

    [Fact(DisplayName = "Get Produtos")]
    [Trait("Categoria", "Produtos")]
    public void ShouldGetAProductListWithSuccess()
    {
        var produtos = _produtoFixture.GerarListaProdutoValida();
        var mocker = new AutoMocker();

        mocker
          .GetMock<IProdutoService>()
          .Setup(p => p.GetListaProdutos())
          .Returns(produtos);

        var produtoService = new ProdutoService(_produtoFixture.context);

        var result = produtoService.GetListaProdutos();

        Assert.NotNull(result);
        Assert.IsType<List<Produto>>(result);
        Assert.All(result, Item => Assert.False(string.IsNullOrEmpty(Item.Nome)));
        Assert.All(result, Item => Assert.False(Item.Valor <= 0));
    }

    [Trait("Categoria", "Produtos")]
    [Theory(DisplayName = "Get Produtos por nome")]
    [InlineData("Placa")]
    [InlineData("video")]
    [InlineData("vídeo")]
    [InlineData("memoria")]
    [InlineData("memória")]
    public void ShouldGetAProductListByNameWithSuccess(string nome)
    {
        var produtos = _produtoFixture.GerarListaProdutoValida();
        var mocker = new AutoMocker();

        var produtoService = new ProdutoService(_produtoFixture.context);

        mocker
            .GetMock<IProdutoService>()
            .Setup(p => p.GetListaProdutosPorNome(nome))
            .Returns(produtos);

        var result = produtoService.GetListaProdutosPorNome(nome);

        nome = RemoveDiacritcsHelper.RemoveDiacritics(nome).ToLower();

        Assert.NotNull(result);
        Assert.IsType<List<Produto>>(result);
        Assert.All(result, Item => Assert.False(string.IsNullOrEmpty(Item.Nome)));
        Assert.All(result, Item => Assert.True(RemoveDiacritcsHelper.RemoveDiacritics(Item.Nome).ToLower().Contains(nome)));
    }


    [Trait("Categoria", "Produtos")]
    [Theory(DisplayName = "Get Produtos entre range")]
    [InlineData(100, 200)]
    [InlineData(300, 600)]
    [InlineData(700, 800)]
    [InlineData(100, 2000)]
    public void ShouldGetAProductListByNameWithSuccsess(decimal min, decimal max)
    {
        var produtos = _produtoFixture.GerarListaProdutoValida();
        var mocker = new AutoMocker();

        var produtoService = new ProdutoService(_produtoFixture.context);

        mocker
            .GetMock<IProdutoService>()
            .Setup(p => p.GetListaProdutosEntreValores(min, max))
            .Returns(produtos);

        var result = produtoService.GetListaProdutosEntreValores(min, max);

        Assert.NotNull(result);
        Assert.IsType<List<Produto>>(result);
        Assert.All(result, Item => Assert.InRange(Item.Valor, min, max));
    }

    [Fact(DisplayName = "Get Produtos Maiores valores")]
    [Trait("Categoria", "Produtos")]
    public void ShouldGetAMaxValuedProductstWithSuccsess()
    {
        var produtos = _produtoFixture.GerarListaProdutoValida();
        var mocker = new AutoMocker();

        var produtoService = new ProdutoService(_produtoFixture.context);

        mocker
            .Setup<IProdutoService, List<Produto>>(p => p.GetListaValoresMaximos())
            .Returns(produtos);

        var result = produtoService.GetListaValoresMaximos();

        Assert.NotNull(result);
        Assert.IsType<List<Produto>>(result);
        Assert.Equal(4, result.Count);
        Assert.Equal(produtos.Max(x => x.Valor), result.Max(x => x.Valor));
    }

    [Fact(DisplayName = "Get Produtos Menores valores")]
    [Trait("Categoria", "Produtos")]
    public void ShouldGetAMinValuedProductstWithSuccsess()
    {
        var produtos = _produtoFixture.GerarListaProdutoValida();
        var mocker = new AutoMocker();

        var produtoService = new ProdutoService(_produtoFixture.context);

        mocker
            .GetMock<IProdutoService>()
            .Setup(p => p.GetListaValoresMinimos())
            .Returns(produtos);

        var result = produtoService.GetListaValoresMinimos();

        Assert.NotNull(result);
        Assert.IsType<List<Produto>>(result);
        Assert.Equal(4, result.Count);
        Assert.Equal(produtos.Min(x => x.Valor), result.Min(x => x.Valor));
    }

    [Fact(DisplayName = "Get Produtos Ordenados Ascendente")]
    [Trait("Categoria", "Produtos")]
    public void ShouldGetAAscOrderedProductstWithSuccsess()
    {
        var produtos = _produtoFixture.GerarListaProdutoValida();
        var mocker = new AutoMocker();
        var expectedList = produtos
          .OrderBy(p => p.Valor)
          .ToList();

        //mocker.Use<ApplicationDbContext>(_context);
        var produtoService = new ProdutoService(_produtoFixture.context);
        var produtoComparer = new ProductComparer();

        mocker
            .GetMock<IProdutoService>()
            .Setup(p => p.GetListaOrdenada("asc"))
            .Returns(produtos);

        var result = produtoService.GetListaOrdenada("asc");

        Assert.NotNull(result);
        Assert.IsType<List<Produto>>(result);
        Assert.True(Enumerable.SequenceEqual(expectedList, result, produtoComparer));
    }

    [Fact(DisplayName = "Get Produtos Ordenados Descendente")]
    [Trait("Categoria", "Produtos")]
    public void ShouldGetADescOrderedProductstWithSuccsess()
    {
        var produtos = _produtoFixture.GerarListaProdutoValida();
        var mocker = new AutoMocker();

        var expectedList = produtos
          .OrderBy(p => p.Valor)
          .ToList();

        var produtoService = new ProdutoService(_produtoFixture.context);
        var produtoComparer = new ProductComparer();

        mocker
            .GetMock<IProdutoService>()
            .Setup(p => p.GetListaOrdenada("asc"))
            .Returns(produtos);

        var result = produtoService.GetListaOrdenada("asc");

        Assert.NotNull(result);
        Assert.IsType<List<Produto>>(result);
        Assert.True(Enumerable.SequenceEqual(expectedList, result, produtoComparer));
    }

}