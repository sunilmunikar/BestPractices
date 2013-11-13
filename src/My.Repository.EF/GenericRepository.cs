using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace My.Repository.EF
{
    public enum DomainObjectState
    {
        Added,
        Unchanged,
        Modified,
        Deleted
    }

    interface IEntityWithState
    {
        DomainObjectState State { get; set; }
    }

    interface IGenericRepository<TEntity>
        where TEntity : IEntityWithState
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includeProperties);
        void InsertOrUpdateGraph(TEntity entity);
        void Delete(TEntity entity);
        void Delete<TKey>(TKey key) where TKey : struct;
    }

    public abstract class EntityBase : IEntityWithState
    {
        public DomainObjectState State { get; set; }
    }

    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : EntityBase;
        int SaveChanges();
    }

    interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        IDbContext DbContext { get; }
    }

    public abstract class GenericRepositoryBase<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdateGraph(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete<TKey>(TKey key) where TKey : struct
        {
            throw new NotImplementedException();
        }
    }
}
