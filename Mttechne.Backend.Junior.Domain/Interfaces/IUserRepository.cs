using Mttechne.Backend.Junior.Domain.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IUserRepository
{
    User Cadastrar(User user);
    User Logar(User user);
}
