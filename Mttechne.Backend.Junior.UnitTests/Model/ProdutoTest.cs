using Moq;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.Services.Extensions;
using Mttechne.Backend.Junior.Services.Strategies;
using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    private readonly Mock<IProdutoService> _produtoService;


    private AttributeValidationStrategy _attributeValidationStrategy;
    private readonly ProductValidationStrategy _produtoValidationStrategy;
    public ProdutoTest()
    {
        _produtoService = new Mock<IProdutoService>();
        _attributeValidationStrategy = new AttributeValidationStrategy();
        _produtoValidationStrategy = new ProductValidationStrategy(new AttributeValidationStrategy());
    }

    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }

    private bool IsValidRange(decimal minimo, decimal maximo) => _produtoValidationStrategy.IsMaximoMinimoValid(minimo, maximo);


    private async Task TestValueRange(decimal minimo, decimal maximo, bool testError)
    {
        _produtoService.Setup(x => x.GetListaFaixaValor(minimo, maximo))
                .Returns(Task.FromResult(ListaDeProdutosPadrao.Where(x => x.Valor >= minimo && x.Valor <= maximo).OrderBy(x => x.Valor).ToList()));

        if (!testError && IsValidRange(minimo,maximo))
            this.AssertListHasList(await _produtoService.Object.GetListaFaixaValor(minimo, maximo));
        else
            this.AssertHasNoList(null);
    }

    private List<Produto> ListaDeProdutosPadrao = new List<Produto>()  {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { Nome = "Processador", Valor = 2000 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 },
            };



    private void AssertListHasList(List<Produto>? result) => Assert.True(result != null && result.Count > 0, "A lista de produtos está vazia.");

    private void AssertHasNoList(List<Produto>? result) => Assert.Null(result);


    [Fact]
    public async Task GetListaProdutos_ShouldReturnListOfProducts()
    {
        _produtoService.Setup(x => x.GetListaProdutos()).ReturnsAsync(ListaDeProdutosPadrao);
        this.AssertListHasList(await _produtoService.Object.GetListaProdutos());
    }



    [Theory]
    [InlineData("placa mae")]
    [InlineData("placa de video")]
    [InlineData("memoria")]
    public async Task GetListaProdutos_DeveRetornarListaDeProdutosByName(string name)
    {
        _produtoService.Setup(x => x.GetListaProdutosPorNome(name))
        .ReturnsAsync(ListaDeProdutosPadrao.Where(x => x.Nome.RemoverAcentuacao().IndexOf(name.RemoverAcentuacao(),
        StringComparison.OrdinalIgnoreCase) >= 0).ToList());

        this.AssertListHasList(await _produtoService.Object.GetListaProdutosPorNome(name));
    }

    [Fact]
    public async Task GetProducts_ShouldReturnProductsOrderedByValorAsc()
    {
        _produtoService.Setup(x => x.GetListaValorOrdenado(true)).ReturnsAsync(ListaDeProdutosPadrao.OrderBy(x => x.Valor).ToList());
        this.AssertListHasList(await _produtoService.Object.GetListaValorOrdenado(true));
    }



    [Fact]
    public async Task GetProducts_ShouldReturnProductsOrderedByValorDesc()
    {
        _produtoService.Setup(x => x.GetListaValorOrdenado(false)).ReturnsAsync(ListaDeProdutosPadrao.OrderByDescending(x => x.Valor).ToList());
        this.AssertListHasList(await _produtoService.Object.GetListaValorOrdenado(false));
    }

    [Theory]
    [InlineData(300, 1000)]
    public async Task GetProducts_ShouldReturnListOfProductsBetweenValores(decimal minimo, decimal maximo)
        => await TestValueRange(minimo, maximo,false);

    //Teste de Erro
    [Theory]
    [InlineData(2000, 100)]
    public async Task GetProducts_ShouldReturnBadRequestMinimalValueInvalid(decimal minimo, decimal maximo)
         => await TestValueRange(minimo, maximo,true);
    //Teste de Erro
    [Theory]
    [InlineData(-2000, 100)]
    public async Task GetProducts_ShouldReturnBadRequestForMinimalValueNegative(decimal minimo, decimal maximo)
       => await TestValueRange(minimo, maximo,true);
    //Teste de Erro
    [Theory]
    [InlineData(2000, -100)]
    public async Task GetProducts_ShouldReturnBadRequestForMaximalValueNegative(decimal minimo, decimal maximo)
       => await TestValueRange(minimo, maximo,true);


    [Fact]
    public async Task GetProdicts_ShouldReturnMinimalValue()
    {
        _produtoService.Setup(x => x.GetListaMinValor()).ReturnsAsync(ListaDeProdutosPadrao.OrderBy(p => p.Valor).Take(1).ToList());
        this.AssertListHasList(await _produtoService.Object.GetListaMinValor());
    }

    [Fact]
    public async Task GetProdicts_ShouldReturnMaximumValue()
    {
        _produtoService.Setup(x => x.GetListaMaxValor()).ReturnsAsync(ListaDeProdutosPadrao.OrderByDescending(p => p.Valor).Take(1).ToList());
        this.AssertListHasList(await _produtoService.Object.GetListaMaxValor());
    }



}