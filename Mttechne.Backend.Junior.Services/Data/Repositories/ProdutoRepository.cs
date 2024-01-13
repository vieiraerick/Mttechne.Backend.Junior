using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Data.Repositories.interfaces;
using Mttechne.Backend.Junior.Services.Extensions;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Produto>> GetListaProdutos() => await _appDbContext.Produtos.ToListAsync();
    public async Task<List<Produto>> GetListaProdutosPorNome(string nome)
        =>(await GetListaProdutos()).Where(x => x.Nome.RemoverAcentuacao().IndexOf(nome.RemoverAcentuacao(), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
       

    public async Task<List<Produto>> GetListaValorOrdenado(bool crescente) => crescente ?
        (await GetListaProdutos()).OrderBy(x => x.Valor).ToList() : (await GetListaProdutos()).OrderByDescending(x => x.Valor).ToList();

        
    public async Task<List<Produto>> GetListaFaixaValor(decimal minimo,decimal maximo) =>    
     (await GetListaProdutos()).Where(x => x.Valor >= minimo && x.Valor <= maximo).OrderBy(x => x.Valor).ToList();
    
        

    public async Task<List<Produto>> GetListaMinValor() =>
        (await GetListaProdutos()).OrderBy(p => p.Valor).Take(1).ToList();
    
    public async Task<List<Produto>> GetListaMaxValor() =>
        (await GetListaProdutos()).OrderByDescending(p => p.Valor).Take(1).ToList();
    }
}