using Mttechne.Backend.Junior.Services.Model;

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

    public List<Produto> GetListaProdutosEntreFaixaValor(int maximo, int minimo)
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.Where(x => x.Valor >= minimo && x.Valor <= maximo).ToList();
    }

    public List<Produto> GetListaProdutosOrdenadosPorValor(bool crescente)
    {
        var listaProdutos = GetListaProdutos();

        if (crescente)
            return listaProdutos.OrderBy(x => x.Valor).ToList();

        return listaProdutos.OrderByDescending(x => x.Valor).ToList();
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        var listaProdutos = GetListaProdutos();
        nome = nome.Normalize().ToLower();
        return listaProdutos.Where(x => x.Nome.Normalize().ToLower().Contains(nome)).ToList();
    }

    public List<Produto?> GetListaValoresMaximosCadaProduto()
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.GroupBy(x => x.Nome).Select(x => x.MaxBy(x => x.Valor)).ToList();
    }

    public List<Produto?> GetListaValoresMinimosCadaProduto()
    {
        var listaProdutos = GetListaProdutos();

        return listaProdutos.GroupBy(x => x.Nome).Select(x => x.MinBy(x => x.Valor)).ToList();
    }
}