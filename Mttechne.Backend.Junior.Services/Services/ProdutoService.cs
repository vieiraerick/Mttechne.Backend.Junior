using Mttechne.Backend.Junior.Services.Data.Repositories;
using Mttechne.Backend.Junior.Services.Model;
using System.Globalization;
using System.Text;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public List<Produto> GetListaProdutos()
    {
        return _produtoRepository.GetAllAsync().Result.ToList();
    }
    public List<Produto> GetListaProdutosPorValorMaximo()
    {
        return _produtoRepository.GetAllAsync().Result
            .GroupBy(x => x.Nome)
            .Select(x => x.OrderByDescending(y => y.Valor)
            .FirstOrDefault())
            .ToList();
    }
    public List<Produto> GetListaProdutosPorValorMinimo()
    {
        return _produtoRepository.GetAllAsync().Result
            .GroupBy(x => x.Nome)
            .Select(x => x.OrderBy(y => y.Valor)
            .FirstOrDefault())
            .ToList();
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {

        return _produtoRepository.GetAllAsync().Result
                    .Where(palavra => RemoverAcentos(palavra.Nome)
                    .Contains(nome, StringComparison.OrdinalIgnoreCase))
                    .ToList();

    }

    public List<Produto> GetListaProdutosPorIntervalo(int inicial, int final)
    {
        return _produtoRepository.GetAllAsync().Result.Where(x => x.Valor >= inicial && x.Valor <= final).ToList();
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