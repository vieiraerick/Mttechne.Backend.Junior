using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    public IProdutoService _produtoService = new ProdutoService();

    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }

    [Fact]
    public void ShouldGetProductsInDescendingOrder()
    {
        Produto produto1 = new Produto() { Nome = "abacaxi", Valor = 10 };
        Produto produto2 = new Produto() { Nome = "maça", Valor = 2 };
        Produto produto3 = new Produto() { Nome = "damasco", Valor = 15 };

        List<Produto> EmOrdem = new() { produto2, produto1, produto3 };

        List<Produto> ForaDeOrdem = new() { produto1, produto2, produto3 };

        List<Produto> retorno = _produtoService.GetProdutosPorValor(0, ForaDeOrdem);

        Assert.Equal(EmOrdem, retorno);
    }

    [Fact]
    public void ShouldGetProductsInAscendingOrder()
    {
        Produto produto1 = new Produto() { Nome = "abacaxi", Valor = 10 };
        Produto produto2 = new Produto() { Nome = "maça", Valor = 2 };
        Produto produto3 = new Produto() { Nome = "damasco", Valor = 15 };

        List<Produto> EmOrdem = new() { produto3, produto1, produto2 };

        List<Produto> ForaDeOrdem = new() { produto1, produto2, produto3 };

        List<Produto> retorno = _produtoService.GetProdutosPorValor(1, ForaDeOrdem);

        Assert.Equal(EmOrdem, retorno);
    }

    [Fact]
    public void Should_GetProducts_In_Budget_Range()
    {
        Produto produto1 = new Produto() { Nome = "Processador", Valor = 100 };
        Produto produto2 = new Produto() { Nome = "Processador", Valor = 200 };
        Produto produto3 = new Produto() { Nome = "Memória", Valor = 300 };
        Produto produto4 = new Produto() { Nome = "Memória", Valor = 400 };
        Produto produto5 = new Produto() { Nome = "Placa mãe", Valor = 500 };

        List<Produto> produtos = new()
        {
            produto1, produto2, produto3, produto4, produto5
        };

        List<Produto> lista_resposta = new()
        {
            produto2, produto3, produto4
        };

        List<Produto> retorno = _produtoService.GetProdutosFaixa(200, 400, produtos);

        Assert.Equal(lista_resposta, retorno);
    }

    [Fact]
    public void Should_Return_Cheapest_Of_Each_Produto()
    {
        Produto produto1 = new() { Nome = "Mexirica", Valor = 4 };
        Produto produto2 = new() { Nome = "Mexirica", Valor = 10 };

        Produto produto3 = new() { Nome = "Banana", Valor = 2 };
        Produto produto4 = new() { Nome = "Banana", Valor = 9 };

        Produto produto5 = new() { Nome = "Melão", Valor = 2 };
        Produto produto6 = new() { Nome = "Melão", Valor = 7 };

        List<Produto> produtos = new()
        {
            produto1, produto2, produto3, produto4, produto5, produto6
        };

        List<Produto> lista_resposta = new() { produto1, produto3, produto5 };

        List<Produto> retorno = _produtoService.ValoresExtremos(0, produtos);

        Assert.Equal(lista_resposta, retorno);

    }

    public void Should_Return_Most_Expensive_Of_Each_Produto()
    {
        Produto produto1 = new() { Nome = "Mexirica", Valor = 4 };
        Produto produto2 = new() { Nome = "Mexirica", Valor = 10 };

        Produto produto3 = new() { Nome = "Banana", Valor = 2 };
        Produto produto4 = new() { Nome = "Banana", Valor = 9 };

        Produto produto5 = new() { Nome = "Melão", Valor = 2 };
        Produto produto6 = new() { Nome = "Melão", Valor = 7 };

        List<Produto> produtos = new()
        {
            produto1, produto2, produto3, produto4, produto5, produto6
        };

        List<Produto> lista_resposta = new() { produto1, produto3, produto5 };

        List<Produto> retorno = _produtoService.ValoresExtremos(1, produtos);

        Assert.Equal(lista_resposta, retorno);

    }

}