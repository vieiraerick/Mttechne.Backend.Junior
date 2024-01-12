using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Helpers
{
    public class ProductComparer : IEqualityComparer<Produto>
    {
        public bool Equals(Produto x, Produto y)
        {
            return x.Valor == y.Valor && y.Nome == x.Nome;
        }

        public int GetHashCode(Produto produto)
        {
            return produto.GetHashCode();
        }
    }
}
