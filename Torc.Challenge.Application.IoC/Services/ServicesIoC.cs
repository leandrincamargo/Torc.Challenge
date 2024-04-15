using Microsoft.Extensions.DependencyInjection;
using Torc.Challenge.Application.Interfaces.Services;
using Torc.Challenge.Application.Interfaces.Services.Standard;
using Torc.Challenge.Application.Services;
using Torc.Challenge.Application.Services.Standard;

namespace Torc.Challenge.Application.IoC.Services
{
    public static class ServicesIoC
    {
        public static void ApplicationServicesIoC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            
            services.AddScoped<IBookService, BookService>();
        }
    }
}
