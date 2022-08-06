using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SellPoint.Bussines.Interfaces
{
    interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById<V>(V Id) where V : struct;
        Task<T> FindWhere(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] properties);
        Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] properties);
        Task<bool> Add(T entity);
        Task<bool> Delete<V>(V Id) where V : struct;
        Task<bool> Update(T entity);
        Task<bool> Exists(Expression<Func<T, bool>> predicate);
        Task<bool> CommitChanges();
    }
}
