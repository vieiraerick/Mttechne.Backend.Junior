using Moq;
using Mttechne.Backend.Junior.Domain.Model;
using Mttechne.Backend.Junior.Repository.Context;
using Mttechne.Backend.Junior.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        public readonly MyContext _myContext;

        public ProdutoRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public  List<Produto> GetListaProdutos()
        {
            var resultado = _myContext.Produtos.ToList();
            return resultado;
        }
    }

  
}
