using System.ComponentModel.DataAnnotations;

namespace Mttechne.Backend.Junior.Services.Model;

public class Produto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; } = null!;
    public int Valor { get; set; }
}