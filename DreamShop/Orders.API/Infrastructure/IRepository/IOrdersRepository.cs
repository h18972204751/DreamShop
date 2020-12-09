using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Infrastructure.IRepository
{
    public interface IOrdersRepository
    {

        public Task<List<Model.Orders>> Get();

        public Task<Model.Orders> Get(int id);
    }
}
