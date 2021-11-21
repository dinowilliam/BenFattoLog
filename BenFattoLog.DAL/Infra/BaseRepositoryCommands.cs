using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BenFattoLog.DAL.Infra {
    
    using BenFattoLog.DAL.Infra.Contracts;

    public abstract class BaseRepositoryCommands<TEntity, TContext> : IRepositoryCommands<TEntity>
        where TEntity : class, IEntity
        where TContext:  DbContext {

        private readonly TContext _dataContext;

        public BaseRepositoryCommands(TContext dataContext) {
            this._dataContext = dataContext;
        }

        public int Delete(TEntity entity) {
            this._dataContext.Set<TEntity>().Remove(entity);
            return this._dataContext.SaveChanges();
        }        

        public int Insert(TEntity entity) {
            this._dataContext.Set<TEntity>().Add(entity);
            return this._dataContext.SaveChanges();
        }

        public int AddRange(IEnumerable<TEntity> entities) {
            this._dataContext.Set<TEntity>().AddRange(entities);
            return this._dataContext.SaveChanges();
        }
        
        public int Update(TEntity entity) {
            this._dataContext.Entry<TEntity>(entity).State = EntityState.Modified;
            return this._dataContext.SaveChanges();
        }
        
    }
}