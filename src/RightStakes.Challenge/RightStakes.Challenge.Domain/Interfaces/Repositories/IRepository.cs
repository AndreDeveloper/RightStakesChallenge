using RightStakes.Challenge.Domain.Entities;
using System;
using System.Linq;

namespace RightStakes.Challenge.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp);

        TEntity GetBy(Func<TEntity, bool> exp);

        bool Any(Func<TEntity, bool> exp);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
