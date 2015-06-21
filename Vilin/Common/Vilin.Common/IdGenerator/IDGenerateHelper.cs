using System;
using System.Collections;
using JF.Common.Libary.JEnum;

namespace JF.Common.Libary.IdGenerator
{
    public class IDGenerateHelper
    {
        /// <summary>
        /// 随机数缓存
        /// </summary>
        private static Hashtable ht;

        /// <summary>
        /// 时间戳刻度缓存
        /// </summary>
        private long lastTimeStampStyleTicks;

        /// <summary>
        /// 时间戳缓存（上一次计算ID的系统时间按时间戳刻度取值）
        /// </summary>
        private long lastEndDateTimeTicks;

        public IDGenerateHelper()
        {
            if (ht == null)
                ht = new Hashtable();
            if (jfOrderHt == null)
                jfOrderHt = new Hashtable();
            if (jfBillPurchaseOrderHt == null)
                jfBillPurchaseOrderHt = new Hashtable();
        }

        /// <summary>
        /// IdentityGenerator的静态实例
        /// </summary>
        private static IDGenerateHelper ig;

        public IDGenerateHelper GetInstance()
        {
            if (ig == null)
                ig = new IDGenerateHelper();
            return ig;
        }

        /// <summary>
        /// 按照时间戳刻度计算当前时间戳
        /// </summary>
        /// <param name="startDateTime">起始时间</param>
        /// <param name="timestampStyleTicks">时间戳刻度值</param>
        /// <returns>long</returns>
        private long GetTimestamp(DateTime startDateTime, long timestampStyleTicks)
        {
            if (timestampStyleTicks == 0)
                throw new Exception("时间戳刻度样式精度值不符，不能为0或负数");
            DateTime endDateTime = DateTime.Now;
            long ticks = (endDateTime.Ticks - startDateTime.Ticks) / timestampStyleTicks;
            return ticks;
        }

        /// <summary>
        /// 静态随机数生成器
        /// </summary>
        private static Random random;

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        private long GetRandom(int length)
        {
            if (length <= 0)
                throw new Exception("随机数长度指派错误，长度不能为0或负数");
            if (random == null)
                random = new Random();

            int minValue = 0;
            int maxValue = int.Parse(System.Math.Pow(10, length).ToString());
            long result = long.Parse(random.Next(minValue, maxValue).ToString());
            return result;
        }

        /// <summary>
        /// 计算一个Id
        /// 以2012-1-1 00:00 000为起始时间刻度
        /// </summary>
        /// <returns>long</returns>
        public long GetIdentity()
        {
            DateTime startDateTime = new DateTime(2012, 1, 1, 0, 0, 0, 0);
            TimestampStyle timestampStyle = TimestampStyle.SecondTicks;
            int randomLength = 3;
            return GetIdentity(startDateTime, timestampStyle, randomLength);
        }

        /// <summary>
        /// 计算一个Id
        /// 以2012-1-1 00:00 000为起始时间刻度
        /// </summary>
        /// <param name="timestampStyle">时间戳刻度</param>
        /// <returns>long</returns>
        public long GetIdentity(TimestampStyle timestampStyle)
        {
            DateTime startDateTime = new DateTime(2012, 1, 1, 0, 0, 0, 0);
            int randomLength = 3;
            return GetIdentity(startDateTime, timestampStyle, randomLength);
        }

        /// <summary>
        /// 计算一个Id
        /// </summary>
        /// <param name="randomLength">随机数长度</param>
        /// <returns>long</returns>
        public long GetIdentity(int randomLength)
        {
            DateTime startDateTime = new DateTime(2012, 1, 1, 0, 0, 0, 0);
            TimestampStyle timestampStyle = TimestampStyle.SecondTicks;
            return GetIdentity(startDateTime, timestampStyle, randomLength);
        }

        /// <summary>
        /// 计算一个Id
        /// </summary>
        /// <param name="timestampStyle">时间戳刻度</param>
        /// <param name="randomLength">随机数长度</param>
        /// <returns>long</returns>
        public long GetIdentity(TimestampStyle timestampStyle, int randomLength)
        {
            DateTime startDateTime = new DateTime(2012, 1, 1, 0, 0, 0, 0);
            return GetIdentity(startDateTime, timestampStyle, randomLength);
        }

        /// <summary>
        /// 计算一个Id
        /// </summary>
        /// <param name="startDateTime">时间戳的起始时间</param>
        /// <param name="timestampStyle">时间戳刻度</param>
        /// <param name="randomLength">随机数长度</param>
        /// <returns>long</returns>
        public long GetIdentity(DateTime startDateTime, TimestampStyle timestampStyle, int randomLength)
        {
            long timestampStyleTicks = long.Parse(timestampStyle.ToString("D"));
            return GetIdentity(startDateTime, timestampStyleTicks, randomLength);
        }

