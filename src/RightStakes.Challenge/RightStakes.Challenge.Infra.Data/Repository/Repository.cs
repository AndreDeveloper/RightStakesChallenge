using Microsoft.EntityFrameworkCore;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Infra.Data.Context;
using System;
using System.Linq;

namespace RightStakes.Challenge.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly RightStakesContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(RightStakesContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public bool Any(Func<TEntity, bool> exp)
        {
            return DbSet.Any(exp);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp)
        {
            return DbSet.Where(exp).AsQueryable();
        }

        public TEntity GetBy(Func<TEntity, bool> exp)
        {
            return DbSet.FirstOrDefault(exp);
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
            Db.SaveChanges();
        }
    }
}
