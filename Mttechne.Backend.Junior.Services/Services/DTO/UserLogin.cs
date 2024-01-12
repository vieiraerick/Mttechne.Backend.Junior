using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Services.DTO;

public class UserLogin 
{
    public string? Username { get; set; }
    public string? Senha { get; set; }
}


public class UserLoginReposta
{
    public string? Username { get; set; }
    public string? Senha { get; set; }
    public string? Token { get; set; }
}
