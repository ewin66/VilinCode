using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;

namespace JF.Common.Libary.JFile
{

    public class ClientUpdateFileHelper
    {
        private static int _cacheExpireMinutes;
        private static DateTime _lastUpdateTime;
        private static string[] _fileListCache;
        private static string _clientFilePath;
        private static MD5CryptoServiceProvider _mcsp;

        static ClientUpdateFileHelper()
        {
            _clientFilePath = String.Empty;
            _cacheExpireMinutes = 15;
            _fileListCache = null;
            _lastUpdateTime = DateTime.Now;
            _mcsp = new MD5CryptoServiceProvider();
        }

        public ClientUpdateFileHelper()
        {
            try
            {
                _clientFilePath = JConfig.ConfigHelper.GetSectionSetting("ClientUpdate", "FilePath");
                if (!_clientFilePath.EndsWith(@"\"))
                {
                    _clientFilePath += @"\";
                }
                _cacheExpireMinutes = Convert.ToInt32(JConfig.ConfigHelper.GetSectionSetting("ClientUpdate", "CacheExpireMinutes"));
            }
            catch
            {
            }
        }

        private string CaculateHash(string filePath)
        {
            if (_mcsp == null)
                _mcsp = new MD5CryptoServiceProvider();

            using (FileStream stream1 = File.OpenRead(filePath))
            {
                int num1 = Convert.ToInt32(stream1.Length);
                byte[] buffer1 = new byte[num1];
                int num2 = 0;
                int num3 = num1;
                int num4 = 0;
                do
                {
                    num4 = stream1.Read(buffer1, num2, num3);
                    num2 += num4;
                    num3 -= num4;
                } while (num2 < num1);

                string text1 = string.Empty;
                byte[] buffer2 = _mcsp.ComputeHash(buffer1);
                for (int num5 = 0; num5 < buffer2.Length; num5++)
                {
                    text1 = text1 + buffer2[num5].ToString("x").PadLeft(2, '0');
                }
                return text1;
            }
        }

        public string[] GetClientFileList()
        {
            if (!Directory.Exists(_clientFilePath))
                return new string[0];

            DateTime now = DateTime.Now;

            lock (typeof(string[]))
            {
                if (_fileListCache != null && (now - _lastUpdateTime).TotalMinutes < _cacheExpireMinutes)
                {
                    return _fileListCache;
                }
            }

            ArrayList list = new ArrayList();
            this.GetDirectoryFiles(_clientFilePath, ref list);

            lock (typeof(string[]))
            {
                _fileListCache = null;
                _fileListCache = (string[])list.ToArray(typeof(string));
                _lastUpdateTime = now;
            }

            return _fileListCache;
        }

        public byte[] GetClientUpdateFile(string fileName)
        {
            byte[] buffer2;
            string text1 = _clientFilePath + fileName;
            using (FileStream stream1 = File.OpenRead(text1))
            {
                int num1 = Convert.ToInt32(stream1.Length);
                byte[] buffer1 = new byte[num1];
                int num2 = 0;
                int num3 = num1;
                int num4 = 0;
                do
                {
                    num4 = stream1.Read(buffer1, num2, num3);
                    num2 += num4;
                    num3 -= num4;
                } while (num2 < num1);
                stream1.Close();
                buffer2 = buffer1;
            }
            return buffer2;
        }

        private void GetDirectoryFiles(string filePath, ref ArrayList fileList)
        {
            string[] files = Directory.GetFiles(filePath);
            for (int i = 0; i < files.Length; i++)
            {
                string fileHash = this.CaculateHash(files[i]);
                string fileName = files[i].Substring(_clientFilePath.Length);
                fileList.Add(fileHash + fileName);
            }
            string[] dirs = Directory.GetDirectories(filePath);
            for (int i = 0; i < dirs.Length; i++)
            {
                string dirName = dirs[i];
                this.GetDirectoryFiles(dirName, ref fileList);
            }
        }
    }
}