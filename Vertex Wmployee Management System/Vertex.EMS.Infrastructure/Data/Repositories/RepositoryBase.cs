using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vertex.EMS.Application.Common.Interfaces;

namespace Vertex.EMS.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public AppDbContext _appDbContext { get; }

        public RepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T> FindSingleAsync(Expression<Func<T, bool>> expression)
        {
            return await _appDbContext.Set<T>().FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
           await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> FindAllWithIncludeAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return await query.ToListAsync();
        }
    }
}
