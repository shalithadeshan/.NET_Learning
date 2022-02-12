using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vertex.EMS.Application.Common.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<List<T>> FindAllAsync();
        Task<List<T>> FindAllWithIncludeAsync(params Expression<Func<T, object>>[] includes);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> FindSingleAsync(Expression<Func<T, bool>> expression);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
