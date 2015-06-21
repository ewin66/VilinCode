using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using JF.Common.Libary.JConfig;
using System.Runtime.InteropServices;

namespace JF.Common.Libary.JEncodeFunc
{
    public sealed class EncodeAndDecodeHelper
    {
        private SymmetricAlgorithm mobjCryptoService;
        private string Key = string.Empty;
        private string[] straRam = {  "D3", "e1", "v0", "i2", "dt", "JA","og", "in", "nu", "ef", "do" };

        /// <summary>
        /// 对称加密类的构造函数
        /// </summary>
        public EncodeAndDecodeHelper()
        {
            mobjCryptoService = new RijndaelManaged();
            Key = ConfigHelper.GetStringAppSetting("DESKEY");
        }

        public static string PraseEnd5Num(string orgNum)
        {
            if (!String.IsNullOrEmpty(orgNum))
            {
                int phoneLength = orgNum.Length;
                if (phoneLength >= 7)
                    return orgNum.Replace(orgNum.Substring(phoneLength - 5, 5), "*****");
                else
                    return orgNum;
            }
            else
            {
                return orgNum;
            }
        }

        public static string EncryptPhone(string phone)
        {
            try
            {
                return PasswordEncryption(phone);
            }
            catch
            {
                return phone;
            }
        }

        public static string DecryptPhone(string phone)
        {
            try
            {
                return PasswordDecryption(phone);
            }
            catch
            {
                return phone;
            }
        }

        /// <summary>
        /// 获得密钥
        /// </summary>
        /// <returns>密钥</returns>
        private byte[] GetLegalKey()
        {
            string sTemp = Key;
            try
            {
                mobjCryptoService.GenerateKey();
                byte[] bytTemp = mobjCryptoService.Key;
                int KeyLength = bytTemp.Length;
                if (sTemp.Length > KeyLength)
                    sTemp = sTemp.Substring(0, KeyLength);
                else if (sTemp.Length < KeyLength)
                    sTemp = sTemp.PadRight(KeyLength, ' ');
                return ASCIIEncoding.ASCII.GetBytes(sTemp);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private byte[] GetLegalIV()
        {
            string sTemp = "123E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
            try
            {
                mobjCryptoService.GenerateIV();
                byte[] bytTemp = mobjCryptoService.IV;
                int IVLength = bytTemp.Length;
                if (sTemp.Length > IVLength)
                    sTemp = sTemp.Substring(0, IVLength);
                else if (sTemp.Length < IVLength)
                    sTemp = sTemp.PadRight(IVLength, ' ');
                return ASCIIEncoding.ASCII.GetBytes(sTemp);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>
        private string Encrypto(string Source)
        {
            Random rd = new Random(100);
            string strMix = "";
            int intOut;
            if (Source.Length > 1)
            {
                if (int.TryParse(Source.Substring(0, 1), out intOut))
                {
                    strMix = straRam[intOut];
                }
                else
                {
                    strMix = straRam[10];
                }
            }
            else
            {
                strMix = straRam[10];
            }
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            using (MemoryStream ms = new MemoryStream())
            {
                mobjCryptoService.Key = GetLegalKey();
                mobjCryptoService.IV = GetLegalIV();
                ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
                cs.Write(bytIn, 0, bytIn.Length);
                cs.FlushFinalBlock();
                ms.Close();
                byte[] bytOut = ms.ToArray();
                return strMix + Convert.ToBase64String(bytOut);
            }
        }

        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>
        private string Decrypto(string Source)
        {
            Source = Source.Substring(2);
            byte[] bytIn = Convert.FromBase64String(Source);
            using (MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length))
            {
                mobjCryptoService.Key = GetLegalKey();
                mobjCryptoService.IV = GetLegalIV();
                ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
                using (StreamReader sr = new StreamReader(cs))
                { 
                    return sr.ReadToEnd(); 
                }
            }
        }

        /// <summary>
        /// Base64位编码加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }

        /// <summary>
        /// Base64位编码解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string str)
        {
            byte[] decbuff = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }

        public static string PasswordEncryption(string source)
        {
            EncodeAndDecodeHelper ep = new EncodeAndDecodeHelper();
            return ep.Encrypto(source);
        }

        public static string PasswordDecryption(string source)
        {
            EncodeAndDecodeHelper ep = new EncodeAndDecodeHelper();
            return ep.Decrypto(source);
        }

    }
}