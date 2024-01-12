namespace Mttechne.Backend.Junior.Domain.Model;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public int Valor { get; set; }


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Produto other = (Produto)obj;
        return Nome == other.Nome && Valor == other.Valor;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nome, Valor);
    }

}
