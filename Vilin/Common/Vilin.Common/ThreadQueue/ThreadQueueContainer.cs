using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilin.Common.ThreadQueue
{
    public static class ThreadQueueContainer<T> where T: BaseThreadQueueModel
    {
        private static Dictionary<string, T> dic = new Dictionary<string, T>();
        private static Queue queue { get; set; }

        public static void AddQueue(T d)
        {
            if (queue == null)
                queue = new Queue();

            queue.Enqueue(d);
        }

        public static T GetQueue()
        {
            if (queue == null )
                queue = new Queue();

            T t = queue.Dequeue() as T;
            if(!dic.ContainsKey(t.key))
            {
                dic.Add(t.key, t);
            }

           return t;
        }

        public static T GetDic(string key)
        {
            if (dic.ContainsKey(key))
            {
                T t = dic[key];
                dic.Remove(key);
               return  t;
            }

            return null;
        }

        public static int QueueCount { get { return queue.Count; } }
    }
}
