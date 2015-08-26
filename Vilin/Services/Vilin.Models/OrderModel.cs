using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vilin.Models
{
    public class OrderModel : EntityBase<int>
    {
        public virtual string OrderCode { get; set; }

        public virtual string ProductCode { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
