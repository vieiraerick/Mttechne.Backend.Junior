using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Data.Context;
using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MttechneDbContext _dbContext;

        public ProdutoRepository(MttechneDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync() =>
            await _dbContext.Set<Produto>().AsNoTracking().ToListAsync();

        public Produto GetById(int produtoId) => _dbContext.Set<Produto>().Find(produtoId);
    }
}
