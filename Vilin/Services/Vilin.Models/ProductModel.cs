using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vilin.Models
{
    public class ProductModel : EntityBase<int>
    {
        public virtual string ProductCode { get; set; }

        public virtual string ProductName { get; set; }

        public virtual int Count { get; set; }

        public virtual List<OrderModel> Orders { get; set; }
    }
}
