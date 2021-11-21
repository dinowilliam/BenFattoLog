using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BenFattoLog.DAL.Infra {

    using BenFattoLog.DAL.Infra.Contracts;

    public abstract class BaseRepositoryQueries<TEntity, TContext> : IRepositoryQueries<TEntity>
        where TEntity : class, IEntity
        where TContext:  DbContext {

        private readonly TContext _dataContext;

        public BaseRepositoryQueries(TContext dataContext) {
            this._dataContext = dataContext;
        }

        public TEntity Get(Guid id) {
            return this._dataContext.Set<TEntity>().Find(id);
        }
        
        public IList<TEntity> List() {
            return this._dataContext.Set<TEntity>().ToList();
        }

        public IList<TEntity> List(Expression<Func<TEntity, bool>> expression) {
            return this._dataContext.Set<TEntity>().Where(expression).ToList();
        }
        
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression) {
            return this._dataContext.Set<TEntity>().Where(expression);
        }

        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> expression) {
            return this._dataContext.Set<TEntity>().OrderBy(expression);
        }
    }
}