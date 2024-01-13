using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mttechne.Backend.Junior.Services.Model;
[Table("Produtos")]
public class Produto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order =0)]
    public int ID {get;set;}
    [Required(ErrorMessage ="Campo nome é necessario.")]
    [StringLength(maximumLength:100)]
    [Column(Order = 1)]
    public string Nome { get; set; } = null!;
    [Required(ErrorMessage = "Campo valor é necessario")]
    [Column(Order = 2)]
    public int Valor { get; set; }
}