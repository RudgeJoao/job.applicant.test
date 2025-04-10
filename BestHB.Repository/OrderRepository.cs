using BestHB.Domain.Entities;
using BestHB.Domain.Queries;
using BestHB.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BestHB.Repository //TODO: Um projeto apenas para repositories
{
    public class OrderRepository : IRepository //Devia ter a propria Interface IOrderRepository?
    {
        public OrderRepository()
        {

        }

        public async Task<int> Add(Order order)
        {
            return await Task.Run(() => { return 123; });
        }

        public async Task<List<Order>> Get(QueryOrders queryOrders)
        {
            return await Task.Run(() => { return new List<Order>(); });
        }

        public Task<InstrumentInfo> Get(string symbol)
        {
            throw  new NotImplementedException();
        }
    }
}
