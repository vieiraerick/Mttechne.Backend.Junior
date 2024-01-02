using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Interface
{
    public interface IProdutoRepository
    {
        IList<Produto> GetListaProdutos();
    }
}
