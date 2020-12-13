using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq.Expressions;

namespace BenFattoLog.DAL.Infra.Contracts {
    public interface IRepository<TEntity> where TEntity : class, IEntity {
        TEntity Get(Guid id);
        IList<TEntity> List();
        IList<TEntity> List(Expression<Func<TEntity, bool>> expression);
        int Insert(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> OrderBy(Expression<System.Func<TEntity, bool>> expression);
    }
}
