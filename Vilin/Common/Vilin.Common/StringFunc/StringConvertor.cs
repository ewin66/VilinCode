namespace JF.Common.Libary.StringFunc
{
    public class StringConvertor
    {
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        public static string SqlStringFilter(string s)
        {
            s = s.Replace("\'", "‘");
            s = s.Replace("\"", "“");
            s = s.Replace(",", "，");
            s = s.Replace(";", "；");
            s = s.Replace("--", "——");
            return s;
        }

        /// <summary>
        /// 替换所有输入的字符串中非法字符
        /// </summary>
        /// <param name="strFromText"></param>
        /// <returns></returns>
        public static string TextReplaceIllegalChar(string strFromText)
        {
            if (!string.IsNullOrEmpty(strFromText))
            {
                //strFromText = strFromText.Replace(">", "&gt;");
                //strFromText = strFromText.Replace("<", "&lt;");
                //strFromText = strFromText.Replace(" ", "&nbsp;");
                //strFromText = strFromText.Replace(" ", "&nbsp;");
                //strFromText = strFromText.Replace("/'", "'");
                //strFromText = strFromText.Replace("/n", "<br/> ");

            }
            return strFromText;
        }
    }
}