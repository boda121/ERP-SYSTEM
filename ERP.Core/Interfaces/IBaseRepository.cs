using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ERP.Core.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
       
        Task<IEnumerable<T>> GetAllAsync (params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync (int id);
        T Add (T entity);
        void Update (T entity);
        void Delete (T entity);

        
          

    }
}
