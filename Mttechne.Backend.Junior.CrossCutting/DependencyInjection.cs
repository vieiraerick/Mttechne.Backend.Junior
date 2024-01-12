using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Mttechne.Backend.Junior.Repository.Context;
using Mttechne.Backend.Junior.Repository.Repository;
using Mttechne.Backend.Junior.Services.AutoMappers;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.CrossCutting;

public static class DependencyInjection
{
    

    public static void RegisterBindings(IServiceCollection services)
    {

        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(typeof(MappingsProfile));
    }


  
}