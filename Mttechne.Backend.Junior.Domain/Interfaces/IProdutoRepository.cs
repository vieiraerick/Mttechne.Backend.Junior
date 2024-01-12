using Mttechne.Backend.Junior.Domain.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoRepository
{
    List<Produto> GetListaProdutos();

}
