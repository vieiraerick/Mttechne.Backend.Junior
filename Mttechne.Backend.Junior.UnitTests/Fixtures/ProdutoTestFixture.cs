using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.UnitTests.Fixtures
{
    [CollectionDefinition(nameof(ProdutoCollection))]
    public class ProdutoCollection : ICollectionFixture<ProdutoTestFixture> { }
    public class ProdutoTestFixture : IDisposable
    {
        public readonly ApplicationDbContext context;
        private bool _produtosAdicionados = false;

        public ProdutoTestFixture()
        {
            context = CreateDbContext();
            AddProductsIfNecessary();
        }

        private void AddProductsIfNecessary()
        {
            if (!_produtosAdicionados)
            {
                context.Produtos.AddRange(GerarListaProdutoValida());
                context.SaveChanges();

                _produtosAdicionados = true;
            }
        }

        public void Dispose()
        {
        }

        public List<Produto> GerarListaProdutoValida()
        {
            Produto produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
            Produto produto2 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
            Produto produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1350 };
            Produto produto9 = new Produto() { Nome = "Placa de Vídeo", Valor = 900 };
            Produto produto4 = new Produto() { Nome = "Processador", Valor = 2000 };
            Produto produto5 = new Produto() { Nome = "Processador", Valor = 2100 };
            Produto produto6 = new Produto() { Nome = "Memória", Valor = 300 };
            Produto produto7 = new Produto() { Nome = "Memória", Valor = 350 };
            Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };

            List<Produto> produtosCadastrados = new List<Produto>()
                {
                    produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
                };

            return produtosCadastrados;

        }

        public List<Produto> GerarListaProdutoPorNomeValida(string nome)
        {
            Produto produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
            Produto produto2 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
            Produto produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1350 };
            Produto produto4 = new Produto() { Nome = "Processador", Valor = 2000 };
            Produto produto5 = new Produto() { Nome = "Processador", Valor = 2100 };
            Produto produto6 = new Produto() { Nome = "Memória", Valor = 300 };
            Produto produto7 = new Produto() { Nome = "Memória", Valor = 350 };
            Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };

            List<Produto> produtosCadastrados = new List<Produto>()
                {
                    produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
                };

            return produtosCadastrados;

        }

        public ApplicationDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
