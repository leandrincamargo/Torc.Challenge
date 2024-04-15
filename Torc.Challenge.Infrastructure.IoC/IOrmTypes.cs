using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Torc.Challenge.Infrastructure.IoC
{
    public interface IOrmTypes
    {
        IServiceCollection ResolveOrm(IServiceCollection services, IConfiguration configuration = null);
    }
}
