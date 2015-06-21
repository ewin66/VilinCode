using System.Collections.Specialized;
using System.Configuration;

namespace JF.Common.Libary.JConfig
{
    public class ConfigHelper
    {
        public static string GetStringAppSetting(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[name]))
                {
                    throw new ConfigurationErrorsException(string.Format("Missing ConfigSetting \"{0}\"", name));
                }

                return ConfigurationManager.AppSettings[name];
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string GetSectionSetting(string sectionName, string keyName)
        {
            try
            {
                NameValueCollection nvcc = (NameValueCollection)ConfigurationManager.GetSection(sectionName);
                if (string.IsNullOrEmpty(nvcc[keyName]))
                {
                    throw new ConfigurationErrorsException(string.Format("Missing ConfigSetting \"{0}\"", sectionName));
                }

                return nvcc[keyName];
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}