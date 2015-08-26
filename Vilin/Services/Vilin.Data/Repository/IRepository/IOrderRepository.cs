using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vilin.Models;

namespace Vilin.Data.Repository
{
    public interface IOrderRepository 
    {
        IEnumerable<OrderModel> GetAllOrder();

        void Add(OrderModel ob);
    }
}
