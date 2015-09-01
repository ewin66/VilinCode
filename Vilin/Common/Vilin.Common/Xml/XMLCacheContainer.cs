using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vilin.Common
{
    public static class XMLCacheContainer
    {
        private static Dictionary<string, object> Dic = new Dictionary<string, object>();

        public static void Add(string key, object obj)
        {
            object lockObj = new object();
            lock (lockObj)
            {
                if (Dic.ContainsKey(key))
                {
                    Dic[key] = obj;
                }
                else
                {
                    Dic.Add(key, obj);
                }
            }
        }

        public static object GetByKey(string key)
        {
            if (Dic.ContainsKey(key))
            {
                return Dic[key];
            }

            return null;
        }

        public static bool ContainsKey(string key)
        {
            if (Dic.ContainsKey(key))
            {
                return true;
            }

            return false;
        }

        public static void Clear()
        {
            Dic.Clear();
        }

        public static List<string> GetDicKeys()
        {
            return Dic.Keys.ToList();
        }
    }
}