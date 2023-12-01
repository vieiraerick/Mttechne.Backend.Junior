using Moq;
using Mttechne.Backend.Junior.Services.Data.Repositories;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.UnitTests.Services
{
    public class ProductServiceTest
    {
        private readonly Mock<IProdutoRepository> _repositoryMock;
        private readonly ProdutoService _productService;

        public ProductServiceTest()
        {
            _repositoryMock = new Mock<IProdutoRepository>();
            _productService = new ProdutoService(_repositoryMock.Object);
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
        public void GetListaProdutosPorValorMaximo_ReturnsMaxValueProducts()
        {
            // Arrange
            var listaProdutos = GetSampleProducts();
            _repositoryMock.Setup(x => x.GetAllAsync().Result).Returns(listaProdutos);


            // Act
            var result = _productService.GetListaProdutosPorValorMaximo();
            var expected = listaProdutos
                            .GroupBy(x => x.Nome)
                            .Select(x => x.OrderByDescending(y => y.Valor)
                            .FirstOrDefault())
                            .ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetListaProdutosPorValorMinimo_ReturnsMinValueProducts()
        {
            // Arrange
            var listaProdutos = GetSampleProducts();
            _repositoryMock.Setup(x => x.GetAllAsync().Result).Returns(listaProdutos);


            // Act
            var result = _productService.GetListaProdutosPorValorMinimo();
            var expected = listaProdutos
                            .GroupBy(x => x.Nome)
                            .Select(x => x.OrderBy(y => y.Valor)
                            .FirstOrDefault())
                            .ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetListaProdutosPorNome_ReturnsProductsByName()
        {
            // Arrange
            var nome = "video";
            var listaProdutos = GetSampleProducts();
            _repositoryMock.Setup(x => x.GetAllAsync().Result).Returns(listaProdutos);
            
            // Act
            var result = _productService.GetListaProdutosPorNome(nome);
            var expected = listaProdutos
                .Where(palavra => RemoverAcentos(palavra.Nome)
                .Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToList();


            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void GetListaProdutosPorIntervalo_ReturnsProductsInInterval()
        {
            // Arrange
            var listaProdutos = GetSampleProducts();
            _repositoryMock.Setup(x => x.GetAllAsync().Result).Returns(listaProdutos);

            // Act
            var result = _productService.GetListaProdutosPorIntervalo(350, 1000);
            var expected = listaProdutos
                .Where(x => x.Valor >= 350 && x.Valor <= 1000).ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal(result, expected);
        }

        static string RemoverAcentos(string texto)
        {
            var normalizedString = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
