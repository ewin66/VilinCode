using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vilin.Models;

namespace Vilin.Core.IServer
{
    public interface IOrderServer
    {
        IEnumerable<OrderModel> GetAllOrder();

        void Add(OrderModel ob);

        string GetTimeNow();
    }
}
