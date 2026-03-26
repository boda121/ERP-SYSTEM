using ERP.Core.Interfaces;
using ERP.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.EF.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _appDbContext;

        public IBaseRepository<Product>  product{ get; private set; }
        public IBaseRepository<Branch>   branch { get; private set; }
        public IBaseRepository<Category> category { get; private set; }
        public IBaseRepository<Order>    order { get; private set; }
        public IBaseRepository<OrderItem> orderitems { get; private set; }
        public IBaseRepository<Payment>  payment { get; private set; }
        public IBaseRepository<ErrorLog> Errorlog { get; private set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            product  = new BaseRepository<Product>(appDbContext);
            branch   = new BaseRepository<Branch>(appDbContext);
            category = new BaseRepository<Category>(appDbContext);
            order    = new BaseRepository<Order>(appDbContext);
            orderitems = new BaseRepository<OrderItem>(appDbContext);
            payment  = new BaseRepository<Payment>(appDbContext);
            Errorlog = new BaseRepository<ErrorLog>(appDbContext);
        }
        public async Task<int> Commit()
        {
          return _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public IBaseRepository<T> Repository<T>() where T : class
        {
            return new BaseRepository<T>(_appDbContext);
        }
    }
}
