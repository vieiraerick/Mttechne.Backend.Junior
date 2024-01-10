using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using System.Diagnostics;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    private ProdutoService _validacoes = new ProdutoService();
    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }

    [Fact]
    public void BuscaliLtagemProdutosPartirDeUmNome()
    {
        Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };

        List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto8
        };

        List<Produto> produtoEsperado = new List<Produto>()
        {
            produto8
        };

        var resultado = _validacoes.GetListaProdutosPorNome("Placa mãe");

        Assert.True(produtoEsperado.SequenceEqual(resultado));
    }

    [Fact]
    public void BuscarlistagemProdutosOrdenado()
    {
        Produto produto1 = new Produto() { Nome = "Memória", Valor = 300 };
        Produto produto2 = new Produto() { Nome = "Memória", Valor = 350 };
        Produto produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };

        List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto1, produto2, produto3
        };

        var resultado = _validacoes.GetListaProdutosOrdenado(true, false);

        resultado = resultado.Take(3).ToList();


        Assert.True(resultado.SequenceEqual(produtosCadastrados));
    }

    [Fact]
    public void BuscarlistagemProdutosComRange()
    {
        Produto produto1 = new Produto() { Nome = "Memória", Valor = 300 };
        Produto produto2 = new Produto() { Nome = "Memória", Valor = 350 };
        Produto produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };

        List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto1, produto2, produto3
        };

        var resultado = _validacoes.GetListaRangeValoresProduto(10, 1001).Take(3);

        Assert.True(resultado.SequenceEqual(produtosCadastrados));
    }

    [Fact]
    public void BuscarlistagemProdutosAgrupadoPeloMaiorValor()
    {
        Produto produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
        Produto produto2 = new Produto() { Nome = "Processador", Valor = 2100 };
        Produto produto3 = new Produto() { Nome = "Memória", Valor = 350 };
        Produto produto4 = new Produto() { Nome = "Placa mãe", Valor = 1100 };

        List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto1, produto2, produto3, produto4
        };

        var resultado = _validacoes.GetProdutosMaiorEMenorValor(true);

        Assert.True(resultado.SequenceEqual(produtosCadastrados));
    }
}