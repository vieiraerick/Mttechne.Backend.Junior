using Microsoft.Extensions.Configuration;

namespace Mttechne.Backend.Junior.Services.Configuration
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetSection("ConnectionString").GetConnectionString("DBConnectionString");
        }
    }
}