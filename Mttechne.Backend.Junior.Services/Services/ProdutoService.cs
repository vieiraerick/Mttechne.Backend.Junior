using Mttechne.Backend.Junior.Services.Model;
using System.Text.RegularExpressions;

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

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        if (nome == null)
        {
            throw new Exception("O campo nome não pode estar vazio.");
        }

        var listaProdutos = GetListaProdutos();
        var nomeProduto = listaProdutos.Where(x => RemoveAcentos(x.Nome)
            .IndexOf(RemoveAcentos(nome), StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();

        return nomeProduto;
    }

    private string RemoveAcentos(string nome)
    {
        return new string(nome
            .Normalize(System.Text.NormalizationForm.FormD)
            .Where(ch => char.GetUnicodeCategory(ch) != System.Globalization.UnicodeCategory.NonSpacingMark)
            .ToArray());
    }

    public List<Produto> GetListaProdutosValorCrescente()
    {
        var listaProdutos = GetListaProdutos();
        var valorCrescente = listaProdutos.OrderBy(x => x.Valor).ToList();

        return valorCrescente;
    }

    public List<Produto> GetListaProdutosValorDecrescente()
    {
        var listaProdutos = GetListaProdutos();
        var valorDecrescente = listaProdutos.OrderByDescending(x => x.Valor).ToList();

        return valorDecrescente;
    }

    public List<Produto> GetListaProdutosFaixaDePreco(decimal? valorMinimo, decimal? valorMaximo)
    {
        if (valorMinimo == null || valorMaximo == null)
        {
            throw new Exception("Os valores mínimos e máximos não podem ser nulos.");
        }

        if (valorMinimo < 0 || valorMaximo < 0)
        {
            throw new Exception("Os valores mínimos e máximos não podem ser negativos.");
        }

        if (valorMinimo > valorMaximo)
        {
            throw new Exception("O valor mínimo não pode ser maior que o valor máximo.");
        }

        var listaProdutos = GetListaProdutos();
        var faixaDePreco = listaProdutos.Where(x => x.Valor >= valorMinimo && x.Valor <= valorMaximo)
            .OrderBy(x => x.Valor).ToList();

        return faixaDePreco;
    }

    public List<Produto> GetListaProdutosMaiorValor()
    {
        var listaProdutos = GetListaProdutos();
        var produtosMaiorValor = listaProdutos.GroupBy(x => x.Nome).Select(group => group
            .OrderByDescending(x => x.Valor).First())
            .OrderByDescending(x => x.Valor).ToList();

        return produtosMaiorValor;
    }

    public List<Produto> GetListaProdutosMenorValor()
    {
        var listaProdutos = GetListaProdutos();
        var produtosMenorValor = listaProdutos.GroupBy(x => x.Nome).Select(group => group
            .OrderBy(x => x.Valor).First())
            .OrderBy(x => x.Valor).ToList();

        return produtosMenorValor;
    }
}