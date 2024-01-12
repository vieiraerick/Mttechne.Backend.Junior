using Mttechne.Backend.Junior.Services.Model;
using System.Globalization;
using System.Text;

namespace Mttechne.Backend.Junior.Services.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly List<Produto> _produtos;

        public ProdutoService()
        {
            _produtos = new List<Produto>
            {
                new Produto { Nome = "Placa de Vídeo", Valor = 1000 },
                new Produto { Nome = "Placa de Vídeo", Valor = 1500 },
                new Produto { Nome = "Placa de Vídeo", Valor = 1350 },
                new Produto { Nome = "Processador", Valor = 2000 },
                new Produto { Nome = "Processador", Valor = 2100 },
                new Produto { Nome = "Memória", Valor = 300 },
                new Produto { Nome = "Memória", Valor = 350 },
                new Produto { Nome = "Placa mãe", Valor = 1100 }
            };
        }

        public List<Produto> GetListaProdutos()
        {
            return _produtos;
        }

        public List<Produto> GetListaProdutosPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Nome inválido.");

            return _produtos.Where(p => RemoveAcentuacao(p.Nome.ToLower()).Contains(RemoveAcentuacao(nome.ToLower()))).ToList();
        }

        public List<Produto> GetListaProdutosOrdenadaPorValor(bool ehCrescente)
        {
            return ehCrescente ? _produtos.OrderBy(x => x.Valor).ToList() : _produtos.OrderByDescending(x => x.Valor).ToList();
        }

        public List<Produto> GetListaProdutosPorFaixaDePreco(int valorMinimo, int valorMaximo)
        {
            return _produtos
                .Where(x => x.Valor >= valorMinimo && x.Valor <= valorMaximo)
                .ToList();
        }

        public List<Produto> GetProdutosValoresMaximos()
        {
            return _produtos
                .GroupBy(x => x.Nome)
                .Select(p => p.OrderByDescending(g => g.Valor).First())
                .ToList();
        }

        public List<Produto> GetProdutosValoresMinimos()
        {
            return _produtos
                .GroupBy(x => x.Nome)
                .Select(p => p.OrderBy(g => g.Valor).First())
                .ToList();
        }

        private static string RemoveAcentuacao(string value)
        {
            string valorNormalizado = value.Normalize(NormalizationForm.FormD);

            string valorFiltrado = new(valorNormalizado
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            return valorFiltrado;
        }
    }
}
