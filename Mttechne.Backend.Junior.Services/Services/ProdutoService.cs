using Mttechne.Backend.Junior.Services.Model;
using System.Linq;

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
        var listaProdutos = GetListaProdutos();

        return listaProdutos.Where(x => x.Nome == nome).ToList();
    }

    public List<Produto> GetProdutosPorValor(int order, List<Produto> produtos)
    {
        IEnumerable<Produto> query = from prod in produtos
                    select prod;
        if(order == 1)
        {
            return query.OrderByDescending(prod => prod.Valor).ToList();
        }
        return query.OrderBy(prod => prod.Valor).ToList();
    }

    public List<Produto> GetProdutosFaixa(double valor_inicial, double valor_final, List<Produto> produtos)
    {
        IEnumerable<Produto> query = 
            from prod in produtos
            where prod.Valor >= valor_inicial
            && prod.Valor <= valor_final
            select prod;
       
        return query.ToList();
    }

    // este método busca maiores valores de cada produto ou menores valores de cada produto a depender do valor de entra "i"
    //i = 1 significa maior valor, i = any significa menor valor
    public List<Produto> ValoresExtremos(int i, List<Produto> produtos)
    {
        HashSet<string> nomes_de_produto = new HashSet<string>();
        foreach(var prod in produtos)
        {
            nomes_de_produto.Add(prod.Nome);
        }

        List<Produto> retorno = new List<Produto>();


        foreach(var nome in nomes_de_produto)
        {
            //reutiliza o método de cima que arruma em ordem decrescente ou crescente a adiciona o first ou default para pegar o primeiro da lista, em caso de a lista estar vazia o valor é nulo

            Produto produto_caro = GetProdutosPorValor(i, produtos).FirstOrDefault(prod => prod.Nome == nome);
            retorno.Add(produto_caro);
        }

        return retorno;

        
    }
}