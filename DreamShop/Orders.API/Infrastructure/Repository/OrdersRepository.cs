using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.API.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Infrastructure.Repository
{
    public class OrdersRepository: IOrdersRepository
    {
        private readonly DbSet<Model.Orders> _dbSet = null;

        private readonly OrdersDbContext ordersDbContext;

        public OrdersRepository()
        {
            this._dbSet = ordersDbContext.Orders;
        }

        public async Task<List<Model.Orders>> Get()
        {
            return await  _dbSet.AsQueryable().ToListAsync();

        }

        public async Task<Model.Orders> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
