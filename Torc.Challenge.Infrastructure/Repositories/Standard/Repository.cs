using Microsoft.EntityFrameworkCore;
using Torc.Challenge.Infrastructure.DBConfiguration;
using Torc.Challenge.Infrastructure.Interfaces.Repositories.Standard;

namespace Torc.Challenge.Infrastructure.Repositories.Standard
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity Add(TEntity obj)
        {
            var r = _dbContext.Add(obj);
            Commit();
            return r.Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> obj)
        {
            _dbContext.AddRange(obj);
            Commit();
        }

        public virtual int Update(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            return Commit();
        }

        public virtual bool Remove(object id)
        {
            TEntity entity = GetById(id);

            if (entity == null) return false;

            return Remove(entity) > 0;
        }

        public virtual int Remove(TEntity obj)
        {
            _dbContext.Remove(obj);
            return Commit();
        }

        private int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}
