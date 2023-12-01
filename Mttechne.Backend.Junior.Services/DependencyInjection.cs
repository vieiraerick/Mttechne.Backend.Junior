using Microsoft.Extensions.DependencyInjection;
using Mttechne.Backend.Junior.Services.Data.Repositories;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Services;

public static class DependencyInjection
{
    public static void RegisterBindings(IServiceCollection services)
    {
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IDbInitializer, DbInitializer>();
    }
}