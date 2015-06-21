using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JF.Common.Libary.JAtrribute;

namespace JF.Common.Libary.JEnum
{
    public class EnumHelper<T>
        where T : class
    {
        private static bool IsInited = false;

        public static List<EnumInfo> JFEnumInfoList
        {
            get;
            set;
        }

        /// <summary>
        /// get all enume list,this list include the enume name,key name, value, hashcode
        /// </summary>
        /// <returns></returns>
        public static List<EnumInfo> GetEnumInfoList()
        {
            if (!IsInited)
            {
                List<EnumInfo> jfEnumInfoList = new List<EnumInfo>();
                Type[] plist = typeof(T).GetNestedTypes(BindingFlags.Public).Where(r => r.IsEnum).ToArray();
                foreach (Type type in plist)
                {
                    foreach (var value in Enum.GetValues(type))
                    {
                        string key = Enum.GetName(type, value);
                        object[] attrArray = type.GetField(key).GetCustomAttributes(typeof(NameAttribute), false);
                        string attrname = attrArray.Length > 0 ? ((NameAttribute)attrArray[0]).Name : key;
                        EnumInfo nkv = new EnumInfo();
                        nkv.EnumName = type.Name;
                        nkv.AttriName = attrname;
                        nkv.Key = key;
                        nkv.Value = value.GetHashCode();

                        jfEnumInfoList.Add(nkv);
                    }
                }
                IsInited = true;
                JFEnumInfoList = jfEnumInfoList;
            }
            return JFEnumInfoList;
        }

        public static string GetEnumAttributeName(Enum obj)
        {
            string typename = obj.GetType().Name;
            string typekey = Enum.GetName(obj.GetType(), obj);
            return GetEnumInfoList().Where(r => r.EnumName == typename && r.Key == typekey).Select(r => r.AttriName).FirstOrDefault();
        }

    }
}