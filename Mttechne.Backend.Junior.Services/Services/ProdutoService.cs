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

    public List<Produto> GetListaProdutosOrdenado(bool? OrdemCrescente, bool? OrdemDescrecente)
    {
        var listaProduto = GetListaProdutos();

        //Aqui criei um método novo para Ordernação, sempre dando prioridade para a Crescente

        if (OrdemDescrecente is null || OrdemCrescente is true)
            return listaProduto.OrderBy(p => p.Valor).ToList();
        else
            return listaProduto.OrderByDescending(p => p.Valor).ToList();
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        var listaProdutos = GetListaProdutos();

        //Independete do que o usuário digitar irei remover os acentos primero
        nome = RemoverAcentos(nome);

        var resultados = listaProdutos.Where(produto =>
           RemoverAcentos(produto.Nome).IndexOf(nome, StringComparison.OrdinalIgnoreCase) >= 0
       );

        return resultados.ToList();
    }

    public List<Produto> GetListaRangeValoresProduto(int ValorMIn, int ValorMax)
    {
        var resultado = GetListaProdutos();
        return resultado.Where(produto => produto.Valor >= ValorMIn && produto.Valor <= ValorMax).ToList();
    }

    public List<Produto> GetProdutosMaiorEMenorValor(bool valida)
    {

        var resultado = GetListaProdutos();

        if (valida)
        {


            resultado = resultado.GroupBy(e => new { e.Nome }).Select(
                resultado => new Produto
                {
                    Nome = resultado.Key.Nome,
                    Valor = resultado.Max(a => a.Valor)

                }).ToList();

            return resultado;
        }
        else
        {

            resultado = resultado.GroupBy(e => new { e.Nome }).Select(
                resultado => new Produto
                {
                    Nome = resultado.Key.Nome,
                    Valor = resultado.Min(a => a.Valor)

                }).ToList();

            return resultado;
        }

    }

    //Metodo que criei para independente que o usuário digitar o vai ver com acentos ou não
    private string RemoverAcentos(string texto)
    {
        if (string.IsNullOrEmpty(texto))
            return texto;

        string comAcentos = "áéíóúÁÉÍÓÚâêîôÂÊÎÔãõÃÕàÀüÜçÇ";
        string semAcentos = "aeiouAEIOUaeiouAEIOUaoAOuUcC";

        for (int i = 0; i < comAcentos.Length; i++)
        {
            texto = texto.Replace(comAcentos[i], semAcentos[i]);
        }

        // Remover os caracteres especiais que podem ter sobrado
        texto = Regex.Replace(texto, @"[^a-zA-Z0-9]", " ");

        return texto;
    }
}