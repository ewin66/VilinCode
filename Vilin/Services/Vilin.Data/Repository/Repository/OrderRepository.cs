using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vilin.Models;

namespace Vilin.Data.Repository
{
    public class OrderRepository : Repository<OrderModel>, IOrderRepository
    {
        public OrderRepository()
        { }

        public IEnumerable<OrderModel> GetAllOrder()
        {
            return base.Get();
        }

        public void Add(OrderModel ob)
        {
            base.Add(ob);
        }
    }
}
