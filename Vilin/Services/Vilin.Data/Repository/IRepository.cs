using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Vilin.Data.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> Get<TOrderKey>(Expression<Func<TEntity, bool>> filter, int pagelndex, int pageSize, Expression<Func<TEntity, TOrderKey>> sortExpression, bool isAsc = true);

        int Count(Expression<Func<TEntity, bool>>filter);
        void Add(TEntity instance);
        void Update (TEntity instance) ;
        void Delete(TEntity instance);
    }
}
