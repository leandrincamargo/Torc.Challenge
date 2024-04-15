using Torc.Challenge.Infrastructure.DBConfiguration;
using Torc.Challenge.Infrastructure.Interfaces.Repositories.Domain.Standard;

namespace Torc.Challenge.Infrastructure.Repositories.Standard
{
    public class DomainRepository<TEntity> : Repository<TEntity>, IDomainRepository<TEntity> where TEntity : class
    {
        protected DomainRepository(ApplicationContext dbContext) : base(dbContext) { }
    }
}