        /// <summary>
        /// 计算一个Id
        /// </summary>
        /// <param name="startDateTime">时间戳的起始时间</param>
        /// <param name="timestampStyleTicks">时间戳刻度(毫微秒单位)</param>
        /// <param name="randomLength">随机数长度</param>
        /// <returns>long</returns>
        public long GetIdentity(DateTime startDateTime, long timestampStyleTicks, int randomLength)
        {
            //新一轮时间戳刻度更新后更新缓存
            //如果该参数不变则不进行此更新
            if (timestampStyleTicks != lastTimeStampStyleTicks)
                ht.Clear();

            //取得时间戳（当前时间按刻度取值）
            long timestamp = GetTimestamp(startDateTime, timestampStyleTicks);

            //新一轮时间戳更新后更新缓存
            if (timestamp != lastEndDateTimeTicks)
                ht.Clear();
            //幂
            long power = long.Parse(Math.Pow(10, randomLength).ToString());
            //随机数
            long rand = GetRandom(randomLength);
            //生成结果（Id）
            long result = timestamp * power + rand;
            //long result = rand;

            //如果发现重复
            if (ht.ContainsKey(result))
            {
                //在随机数长度范围内再重复查找一次
                for (int i = 0; i < power; i++)
                {
                    rand = GetRandom(randomLength);
                    result = timestamp * power + rand;
                    //发现非重复的Id
                    if (!ht.ContainsKey(result))
                    {
                        //将新的Id加入HashTable缓存
                        ht.Add(result, result);
                        break;//找到一个同一时间戳内的Id即退出
                    }
                }
                //此处运行在当前时间戳内无法再继续生成Id的代码，如：
                //
                //throw new Exception("已无法生成更多Id，请增加时间戳刻度TimestampStyle或增加随机数长度randomLength");
            }
            else
            {
                //将新的Id加入HashTable缓存
                ht.Add(result, result);
            }
            //记录当前一轮时间戳（当前时间按刻度取值）
            this.lastEndDateTimeTicks = timestamp;
            //记录当前一轮时间戳刻度
            this.lastTimeStampStyleTicks = timestampStyleTicks;
            return result;
        }
        //JF订单编号生成特殊算法
        private static Hashtable jfOrderHt;
        private static DateTime jfOrderlastEndDateTimeTicks;

        private string JFGenerateOrderCode(string EmployeeCode, int deptRole, int randomLength)
        {

            //新一轮时间戳更新后更新缓存
            if ( DateTime.Today != jfOrderlastEndDateTimeTicks)
                jfOrderHt.Clear();
            //幂
            long power = long.Parse(Math.Pow(10, randomLength).ToString());
            //随机数
            long rand = GetRandom(randomLength);
            //生成结果（Id）
            string Perfix = GetCodePerfix(deptRole);
            string result = Perfix + EmployeeCode + DateTime.Today.ToString("yyyyMMdd") + rand.ToString();

            //如果发现重复
            if (jfOrderHt.ContainsKey(result))
            {
                //在随机数长度范围内再重复查找一次
                for (int i = 0; i < power; i++)
                {
                    rand = GetRandom(randomLength);
                    result = Perfix + EmployeeCode + DateTime.Today.ToString("yyyyMMdd") + rand.ToString();
                    //发现非重复的Id
                    if (!jfOrderHt.ContainsKey(result))
                    {
                        //将新的Id加入HashTable缓存
                        ht.Add(result, result);
                        break;//找到一个同一时间戳内的Id即退出
                    }
                }
                //此处运行在当前时间戳内无法再继续生成Id的代码，如：
                //
                //throw new Exception("已无法生成更多Id，请增加时间戳刻度TimestampStyle或增加随机数长度randomLength");
            }
            else
            {
                //将新的Id加入HashTable缓存
                jfOrderHt.Add(result, result);
            }

            jfOrderlastEndDateTimeTicks = DateTime.Today;
            return result;
        }

        //JF采购订单编号生成特殊算法
        private static Hashtable jfBillPurchaseOrderHt;
        private static DateTime jfBillPurchaseOrderlastEndDateTimeTicks;

        private string JFGenerateBillPurchaseOrderCode(int randomLength)
        {

            //新一轮时间戳更新后更新缓存
            if (DateTime.Today != jfBillPurchaseOrderlastEndDateTimeTicks)
                jfBillPurchaseOrderHt.Clear();
            //幂
            long power = long.Parse(Math.Pow(10, randomLength).ToString());
            //随机数
            long rand = GetRandom(randomLength);
            //生成结果（Id）
            string Perfix = "YSM-GX-";
            string result = Perfix + DateTime.Today.ToString("yyyyMMdd") + rand.ToString();

            //如果发现重复
            if (jfBillPurchaseOrderHt.ContainsKey(result))
            {
                //在随机数长度范围内再重复查找一次
                for (int i = 0; i < power; i++)
                {
                    rand = GetRandom(randomLength);
                    result = Perfix + DateTime.Today.ToString("yyyyMMdd") + rand.ToString();
                    //发现非重复的Id
                    if (!jfBillPurchaseOrderHt.ContainsKey(result))
                    {
                        //将新的Id加入HashTable缓存
                        ht.Add(result, result);
                        break;//找到一个同一时间戳内的Id即退出
                    }
                }
            }
            else
            {
                //将新的Id加入HashTable缓存
                jfBillPurchaseOrderHt.Add(result, result);
            }

            jfBillPurchaseOrderlastEndDateTimeTicks = DateTime.Today;
            return result;
        }

