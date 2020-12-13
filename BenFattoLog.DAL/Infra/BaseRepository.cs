using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BenFattoLog.DAL.Infra.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BenFattoLog.DAL.Infra {
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext:  DbContext {

        private readonly TContext _dataContext;

        public BaseRepository(TContext dataContext) {
            this._dataContext = dataContext;
        }

        public int Delete(TEntity entity) {
            this._dataContext.Set<TEntity>().Remove(entity);
            return this._dataContext.SaveChanges();
        }

        public TEntity Get(Guid id) {
            return this._dataContext.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity) {
            this._dataContext.Set<TEntity>().Add(entity);
            return this._dataContext.SaveChanges();
        }

        public int AddRange(IEnumerable<TEntity> entities) {
            this._dataContext.Set<TEntity>().AddRange(entities);
            return this._dataContext.SaveChanges();
        }

        public IList<TEntity> List() {
            return this._dataContext.Set<TEntity>().ToList();
        }

        public IList<TEntity> List(Expression<Func<TEntity, bool>> expression) {
            return this._dataContext.Set<TEntity>().Where(expression).ToList();
        }

        public int Update(TEntity entity) {
            this._dataContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return this._dataContext.SaveChanges();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression) {
            return this._dataContext.Set<TEntity>().Where(expression);
        }

        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> expression) {
            return this._dataContext.Set<TEntity>().OrderBy(expression);
        }
    }
}