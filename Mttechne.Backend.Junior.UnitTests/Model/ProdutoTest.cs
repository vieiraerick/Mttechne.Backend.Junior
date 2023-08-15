using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };
        
        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }

    [Fact]
    public void ShouldReturnProductByNameWithSuccess()
    {
        var service = new ProdutoService();
        var resultadoEsperado = "Placa de Vídeo";
        var buscaProduto = "placa de vid";

        var result = service.GetListaProdutosPorNome(buscaProduto);

        Assert.Contains(result, produto => produto.Nome.Equals(resultadoEsperado, StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void ShouldReturnAscendingOrderedList()
    {
        var service = new ProdutoService();

        var result = service.GetListaProdutosValorCrescente();

        Assert.True(result.SequenceEqual(result.OrderBy(x => x.Valor)));
    }

    [Fact]
    public void ShouldReturnDescendingOrderedList()
    {
        var service = new ProdutoService();

        var result = service.GetListaProdutosValorDecrescente();

        Assert.True(result.SequenceEqual(result.OrderByDescending(x => x.Valor)));
    }

    [Fact]
    public void ShouldReturnProductsInRangeOfPrices()
    {
        var service = new ProdutoService();
        decimal minValue = 300;
        decimal maxValue = 1500;

        var result = service.GetListaProdutosFaixaDePreco(minValue, maxValue);

        Assert.True(result.All(x => x.Valor >= minValue && x.Valor <= maxValue));
    }

    [Fact]
    public void ShouldReturnProductsByMaxValue()
    {
        var service = new ProdutoService();

        var result = service.GetListaProdutosMaiorValor();

        for (int i = 1; i < result.Count; i++)
        {
            Assert.True(result[i - 1].Valor >= result[i].Valor);
        }
    }

    [Fact]
    public void ShouldReturnProductsByMinValue()
    {
        var service = new ProdutoService();

        var result = service.GetListaProdutosMenorValor();

        for (int i = 1; i < result.Count; i++)
        {
            Assert.True(result[i - 1].Valor <= result[i].Valor);
        }
    }
}