using Microsoft.Extensions.DependencyInjection;
using Mttechne.Backend.Junior.Services.Configuration;
using Mttechne.Backend.Junior.Services.Data.Repositories;
using Mttechne.Backend.Junior.Services.Data.Repositories.interfaces;
using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.Services.Strategies;
using Mttechne.Backend.Junior.Services.Strategies.interfaces;

namespace Mttechne.Backend.Junior.Services;

public static class DependencyInjection
{
    public static void RegisterBindings(IServiceCollection services)
    {
        
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IAttributeValidationStrategy, AttributeValidationStrategy>();
        services.AddScoped<IObjectValidationStrategy<Produto>, ProductValidationStrategy>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddSingleton<IAppConfig, AppConfig>();
    }
}