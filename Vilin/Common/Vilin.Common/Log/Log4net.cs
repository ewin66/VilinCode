using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vilin.Common
{
    public class Log4net
    {
        private static readonly ILog info = log4net.LogManager.GetLogger("loginfo");   //选择<logger name="loginfo">的配置 
        private static readonly ILog err = log4net.LogManager.GetLogger("logerror");   //选择<logger name="logerror">的配置 

        public static void Info(string content)
        {
            info.Info(content);
        }

        public static void Error(string content, Exception ex)
        {
            err.Error(content, ex);
        }   
    }
}
