using Microsoft.Extensions.Configuration;

namespace Mttechne.Backend.Junior.Services.Configuration
{
    public class AppConfigService
    {
        private readonly IConfiguration _configuration;

        public AppConfigService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetSection("ConnectionString").GetConnectionString("DBConnectionString");
        }
    }
}