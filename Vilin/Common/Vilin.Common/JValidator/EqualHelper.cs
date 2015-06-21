using System;
using System.Collections.Generic;

namespace JF.Common.Libary.JValidator
{
    public class EqualHelper
    {
        /// <summary>
        /// 字符串为空，返回默认值
        /// </summary>
        /// <param name="orgString">被判断字符串</param>
        /// <param name="defaultString">默认字符串</param>
        /// <returns>结果字符串</returns>
        public static string GetNoEmptyString(string orgString, string defaultString = "")
        {
            return String.IsNullOrEmpty(orgString) ? defaultString : orgString;
        }
    }

    public delegate bool EqualsComparer<T>(T x, T y);

    public class Compare<T> : IEqualityComparer<T>
    {
        private EqualsComparer<T> _equalsComparer;

        public Compare(EqualsComparer<T> equalsComparer)
        {
            this._equalsComparer = equalsComparer;
        }

        public bool Equals(T x, T y)
        {
            if (null != this._equalsComparer)
                return this._equalsComparer(x, y);
            else
                return false;
        }

        public int GetHashCode(T obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}