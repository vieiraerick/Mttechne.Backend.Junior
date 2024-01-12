using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Mttechne.Backend.Junior.Services.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        IConfiguration _configuration;
        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public AppDbContext CreateDbContext(string[] args)
        {
            // Configure as opções de contexto aqui
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            string? connectionString = _configuration.GetSection("ConnectionString").GetSection("DBConnectionString").Value;
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}