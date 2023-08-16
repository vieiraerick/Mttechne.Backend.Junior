using Mttechne.Backend.Junior.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.UnitTests.Services
{
    public class ProdutoServiceTeste
    {
        [Theory]
        [InlineData("memória")]
        [InlineData("MeMóRiA")]
        [InlineData("Placa")]
        [InlineData("Mãe")]
        public void RetornarProdutosIndependenteDaFormatacaoDoNome(string nome)
        {
            var produtoService = new ProdutoService();

            var produtos = produtoService.GetListaProdutosPorNome(nome);

            Assert.NotEmpty(produtos);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RetornarProdutosOrdenados(bool crescente)
        {
            var produtoService = new ProdutoService();

            var produtos = produtoService.GetListaProdutosOrdenadosPorValor(crescente);

            Assert.Equal(crescente ? produtos.Min(y => y.Valor) : produtos.Max(y => y.Valor), produtos.First().Valor);
        }

        [Theory]
        [InlineData(300, 1000)]
        [InlineData(400, 5000)]
        [InlineData(600, 700)]
        public void RetornarProdutosEntreFaixaValores(int minimo, int maximo)
        {
            var produtoService = new ProdutoService();

            var produtos = produtoService.GetListaProdutosEntreFaixaValor(maximo, minimo);

            Assert.All(produtos, x => Assert.InRange(x.Valor, minimo, maximo));
        }

        [Fact]
        public void RetornarProdutosValoresMaximos()
        {
            var produtoService = new ProdutoService();

            var produtos = produtoService.GetListaProdutos();
            var produtosValoresMaximo = produtoService.GetListaValoresMaximosCadaProduto();

            Assert.All(produtosValoresMaximo, x => Assert.Equal(x?.Valor, produtos.Where(y => y.Nome == x?.Nome).Max(y => y.Valor)));
        }

        [Fact]
        public void RetornarProdutosValoresMinimos()
        {
            var produtoService = new ProdutoService();

            var produtos = produtoService.GetListaProdutos();
            var produtosValoresMaximo = produtoService.GetListaValoresMinimosCadaProduto();

            Assert.All(produtosValoresMaximo, x => Assert.Equal(x?.Valor, produtos.Where(y => y.Nome == x?.Nome).Min(y => y.Valor)));
        }
    }
}
