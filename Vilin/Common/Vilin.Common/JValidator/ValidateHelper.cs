using System.Diagnostics;
using NHibernate.Cfg;
using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace JF.Common.Libary.JValidator
{
    public class ValidateHelper
    {
        //验证电话号码的主要代码如下：
        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }

        //验证手机号码的主要代码如下：
        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^0?(13[0-9]|15[012356789]|18[0236789]|14[57])[0-9]{8}$");
        }

        //验证身份证号的主要代码如下：
        public bool IsIDcard(string str_idcard)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
        }

        //验证输入为数字的主要代码如下：
        public bool IsNumber(string str_number)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_number, @"^[0-9]*$");
        }

        //验证邮编的主要代码如下：
        public bool IsPostalcode(string str_postalcode)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }

        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="str_Email"></param>
        /// <returns></returns>
        public bool IsEmail(string str_Email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Email, @"\\w{1,}@\\w{1,}\\.\\w{1,}");
        }

        /// <summary>检证IP地址的合法性
        /// </summary>
        /// <param name="ip">IP字符串</param>
        /// <returns></returns>
        public static bool IsCorrenctIPAddress(string ip)
        {
            string pattrn = @"^([1-9]|[1-9]\d{1}|1\d\d|2[0-4]\d|25[0-5])\.(([0-9]|[1-9]\d{1}|1\d\d|2[0-4]\d|25[0-5])\.){2}([1-9]|[1-9]\d{1}|1\d\d|2[0-4]\d|25[0-5])$";
            if (System.Text.RegularExpressions.Regex.IsMatch(ip, pattrn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>判断字符串是否Int32类型
        /// </summary>
        /// <param name="number">判断的字符串</param>
        /// <returns></returns>
        public static bool IsInt32Number(string number)
        {
            int outNumber;
            if (int.TryParse(number, out outNumber))
                return true;
            else
                return false;
        }

        /// <summary>判断字符串是否Long类型
        /// </summary>
        /// <param name="number">判断的字符串</param>
        /// <returns></returns>
        public static bool IsLongNumber(string number)
        {
            long outNumber;
            if (long.TryParse(number, out outNumber))
                return true;
            else
                return false;
        }

        /// <summary>判断字符串是否Double类型
        /// </summary>
        /// <param name="number">判断的字符串</param>
        /// <returns></returns>
        public static bool IsDoubleNumber(string number)
        {
            double outNumber;
            if (double.TryParse(number, out outNumber))
                return true;
            else
                return false;
        }

        /// <summary>判断字符串是否Decimal类型
        /// </summary>
        /// <param name="number">判断的字符串</param>
        /// <returns></returns>
        public static bool IsDecimalNumber(string number)
        {
            decimal outNumber;
            if (decimal.TryParse(number, out outNumber))
                return true;
            else
                return false;
        }

        /// <summary>判断字符串是否GUID类型
        /// </summary>
        /// <param name="guidString">判断的字符串</param>
        /// <returns></returns>
        public static bool IsGuid(string guidString)
        {
            bool isGuid = false;
            string strRegexPatten = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\"
                    + @"-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";
            if (guidString != null && !guidString.Equals(""))
            {
                isGuid = System.Text.RegularExpressions.Regex.IsMatch(guidString, strRegexPatten);
            }
            return isGuid;
        }

        /// <summary>是否为日期型字符串
        /// </summary>
        /// <param name="StrSource">日期字符串(格式如: 2008-05-08)</param>
        /// <returns></returns>
        public static bool IsDate(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }

        /// <summary>是否为时间型字符串
        /// </summary>
        /// <param name="source">时间字符串(格式如: 15:00:00)</param>
        /// <returns></returns>
        public static bool IsTime(string StrSource)
        {
            return Regex.IsMatch(StrSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }

        /// <summary>是否为日期+时间型字符串
        /// </summary>
        /// <param name="source">日期时间字符串(格式如: 2008-05-08 15:00:00)</param>
        /// <returns></returns>
        //public static bool IsDateTime(string StrSource)
        //{
        //    return Regex.IsMatch(StrSource, @"^(((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$ ");
        //}

        public static bool IsDateTime(string StrSource)
        {
            DateTime outDateTime;
            if (DateTime.TryParse(StrSource, out outDateTime))
                return true;
            else
                return false;
        }

        /// <summary>字符串转化成DateTime类型
        /// </summary>
        /// <param name="dateTimeString">转类型的字符串</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(string dateTimeString)
        {
            DateTime outDateTime;
            if (DateTime.TryParse(dateTimeString, out outDateTime))
                return outDateTime;
            else
                return null;
        }

        /// <summary>字符串转化成Int32类型
        /// </summary>
        /// <param name="number">转类型的字符串</param>
        /// <returns></returns>
        public static Int32? ToInt32Number(string number)
        {
            int outNumber;
            if (int.TryParse(number, out outNumber))
                return outNumber;
            else
                return null;
        }

        /// <summary>字符串转化成Long类型
        /// </summary>
        /// <param name="number">转类型的字符串</param>
        /// <returns></returns>
        public static long? ToLongNumber(string number)
        {
            long outNumber;
            if (long.TryParse(number, out outNumber))
                return outNumber;
            else
                return null;
        }

        /// <summary>字符串转化成double类型
        /// </summary>
        /// <param name="number">转类型的字符串</param>
        /// <returns></returns>
        public static double? ToDoubleNumber(string number)
        {
            double outNumber;
            if (double.TryParse(number, out outNumber))
                return outNumber;
            else
                return null;
        }

        /// <summary>字符串转化成decimal类型
        /// </summary>
        /// <param name="number">转类型的字符串</param>
        /// <returns></returns>
        public static decimal? ToDecimalNumber(string number)
        {
            decimal outNumber;
            if (decimal.TryParse(number, out outNumber))
                return outNumber;
            else
                return null;
        }

        /// <summary>判断是否双字节字符
        /// </summary>
        public static bool IsTwoBytesChar(char chr)
        {
            string str = chr.ToString();
            // 使用中文支持编码
            Encoding ecode = Encoding.GetEncoding("GB18030");
            if (ecode.GetByteCount(str) == 2)
                return true;
            else
                return false;
        }

        /// <summary>获取字符的ASCII码值
        /// </summary>
        /// <param name="chr">求ASCII码值的字符</param>
        /// <returns>返回ASCII值</returns>
        public static int GetASCII(char chr)
        {
            Encoding ecode = Encoding.GetEncoding("GB18030");
            Byte[] codeBytes = ecode.GetBytes(chr.ToString());
            if (IsTwoBytesChar(chr))
                // 双字节码为高位乘256，再加低位，该为无符号码，再减65536
                return (int)codeBytes[0] * 256 + (int)codeBytes[1] - 65536;
            else
                return (int)codeBytes[0];
        }

        /// <summary>获取双精度数值的科学记数法的字符表达方式
        /// </summary>
        /// <param name="number">要转化的双精度数值</param>
        /// <param name="fractionBit">保留的小数位数</param>
        /// <returns>如: 5.46*10^6</returns>
        public static string GetScienceNotationString(double number, int fractionBit)
        {
            double i = 0;
            double k = 0;
            string fomatdata = string.Empty;

            i = number;
            while (i > 10)
            {
                k += 1;
                i /= (double)10;
            }
            fomatdata = string.Format("#0.{0}", new string('0', fractionBit));
            return i.ToString(fomatdata) + "*10^" + k.ToString();
        }

        public static byte[] SerializeObject(object obj)
        {
            //lock (_LockSerialize) {
            if (obj == null) return null;
            using (var memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                memoryStream.Position = 0;
                byte[] bytes = new byte[memoryStream.Length];
                memoryStream.Read(bytes, 0, bytes.Length);
                return bytes;
            }
        }

        public static object DeserializeObject(byte[] bytes)
        {
            //lock (_LockDeserialize) {
            if (bytes == null) return null;
            using (var memoryStream = new MemoryStream(bytes))
            {
                memoryStream.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(memoryStream);
            }
        }

        public static T DeserializeObject<T>(byte[] bytes) where T : class
        {
            return DeserializeObject(bytes) as T;
        }

        /// <summary>
        /// 判断是否图片格式
        /// </summary>
        /// <param name="type">被判断格式</param>
        /// <returns>是否图片</returns>
        public static bool IsPicType(string type)
        {
            string[] _picTypes = { "gif", "jpg", "jpeg", "png" };
            List<string> _listPicTypes = _picTypes.ToList();
            if (_listPicTypes.Contains(type))
                return true;
            else
                return false;
        }
    }
}