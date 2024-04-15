using Torc.Challenge.Infrastructure.Interfaces.Repositories.Standard;

namespace Torc.Challenge.Infrastructure.Interfaces.Repositories.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepository<TEntity> where TEntity : class { }
}
