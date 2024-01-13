using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.Services.Configuration
{
    public interface IAppConfig
    {
        public string GetConnectionString();
    }
}