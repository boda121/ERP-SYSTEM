using ERP.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ERP.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext _appDbContext;
        public BaseRepository(AppDbContext appDb)
        {
            _appDbContext = appDb;
            
        }
        public   T Add(T entity)
        {
          _appDbContext.Set<T>().AddAsync(entity);

            return entity;

        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _appDbContext.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {

           return _appDbContext.Set<T>().Find(id);

        }

        public async void  Update(T entity)
        {

           _appDbContext.Set<T>().Update(entity);

        }
    }
}
