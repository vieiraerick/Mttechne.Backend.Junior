global using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Moq;
using Mttechne.Backend.Junior.Interface.Controllers;
using Mttechne.Backend.Junior.Services.Data;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.Services.Strategies;
using Mttechne.Backend.Junior.Services.Strategies.interfaces;

public sealed class ProdutctServiceTests
{
    private ProdutoController _produtoController { get; set; }
    public ProdutctServiceTests(IProdutoService service, IAttributeValidationStrategy attributeValidationStrategy, IObjectValidationStrategy<Produto> objectValidationStrategy)
    {
        _produtoController = new ProdutoController(service,attributeValidationStrategy,objectValidationStrategy);
    }

    private void AssertListIsNotEmpty(IActionResult result)
    {
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
        Assert.True(okResult.Value is List<Produto> listaProdutosRetornada && listaProdutosRetornada.Count > 0, "A lista de produtos está vazia.");
    }

    private void AssertListBadRequest(IActionResult result, string mensagemRetorno)
    {
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.NotNull(badRequestResult.Value);
        Assert.Equal(mensagemRetorno, badRequestResult.Value?.ToString());
    }


    [Fact]
    public async Task GetListaProdutos_ShouldReturnListOfProducts() =>
       this.AssertListIsNotEmpty(await _produtoController.GetListaProdutos());

    [Theory]
    [InlineData("placa mae")]
    [InlineData("placa de video")]
    [InlineData("memoria")]
    public async Task GetProductsByName_ShouldReturnListOfProductsWhenNameMatches(string name) =>
        this.AssertListIsNotEmpty(await _produtoController.GetListaProdutosProNome(name));

    [Fact]
    public async Task GetProducts_ShouldReturnProductsOrderedByValorAsc() =>
        this.AssertListIsNotEmpty(await _produtoController.GetListaValorCrescente());

    [Fact]
    public async Task GetProducts_ShouldReturnProductsOrderedByValorDesc() =>
         this.AssertListIsNotEmpty(await _produtoController.GetListaValorDecrescente());

    [Theory]
    [InlineData(300, 1000)]
    public async Task GetProducts_ShouldReturnListOfProductsBetweenValores(decimal minimo, decimal maximo) =>
        this.AssertListIsNotEmpty(await _produtoController.GetListaProdutosEntreValores(minimo, maximo));

    [Theory]
    [InlineData(2000, 100)]
    public async Task GetProducts_ShouldReturnBadRequestMinimalValueInvalid(decimal minimo, decimal maximo) =>
        AssertListBadRequest(await _produtoController.GetListaProdutosEntreValores(minimo, maximo), "Minimo: Valor minimo é maior que valor máximo\n");

    [Theory]
    [InlineData(-2000, 100)]
    public async Task GetProducts_ShouldReturnBadRequestForMinimalValueNegative(decimal minimo, decimal maximo) =>
        AssertListBadRequest(await _produtoController.GetListaProdutosEntreValores(minimo, maximo), "Minimo: Valor informado não pode ser menor que zero.\n");


    [Theory]
    [InlineData(2000, -100)]
    public async Task GetProducts_ShouldReturnBadRequestForMaximalValueNegative(decimal minimo, decimal maximo) =>
        AssertListBadRequest(await _produtoController.GetListaProdutosEntreValores(minimo, maximo), "Máximo: Valor informado não pode ser menor que zero.\n");



}