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
            _dataContext = dataContext;
        }

        public int Delete(TEntity entity) {
            _dataContext.Set<TEntity>().Remove(entity);
            return _dataContext.SaveChanges();
        }

        public TEntity Get(Guid id) {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public int Insert(TEntity entity) {
            _dataContext.Set<TEntity>().Add(entity);
            return _dataContext.SaveChanges();
        }

        public IList<TEntity> List() {
            return _dataContext.Set<TEntity>().ToList();
        }

        public IList<TEntity> List(Expression<Func<TEntity, bool>> expression) {
            return _dataContext.Set<TEntity>().Where(expression).ToList();
        }

        public int Update(TEntity entity) {
            _dataContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return _dataContext.SaveChanges();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression) {
            return _dataContext.Set<TEntity>().Where(expression);
        }

        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> expression) {
            return _dataContext.Set<TEntity>().OrderBy(expression);
        }
    }
}