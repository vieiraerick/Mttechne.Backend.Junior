using Mttechne.Backend.Junior.Services.Model;
using System.Globalization;
using System.Text;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{
    public List<Produto> GetListaProdutos()
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

    public List<Produto> GetListaProdutosByName(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            throw new ArgumentNullException(nameof(nome), "O nome do produto não pode ser nulo ou vazio.");
        }

        var listaProdutos = GetListaProdutos();

        return listaProdutos.Where(x => IsMatch(x.Nome, nome)).ToList();
    }

    public List<Produto> GetListaProdutosByPriceAscendinge()
    {
        var listaProdutos = GetListaProdutos(); 

        return listaProdutos.OrderBy(x => x.Valor).ToList();
    }

    public List<Produto> GetListaProdutosByPriceDescending()
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.OrderByDescending(x => x.Valor).ToList();
    }

    public List<Produto> GetListaProdutosInPriceRange(int minPrice, int maxPrice)
    {
        var listaProdutos = GetListaProdutos();
        List<Produto> produtosInRange = new List<Produto>();

        foreach (var produto in listaProdutos)
        {
            if (produto.Valor >= minPrice && produto.Valor <= maxPrice)
            {
                produtosInRange.Add(produto);
            }
        }

        return produtosInRange;
    }

    public List<Produto> GetListaProdutosPerMaxValue()
    {
        var listaProdutos = GetListaProdutos();

        var maxValuesPerProduct = listaProdutos
            .GroupBy(produto => produto.Nome)
            .Select(group => group.OrderByDescending(produto => produto.Valor).First())
            .ToList();

        return maxValuesPerProduct;
    }

    public List<Produto> GetListaProdutosPerMinValue()
    {
        var listaProdutos = GetListaProdutos();

        var minValuesPerProduct = listaProdutos
            .GroupBy(produto => produto.Nome)
            .Select(group => group.OrderBy(produto => produto.Valor).First())
            .ToList();

        return minValuesPerProduct;
    }

    static string RemoveDiacritics(string text)
    {
        string normalizedText = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new System.Text.StringBuilder();

        foreach (char c in normalizedText)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }

    static bool IsMatch(string source, string target)
    {
        string normalizedSource = RemoveDiacritics(source);
        string normalizedTarget = RemoveDiacritics(target);

        normalizedSource = normalizedSource.ToLower();
        normalizedTarget = normalizedTarget.ToLower();

        return normalizedSource.Contains(normalizedTarget);
    }
}
