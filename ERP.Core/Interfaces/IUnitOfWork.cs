using ERP.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : class;
        IBaseRepository<Product> product { get; }
        IBaseRepository<Branch> branch { get; }
        IBaseRepository<Category> category { get; }
        IBaseRepository<Order> order { get; }
        IBaseRepository<OrderItem> orderitems { get; }

        Task<int> Commit();


    }
}
