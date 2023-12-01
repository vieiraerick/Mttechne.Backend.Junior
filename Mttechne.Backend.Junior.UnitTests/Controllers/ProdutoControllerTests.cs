using Microsoft.AspNetCore.Mvc;
using Moq;
using Mttechne.Backend.Junior.Interface.Controllers;
using Mttechne.Backend.Junior.Services.Data.Repositories;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.UnitTests.Controllers
{
    public class ProdutoControllerTests
    {
        private readonly Mock<IProdutoService> _produtoService;
        private readonly ProdutoController _controller;

        public ProdutoControllerTests()
        {
            _produtoService = new Mock<IProdutoService>();
            _controller = new ProdutoController(_produtoService.Object);
        }

        private List<Produto> GetSampleProducts()
        {
            var produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
            var produto2 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
            var produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1350 };
            var produto4 = new Produto() { Nome = "Processador", Valor = 2000 };
            var produto5 = new Produto() { Nome = "Processador", Valor = 2100 };
            var produto6 = new Produto() { Nome = "Memória", Valor = 300 };
            var produto7 = new Produto() { Nome = "Memória", Valor = 350 };
            var produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };

            return new List<Produto>() { produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8 };
        }

        [Fact]
        public void GetListaProdutos_DeveRetornarListaDeProdutos()
        {
            // Arrange
            var listaProdutos = GetSampleProducts();
            _produtoService.Setup(x => x.GetListaProdutos()).Returns(listaProdutos);

            // Act
            var result = _controller.GetListaProdutos().Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtosRetornados = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Equal(listaProdutos, produtosRetornados);
        }

        [Fact]
        public void GetListaProdutosPorValorCrescente_DeveRetornarListaOrdenadaPorValorCrescente()
        {
            // Arrange
            var listaProdutos = GetSampleProducts();
            _produtoService.Setup(x => x.GetListaProdutos()).Returns(listaProdutos);

            // Act
            var result = _controller.GetListaProdutosPorValorCrescente().Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtosRetornados = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Equal(listaProdutos.OrderBy(p => p.Valor), produtosRetornados);
        }

        [Fact]
        public void GetListaProdutosPorValorDecrescente_DeveRetornarListaOrdenadaPorValorDecrescente()
        {
            // Arrange
            var listaProdutos = GetSampleProducts();
            _produtoService.Setup(x => x.GetListaProdutos()).Returns(listaProdutos);

            // Act
            var result = _controller.GetListaProdutosPorValorDecrescente().Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtosRetornados = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Equal(listaProdutos.OrderByDescending(p => p.Valor), produtosRetornados);
        }


        [Fact]
        public void GetListaProdutosPorValorMaximo_DeveRetornarListaProdutosComValorMaior()
        {
            // Arrange
            var listaProdutos = new List<Produto>()
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 350 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };
            _produtoService.Setup(x => x.GetListaProdutosPorValorMaximo()).Returns(listaProdutos);

            // Act
            var result = _controller.GetListaProdutosPorValorMaximo().Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtosRetornados = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Equal(produtosRetornados, listaProdutos);
        }

        [Fact]
        public void GetListaProdutosPorValorMinimo_DeveRetornarListaProdutosComValorMenor()
        {
            // Arrange
            var listaProdutos = new List<Produto>()
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto() { Nome = "Processador", Valor = 2100 },
                new Produto() { Nome = "Memória", Valor = 300 },
                new Produto() { Nome = "Placa mãe", Valor = 1100 }
            };
            _produtoService.Setup(x => x.GetListaProdutosPorValorMinimo()).Returns(listaProdutos);

            // Act
            var result = _controller.GetListaProdutosPorValorMinimo().Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtosRetornados = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Equal(produtosRetornados, listaProdutos);
        }

        [Fact]
        public void GetListaProdutosPorValorInterva_DeveRetornarListaProdutosNoIntervalo()
        {
            // Arrange
            var listaProdutos = new List<Produto>()
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Memória", Valor = 350 }
            };
            _produtoService.Setup(x => x.GetListaProdutosPorIntervalo(350, 1000)).Returns(listaProdutos);

            // Act
            var result = _controller.GetListaProdutosPorValorInterva(350, 1000).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtosRetornados = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.All(produtosRetornados, p => Assert.InRange(p.Valor, 350, 1000));
        }

        [Fact]
        public void GetListaProdutosPorNome_DeveRetornarListaProdutosComMesmoNome()
        {
            // Arrange
            var nome = "video";
            var listaProdutos = new List<Produto>
            {
                new Produto() { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto() { Nome = "Placa de Vídeo", Valor = 1500 }
            };
            _produtoService.Setup(x => x.GetListaProdutosPorNome(nome)).Returns(listaProdutos);

            // Act
            var result = _controller.GetListaProdutosPorNome(nome).Result;

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var produtosRetornados = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Equal(produtosRetornados, listaProdutos);
        }
    }
}
