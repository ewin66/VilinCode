using System;

namespace JF.Common.Libary.TimeFunc
{
    public class DateTimeConvertor
    {
        public static string LongStrYearMonthDayHourMinuteSecond
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public static string ConvertDateTimeToString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss"); 
        }

        public static DateTime ConvertStringToDateTime(string strDatetime)
        {
            return DateTime.Parse(strDatetime);
        }
    }
}