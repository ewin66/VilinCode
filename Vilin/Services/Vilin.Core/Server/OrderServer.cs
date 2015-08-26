using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vilin.Core.IServer;
using Vilin.Data.Repository;
using Vilin.Models;
using Vilin.Common.Atrribute;

namespace Vilin.Core.Server
{
    public class OrderServer : ServiceBase, IOrderServer
    {
        private IOrderRepository orderRepository{get; set;}

        public OrderServer(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<OrderModel> GetAllOrder()
        {
            return this.orderRepository.GetAllOrder();
        }

        public void Add(OrderModel ob)
        {
            this.orderRepository.Add(ob);
        }


        public string GetTimeNow()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }
    }
}
