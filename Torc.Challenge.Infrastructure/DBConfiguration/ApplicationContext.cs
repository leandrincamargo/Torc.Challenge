using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Torc.Challenge.Domain.Entities;

namespace Torc.Challenge.Infrastructure.DBConfiguration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection"));
            }
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
