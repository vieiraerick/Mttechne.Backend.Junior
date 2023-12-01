using Mttechne.Backend.Junior.Services.Model.Base;

namespace Mttechne.Backend.Junior.Services.Model;

public class Produto : BaseEntity
{
    public string Nome { get; set; } = null!;
    public int Valor { get; set; }
}