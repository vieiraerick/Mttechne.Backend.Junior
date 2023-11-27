using Microsoft.AspNetCore.Routing;
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
    public void TestGetListaProdutosByName()
    {
        var produtos = new List<Produto>
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { Nome = "Processador", Valor = 2000 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };

        var produto = new ProdutoService();

        var result = produto.GetListaProdutosByName("Placa de Vídeo");

        var expected = produtos.Where(x => x.Nome == "Placa de Vídeo").ToList();
        Assert.Equal(expected, result, new ProdutoComparer());
    }

    [Fact]
    public void TestGetListaProdutosByPriceAscendinge()
    {
        var produtos = new List<Produto>
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { Nome = "Processador", Valor = 2000 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };

        var produto = new ProdutoService();

        var result = produto.GetListaProdutosByPriceAscendinge();

        var expected = produtos.OrderBy(x => x.Valor).ToList();
        Assert.Equal(expected, result, new ProdutoComparer());
    }

    [Fact]
    public void TestGetListaProdutosByPriceDescending()
    {
        var produtos = new List<Produto>
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { Nome = "Processador", Valor = 2000 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };

        var produto = new ProdutoService();

        var result = produto.GetListaProdutosByPriceDescending();

        var expected = produtos.OrderByDescending(x => x.Valor).ToList();
        Assert.Equal(expected, result, new ProdutoComparer());
    }

    [Fact]
    public void TestGetListaProdutosInPriceRange()
    {
        var produtos = new List<Produto>
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { Nome = "Processador", Valor = 2000 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };

        var produto = new ProdutoService();

        var result = produto.GetListaProdutosInPriceRange(1000, 1350);

        var expected = produtos.Where(x => x.Valor >= 1000 && x.Valor <= 1350).ToList();
        Assert.Equal(expected, result, new ProdutoComparer());
    }

    [Fact]
    public void TestGetListaProdutosPerMaxValue()
    {
        var produtos = new List<Produto>
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { Nome = "Processador", Valor = 2000 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };

        var produto = new ProdutoService();

        var result = produto.GetListaProdutosPerMaxValue();

        var expected = produtos
                .GroupBy(x => x.Nome)
                .Select(group => group.OrderByDescending(x => x.Valor).First())
                .ToList();

        Assert.Equal(expected, result, new ProdutoComparer());
    }

    [Fact]
    public void TestGetListaProdutosPerMinValue()
    {
        var produtos = new List<Produto>
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto() { Nome = "Processador", Valor = 2000 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };

        var produto = new ProdutoService();

        var result = produto.GetListaProdutosPerMinValue();

        var expected = produtos
                .GroupBy(x => x.Nome)
                .Select(group => group.OrderBy(x => x.Valor).First())
                .ToList();

        Assert.Equal(expected, result, new ProdutoComparer());
    }


    public class ProdutoComparer : IEqualityComparer<Produto>
    {
        public bool Equals(Produto x, Produto y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return x.Nome == y.Nome && x.Valor == y.Valor;
        }

        public int GetHashCode(Produto produto)
        {
            if (produto == null) return 0;
            int hashNome = produto.Nome == null ? 0 : produto.Nome.GetHashCode();
            int hashValor = produto.Valor.GetHashCode();
            return hashNome ^ hashValor;
        }
    }
}