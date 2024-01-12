using Mttechne.Backend.Junior.Domain.Model;
using Mttechne.Backend.Junior.Repository.Context;
using Mttechne.Backend.Junior.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Repository.Repository;

public class UserRepository : IUserRepository
{
    public readonly MyContext _myContext;

    public UserRepository(MyContext myContext)
    {
        _myContext = myContext;
    }
    public User Cadastrar(User user)
    {
        //Verificar se o usuario já Existe
        var verificaUsuario = _myContext.Users.Any(u => u.Username == user.Username);

        if(verificaUsuario)
        {
            return new User();
        }

        _myContext.Users.Add(user);
        _myContext.SaveChanges();
        return user;
    }

    public User Logar(User user)
    {
        //Verificar se o usuario já Existe
        var verificaUsuario = _myContext.Users.Any(u => u.Username == user.Username && u.Senha == user.Senha);

        if (verificaUsuario)
        {
            return user;
        }
        else
        {
            return new User();
        }
        
    }
}
