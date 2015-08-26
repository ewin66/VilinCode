using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vilin.Common.ThreadQueue
{
    public class OrderModel : BaseThreadQueueModel
    {
        public string OrderCode { get; set; }

        public int MemberID { get; set; }

        public int Count { get; set; }

        public DateTime OrderTime { get; set; }
    }
}
