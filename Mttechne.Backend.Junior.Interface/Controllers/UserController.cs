using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mttechne.Backend.Junior.CrossCutting;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.Services.Services.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly AppSettings _appSettings;

    public UserController(IUserService service, IOptions<AppSettings> appSettings)
    {
        _service = service;
        _appSettings = appSettings.Value;
    }

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> Registrar(UserLogin userLogin)
    {
        if (userLogin == null)
        {
            return BadRequest("Erro para cadastrar Login");
        }

        var resultado = _service.Cadastrar(userLogin);
        if(string.IsNullOrEmpty(resultado.Username))
        {
            return BadRequest("Erro para cadastrar Login");
        }

        return Ok(ObterRespostaToken(userLogin));
    }

    [HttpPost("Logar")]
    public async Task<IActionResult> Logar(UserLogin userLogin)
    {
        if (userLogin == null)
        {
            return BadRequest("Erro ao Logar - Dados inválidos");
        }

        var resultado = _service.Logar(userLogin);
        if (string.IsNullOrEmpty(resultado.Username))
        {
            return BadRequest("Erro ao Logar - Dados inválidos");
        }

        return Ok(ObterRespostaToken(userLogin));
    }


    private UserLoginReposta ObterRespostaToken(UserLogin userLogin)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _appSettings.Emissor,
            Audience = _appSettings.ValidoEm,
            Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        return new UserLoginReposta
        {
            Username = userLogin.Username,
            Senha = "",
            Token = tokenHandler.WriteToken(token)
        };
    }
}
