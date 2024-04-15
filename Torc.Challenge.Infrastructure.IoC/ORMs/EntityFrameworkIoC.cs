using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Torc.Challenge.Infrastructure.DBConfiguration;
using Torc.Challenge.Infrastructure.Interfaces.Repositories.Domain;
using Torc.Challenge.Infrastructure.Interfaces.Repositories.Standard;
using Torc.Challenge.Infrastructure.Repositories;
using Torc.Challenge.Infrastructure.Repositories.Standard;

namespace Torc.Challenge.Infrastructure.IoC.ORMs
{
    public class EntityFrameworkIoC : OrmTypes
    {
        internal override IServiceCollection AddOrm(IServiceCollection services, IConfiguration configuration)
        {
            IConfiguration dbConnectionSettings = ResolveConfiguration.GetConnectionSettings(configuration);
            string conn = dbConnectionSettings.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
