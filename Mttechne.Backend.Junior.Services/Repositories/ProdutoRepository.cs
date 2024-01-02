using Microsoft.EntityFrameworkCore;
using Mttechne.Backend.Junior.Services.Context;
using Mttechne.Backend.Junior.Services.Extensions;
using Mttechne.Backend.Junior.Services.Interface;
using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ApplicationDbContext _context;
        public ProdutoRepository(ApplicationDbContext context) => _context = context;


        public IList<Produto> GetListaProdutos()
        {

            List<Produto> produtosCadastrados = _context.Produto.ToList();
            return produtosCadastrados;
        }
    }
}
