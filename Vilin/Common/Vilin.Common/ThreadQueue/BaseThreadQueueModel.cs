using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vilin.Common.ThreadQueue
{
    public abstract class BaseThreadQueueModel
    {
        public string key { get; set; }

        public int state { get; set; }

        public ManualResetEvent SourceManualResetEvent { get; set; }
    }
}
