using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vilin.Common.ThreadQueue
{
    public static class ThreadQueueCore<T> where T : BaseThreadQueueModel
    {
        private static Thread thread = null;

        static ThreadQueueCore()
        {
            thread = new Thread(new ThreadStart(DealQueue));  
        }

        public static void Add(T d)
        {
            ThreadQueueContainer<T>.AddQueue(d);

            if (thread.ThreadState == ThreadState.Suspended)
            {
                thread.Resume();
            }
            else if (thread.ThreadState == ThreadState.Unstarted || thread.ThreadState == ThreadState.Stopped)
            {
                thread.Start();
            }

            d.SourceManualResetEvent.WaitOne();
        }

        public static T Get(string key)
        {
            return ThreadQueueContainer<T>.GetDic(key);
        }

        private static void DealQueue()
        {
            while (ThreadQueueContainer<T>.QueueCount > 0)
            {
                T t = ThreadQueueContainer<T>.GetQueue();

                Thread.Sleep(1000 * 10);
                t.state = 1;
                t.SourceManualResetEvent.Set();
            }

            thread.Suspend();
        }
    }
}
