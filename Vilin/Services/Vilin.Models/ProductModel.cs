using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vilin.Models
{
    public class ProductModel : EntityBase<int>
    {
        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public int Count { get; set; }
    }
}
