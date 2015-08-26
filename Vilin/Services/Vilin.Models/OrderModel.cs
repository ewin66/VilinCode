using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vilin.Models
{
    public class OrderModel : EntityBase<int>
    {
        public string OrderCode { get; set; }

        public string ProductCode { get; set; }
    }
}
