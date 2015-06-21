using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace JF.Common.Libary.JFile
{
   public class HtmlExtension
    {
        private static readonly string s_root = HttpRuntime.AppDomainAppPath.TrimEnd('\\');

        public static string RefJsFileHtml(string path)
        {
            string filePath = s_root + path.Replace("/", "\\");
            string version = File.GetLastWriteTimeUtc(filePath).Ticks.ToString();
            return string.Format("<script type=\"text/javascript\" src=\"{0}?_t={1}\"></script>\r\n", path, version);
        }

        public static string RefCssFileHtml(string path)
        {
            string filePath = s_root + path.Replace("/", "\\");
            string version = File.GetLastWriteTimeUtc(filePath).Ticks.ToString();
            return string.Format("<link type=\"text/css\" rel=\"Stylesheet\" href=\"{0}?_t={1}\" />\r\n", path, version);
        }
    }
}
