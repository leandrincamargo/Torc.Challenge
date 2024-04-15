using Torc.Challenge.Infrastructure.DBConfiguration;
using Microsoft.Extensions.Configuration;

namespace Torc.Challenge.Infrastructure.IoC
{
    internal class ResolveConfiguration
    {
        public static IConfiguration GetConnectionSettings(IConfiguration configuration)
        {
            return configuration ?? DatabaseConnection.ConnectionConfiguration;
        }
    }
}
