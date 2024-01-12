using AutoMapper;
using Mttechne.Backend.Junior.Domain.Model;
using Mttechne.Backend.Junior.Services.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Services;

public class UserService : IUserService
{
    protected readonly IUserRepository _userRepository;
    protected readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public UserLogin Cadastrar(UserLogin user)
    {
       var userModel = _mapper.Map<User>(user);
       return _mapper.Map<UserLogin>(_userRepository.Cadastrar(userModel)); 
    }

    public UserLogin Logar(UserLogin user)
    {
        var userModel = _mapper.Map<User>(user);
        return _mapper.Map<UserLogin>(_userRepository.Logar(userModel));
    }
}