        public string JFGenerateStockOrderCode(string prefix)
        {
            long rand = long.Parse(new Random().Next(1000, 9999).ToString());
            return prefix + DateTime.Today.ToString("yyMMddHHmmss") + rand.ToString();
        }

        public static string GenerateStockOrderCode(SysEnum.BILL_TYPE stockType)
        {
            string stockOrderCode = string.Empty;

            switch (stockType)
            {
                case SysEnum.BILL_TYPE.BILL_PURCHASE:
                    stockOrderCode =  new IDGenerateHelper().JFGenerateStockOrderCode("BP");
                    break;
                case SysEnum.BILL_TYPE.STORE_IN:
                    stockOrderCode =  new IDGenerateHelper().JFGenerateStockOrderCode("SI");
                    break;
                case SysEnum.BILL_TYPE.STORE_OUT:
                    stockOrderCode =  new IDGenerateHelper().JFGenerateStockOrderCode("SO");
                    break;
                case SysEnum.BILL_TYPE.EmploySalary:
                    stockOrderCode = new IDGenerateHelper().JFGenerateStockOrderCode("ES");
                    break;

            }

            return stockOrderCode;
        }

        public static string GenerateCode(string EmployeeCode, CODE_TYPE codeType, int deptRole)
        {
            switch (codeType)
            {
                case CODE_TYPE.SALER_ORDER:
                    return  new IDGenerateHelper().JFGenerateOrderCode(EmployeeCode, deptRole, 5);
                case CODE_TYPE.CUSTOMER:
                    return "C" + new IDGenerateHelper().GetIdentity(5).ToString();
                case CODE_TYPE.TAOBAO_CUSTOMER:
                    return "TB" + new IDGenerateHelper().GetIdentity(5).ToString();
                case CODE_TYPE.PROMPT_CODE:
                    return "CX" + new IDGenerateHelper().GetIdentity(5).ToString();
                default: 
                    return string.Empty;
            }
        }

        public static string GeratePurchaseBillCode()
        {
            return new IDGenerateHelper().JFGenerateBillPurchaseOrderCode(4);
        }

        public static string GetCodePerfix(int deptRole)
        {
            switch ((JF.Common.Libary.JEnum.SysEnum.DEPARTMENT_ROLE)deptRole)
            {
                case JF.Common.Libary.JEnum.SysEnum.DEPARTMENT_ROLE.SALES_DEPARTMENT:
                    return "A";
                case JF.Common.Libary.JEnum.SysEnum.DEPARTMENT_ROLE.CUSTOMER_SERVICE_DEPARTMENT:
                    return "B";
                case JF.Common.Libary.JEnum.SysEnum.DEPARTMENT_ROLE.SALES_CUSTOMER_SERVICE_DEPARTMENT:
                    return "C";
                case JF.Common.Libary.JEnum.SysEnum.DEPARTMENT_ROLE.FUNCTIONAL_DEPARTMENT:
                    return "D";
                case JF.Common.Libary.JEnum.SysEnum.DEPARTMENT_ROLE.VIP_SUSTOMER_SERIVCE_DEPARTMENT:
                    return "E";
                default: return "";
            }            
        }
    }

    public enum TimestampStyle : long
    {
        /// <summary>
        /// 时间刻度精度取为1毫秒（此项无意义，因为一般PC机系统时钟只能精确到10毫秒）
        /// </summary>
        MillSecondTicks = 10000,

        /// <summary>
        /// 时间刻度精度取为10毫秒，这是一般PC机系统时钟的最小精度单位
        /// </summary>
        TenMillSecondTicks = 100000,

        /// <summary>
        /// 时间刻度精度取为100毫秒
        /// </summary>
        HundredMillSecondTicks = 1000000,

        /// <summary>
        /// 时间刻度精度取为1秒，即1000毫秒
        /// </summary>
        SecondTicks = 10000000,

        /// <summary>
        /// 时间刻度精度取为5秒
        /// </summary>
        FiveSecondTicks = 50000000,

        /// <summary>
        /// 时间刻度精度取为10秒
        /// </summary>
        TenSecondTicks = 100000000,

        /// <summary>
        /// 时间刻度精度取为1分种（60秒）
        /// </summary>
        MinutesTicks = 600000000
    }

    public enum CODE_TYPE
    {
        SALER_ORDER = 1,
        CUSTOMER = 2,
        TAOBAO_CUSTOMER = 3,
        PROMPT_CODE =4
    }
}