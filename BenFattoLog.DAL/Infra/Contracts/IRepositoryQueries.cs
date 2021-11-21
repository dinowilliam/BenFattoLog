using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BenFattoLog.DAL.Infra.Contracts {
    public interface IRepositoryQueries<TEntity> where TEntity : class, IEntity {
        TEntity Get(Guid id);
        IList<TEntity> List();
        IList<TEntity> List(Expression<Func<TEntity, bool>> expression);        
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> OrderBy(Expression<System.Func<TEntity, bool>> expression);

    }
}
