using Moq;
using Mttechne.Backend.Junior.Services.Interface;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{

    //[Fact]
    //public void ShouldCreateAProductWithSuccess()
    //{
    //    var teclado = new Produto() { Nome = "Teclado", Valor = 100 };

    //    Assert.Equal(100, teclado.Valor);
    //    Assert.Equal("Teclado", teclado.Nome);
    //}

    [Fact]
    public void Lista_Produtos_DeveRetornarTodosOsProdutosComSucesso()
    {
        //Arrange
       
        var produto = new Produto()
        {
            Id = 1,
            Nome = "Placa de Vídeo",
            Valor = 1000
        };
        var produto2 = new Produto()
        {
            Id = 2,
            Nome = "Teclado",
            Valor = 5000
        };

        var produto3 = new Produto()
        {
            Id = 3,
            Nome = "Mouse",
            Valor = 1200
        };
        var produto4 = new Produto()
        {
            Id = 4,
            Nome = "Notebook",
            Valor = 6000
        };

        var listaProd = new List<Produto>();
        listaProd.Add(produto);
        listaProd.Add(produto2);
        listaProd.Add(produto3);
        listaProd.Add(produto4);


        var retornoEsperado = new List<Produto>();
        retornoEsperado.AddRange(listaProd);
        var mock = new Mock<IProdutoRepository>();
        mock.Setup(x => x.GetListaProdutos()).Returns(listaProd);
        var produtoRepository = mock.Object;
        var produtoService = new ProdutoService(produtoRepository);

        //Act
        var resposta = produtoService.GetListaProdutos();
        //Assert

        Assert.Equal(retornoEsperado, resposta);
    }

    [Fact]
    public void GetFaixaDePreco_DeveRetornarProdutosDentroDaFaixaDePrecoComSucesso()
    {
        //Arrange
        var min = 10;
        var max = 3400;

        var produto = new Produto()
        {
            Id = 1,
            Nome = "Placa de Vídeo",
            Valor = 1000
        };
        var produto2 = new Produto()
        {
            Id = 2,
            Nome = "Teclado",
            Valor = 5000
        };

        var listaProd = new List<Produto>();
        listaProd.Add(produto);
        listaProd.Add(produto2);

        var retornoEsperado = new List<Produto>();
        retornoEsperado.Add(produto);
        var mock = new Mock<IProdutoRepository>();
        mock.Setup(x => x.GetListaProdutos()).Returns(listaProd);
        var produtoRepository = mock.Object;
        var produtoService = new ProdutoService(produtoRepository);

        //Act
        var resposta = produtoService.GetFaixaDePreco(min, max);
        //Assert

        Assert.Equal(retornoEsperado, resposta);
    }

    [Fact]
    public void GetListaProdutosPorNome_DeveRetornarProdutosPorNomeSolicitadoPorParametroComSucesso()
    {
        //Arrange
        
        var nome = "Teclado";//Declaração do parâmetro de busca


        var produto = new Produto()
        {
            Id = 1,
            Nome = "Placa de Vídeo",
            Valor = 1000
        };
        var produto2 = new Produto()
        {
            Id = 2,
            Nome = "Teclado",
            Valor = 5000
        };

        var listaProd = new List<Produto>();
        listaProd.Add(produto);
        listaProd.Add(produto2);

        var retornoEsperado = new List<Produto>();
        retornoEsperado.Add(produto2);
        var mock = new Mock<IProdutoRepository>();
        mock.Setup(x => x.GetListaProdutos()).Returns(listaProd);
        var produtoRepository = mock.Object;
        var produtoService = new ProdutoService(produtoRepository);

        //Act
        var resposta = produtoService.GetListaProdutosPorNome(nome);
        //Assert

        Assert.Equal(retornoEsperado, resposta);
    }

    [Fact]
    public void GetValorMaximo_DeveRetornarProdutosDistintosPorValorMaximoComSucesso()
    {
        //Arrange


        var produto = new Produto()
        {
            Id = 1,
            Nome = "Teclado",
            Valor = 1000
        };
        var produto2 = new Produto()
        {
            Id = 2,
            Nome = "Teclado",
            Valor = 5000
        };

        var produto3 = new Produto()
        {
            Id = 3,
            Nome = "Notebook",
            Valor = 1200
        };
        var produto4 = new Produto()
        {
            Id = 4,
            Nome = "Notebook",
            Valor = 6000
        };

        var listaProd = new List<Produto>();
        listaProd.Add(produto);
        listaProd.Add(produto2);
        listaProd.Add(produto3);
        listaProd.Add(produto4);

        var retornoEsperado = new List<Produto>();
        retornoEsperado.Add(produto4);
        retornoEsperado.Add(produto2);

        var mock = new Mock<IProdutoRepository>();
        mock.Setup(x => x.GetListaProdutos()).Returns(listaProd);
        var produtoRepository = mock.Object;
        var produtoService = new ProdutoService(produtoRepository);

        //Act
        var resposta = produtoService.GetValorMaximo();
        //Assert

        Assert.Equal(retornoEsperado, resposta);
    }


    [Fact]
    public void GetValorMinimo_DeveRetornarProdutosDistintosPorValorMinimoComSucesso()
    {
        //Arrange
        var produto = new Produto()
        {
            Id = 1,
            Nome = "Teclado",
            Valor = 1000
        };
        var produto2 = new Produto()
        {
            Id = 2,
            Nome = "Teclado",
            Valor = 5000
        };

        var produto3 = new Produto()
        {
            Id = 3,
            Nome = "Notebook",
            Valor = 1200
        };
        var produto4 = new Produto()
        {
            Id = 4,
            Nome = "Notebook",
            Valor = 6000
        };

        var listaProd = new List<Produto>();
        listaProd.Add(produto);
        listaProd.Add(produto2);
        listaProd.Add(produto3);
        listaProd.Add(produto4);

        var retornoEsperado = new List<Produto>();
        retornoEsperado.Add(produto);
        retornoEsperado.Add(produto3);

        var mock = new Mock<IProdutoRepository>();
        mock.Setup(x => x.GetListaProdutos()).Returns(listaProd);
        var produtoRepository = mock.Object;
        var produtoService = new ProdutoService(produtoRepository);

        //Act
        var resposta = produtoService.GetValorMinimo();
        //Assert

        Assert.Equal(retornoEsperado, resposta);
    }

    [Fact]
    public void GetListaOrdenadaPorValorDecrescente_DeveRetornarTodosOsProdutosEmOrdemDecrescenteComSucesso()
    {
        //Arrange
        var produto = new Produto()
        {
            Id = 1,
            Nome = "Teclado",
            Valor = 1000
        };
        var produto2 = new Produto()
        {
            Id = 2,
            Nome = "Teclado",
            Valor = 5000
        };

        var produto3 = new Produto()
        {
            Id = 3,
            Nome = "Notebook",
            Valor = 1200
        };
        var produto4 = new Produto()
        {
            Id = 4,
            Nome = "Notebook",
            Valor = 6000
        };

        var listaProd = new List<Produto>();
        listaProd.Add(produto);
        listaProd.Add(produto2);
        listaProd.Add(produto3);
        listaProd.Add(produto4);

        var retornoEsperado = new List<Produto>();
        retornoEsperado.Add(produto4);
        retornoEsperado.Add(produto2);
        retornoEsperado.Add(produto3);
        retornoEsperado.Add(produto);

        var mock = new Mock<IProdutoRepository>();
        mock.Setup(x => x.GetListaProdutos()).Returns(listaProd);
        var produtoRepository = mock.Object;
        var produtoService = new ProdutoService(produtoRepository);

        //Act
        var resposta = produtoService.GetListaOrdenadaPorValorDecrescente();
        //Assert

        Assert.Equal(retornoEsperado, resposta);
    }


    [Fact]
    public void GetListaOrdenadaPorValorCrescente_DeveRetornarTodosOsProdutosEmOrdemCrescenteComSucesso()
    {
        //Arrange
        var produto = new Produto()
        {
            Id = 1,
            Nome = "Teclado",
            Valor = 1000
        };
        var produto2 = new Produto()
        {
            Id = 2,
            Nome = "Teclado",
            Valor = 5000
        };

        var produto3 = new Produto()
        {
            Id = 3,
            Nome = "Notebook",
            Valor = 1200
        };
        var produto4 = new Produto()
        {
            Id = 4,
            Nome = "Notebook",
            Valor = 6000
        };

        var listaProd = new List<Produto>();
        listaProd.Add(produto);
        listaProd.Add(produto2);
        listaProd.Add(produto3);
        listaProd.Add(produto4);

        var retornoEsperado = new List<Produto>();
        retornoEsperado.Add(produto);
        retornoEsperado.Add(produto3);
        retornoEsperado.Add(produto2);
        retornoEsperado.Add(produto4);

        var mock = new Mock<IProdutoRepository>();
        mock.Setup(x => x.GetListaProdutos()).Returns(listaProd);
        var produtoRepository = mock.Object;
        var produtoService = new ProdutoService(produtoRepository);

        //Act
        var resposta = produtoService.GetListaOrdenadaPorValorCrescente();
        //Assert

        Assert.Equal(retornoEsperado, resposta);
    }

    

}