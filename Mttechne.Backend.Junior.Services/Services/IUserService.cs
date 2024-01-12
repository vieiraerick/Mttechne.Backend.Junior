using Mttechne.Backend.Junior.Services.Services.DTO;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IUserService
{
    UserLogin Cadastrar(UserLogin user);
    UserLogin Logar(UserLogin user);
}