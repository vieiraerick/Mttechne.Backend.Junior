using Moq;
using Mttechne.Backend.Junior.Domain.Model;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    private readonly IProdutoService _service;
    private readonly Mock<IProdutoRepository> _repository;

    public ProdutoTest()
    {
        _repository = new Mock<IProdutoRepository>();
        _service = new ProdutoService(_repository.Object);
    }

    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }


    [Fact]
    public void BuscaliLtagemProdutosAll()
    {
        List<Produto> produtoEsperado = new List<Produto>()
        {
            new Produto() { Id = 1, Nome = "Placa de Vídeo", Valor = 1000 },
            new Produto() { Id = 2, Nome = "Placa de Vídeo", Valor = 1500 },
            new Produto() { Id = 3, Nome = "Placa de Vídeo", Valor = 1350 },
            new Produto() { Id = 4, Nome = "Processador", Valor = 2000 },
            new Produto() { Id = 5, Nome = "Processador", Valor = 2100 },
            new Produto() { Id = 6, Nome = "Memória", Valor = 300 },
            new Produto() { Id = 7, Nome = "Memória", Valor = 350 },
            new Produto() { Id = 8, Nome = "Placa mãe", Valor = 1100 }
        };


        _repository.Setup(v=> v.GetListaProdutos())
                   .Returns(produtoEsperado);

        var resultado = _service.GetListaProdutos();

        Assert.True(produtoEsperado.SequenceEqual(resultado));
    }



    [Fact]
    public void BuscaliLtagemProdutosPartirDeUmNome()
    {
        Produto produto8 = new Produto() { Id = 8, Nome = "Placa mãe", Valor = 1100 };


        List<Produto> produtoEsperado = new List<Produto>()
        {
            produto8
        };

        _repository.Setup(v => v.GetListaProdutos())
                .Returns(produtoEsperado);

        var resultado = _service.GetListaProdutosPorNome("Placa mãe");
        

        Assert.True(produtoEsperado.SequenceEqual(resultado));
    }

    [Fact]
    public void BuscarlistagemProdutosOrdenado()
    {
        Produto produto1 = new Produto() { Id = 6, Nome = "Memória", Valor = 300 };
        Produto produto2 = new Produto() { Id = 7, Nome = "Memória", Valor = 350 };
        Produto produto3 = new Produto() { Id = 1, Nome = "Placa de Vídeo", Valor = 1000 };

        List<Produto> produtoEsperado = new List<Produto>()
        {
            produto1, produto2, produto3
        };
        _repository.Setup(v => v.GetListaProdutos())
             .Returns(produtoEsperado);

        var resultado = _service.GetListaProdutosOrdenado(true, false);

        resultado = resultado.Take(3).ToList();


        Assert.True(resultado.SequenceEqual(produtoEsperado));
    }

    [Fact]
    public void BuscarlistagemProdutosComRange()
    {
        Produto produto1 = new Produto() { Id = 6, Nome = "Memória", Valor = 300 };
        Produto produto2 = new Produto() { Id = 7, Nome = "Memória", Valor = 350 };
        Produto produto3 = new Produto() { Id = 1, Nome = "Placa de Vídeo", Valor = 1000 };

        List<Produto> produtoEsperado = new List<Produto>()
        {
            produto1, produto2, produto3
        };

        _repository.Setup(v => v.GetListaProdutos())
             .Returns(produtoEsperado);

        var resultado = _service.GetListaRangeValoresProduto(10, 1001).Take(3);

        Assert.True(resultado.SequenceEqual(produtoEsperado));
    }

    [Fact]
    public void BuscarlistagemProdutosAgrupadoPeloMaiorValor()
    {
        Produto produto1 = new Produto() { Id = 2, Nome = "Placa de Vídeo", Valor = 1500 };
        Produto produto2 = new Produto() { Id = 5, Nome = "Processador", Valor = 2100 };
        Produto produto3 = new Produto() { Id = 7, Nome = "Memória", Valor = 350 };
        Produto produto4 = new Produto() { Id = 8, Nome = "Placa mãe", Valor = 1100 };

        List<Produto> produtoEsperado = new List<Produto>()
        {
            produto1, produto2, produto3, produto4
        };

        _repository.Setup(v => v.GetListaProdutos())
           .Returns(produtoEsperado);

        var resultado = _service.GetProdutosMaiorEMenorValor(true);

        Assert.True(resultado.SequenceEqual(produtoEsperado));
    }
}