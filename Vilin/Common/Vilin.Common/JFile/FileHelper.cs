using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.IO.Compression;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace JF.Common.Libary.JFile
{
    public class FileHelper
    {
        public static readonly string CurrentDomainDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string CurrentDomainPath = CurrentDomainDirectory.Substring(CurrentDomainDirectory.Length - 1, 1) == "\\" ? CurrentDomainDirectory : CurrentDomainDirectory + "\\";

        public static bool CompareFile(string file1_path, string file2_path)
        {
            //string file1_path = @"E:\readme_1.txt";
            //string file2_path = @"E:\readme_2.txt";
            //计算第一个文件的哈希值
            var hash = System.Security.Cryptography.HashAlgorithm.Create();
            using (FileStream stream_1 = new System.IO.FileStream(file1_path, System.IO.FileMode.Open))
            {
                byte[] hashByte_1 = hash.ComputeHash(stream_1);
                stream_1.Close();
                //计算第二个文件的哈希值
                using (FileStream stream_2 = new System.IO.FileStream(file2_path, System.IO.FileMode.Open))
                {
                    byte[] hashByte_2 = hash.ComputeHash(stream_2);
                    stream_2.Close();

                    //比较两个哈希值
                    if (BitConverter.ToString(hashByte_1) == BitConverter.ToString(hashByte_2))
                    {
                        Console.WriteLine("两个文件相等");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("两个文件不等");
                        return false;
                    }
                }
            }
        }

        public static List<string> GetStrListByReadFile(string filepath)
        {
            List<string> strList = new List<string>();
            ///从指定的目录以打开或者创建的形式读取日志文件
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                StringBuilder output = new StringBuilder();
                output.Length = 0;
                StreamReader read = new StreamReader(fs);
                read.BaseStream.Seek(0, SeekOrigin.Begin);
                while (read.Peek() > -1)
                {
                    strList.Add(read.ReadLine().Replace(',', ' ').Trim());
                }
                read.Close();
            }
            return strList;
        }

        public static byte[] ReadFile(string fileFullName)
        {
            return ReadFile(fileFullName, false);
        }

        public static byte[] ReadFile(string fileFullName, bool throwException)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(fileFullName);
                if (!fileInfo.Exists) throw new Exception("The file does not exist.");

                using (FileStream fileStream = fileInfo.OpenRead())
                {
                    int fileLength = (int)fileStream.Length;
                    byte[] fileSource = new byte[fileLength];
                    fileStream.Read(fileSource, 0, fileLength);
                    return fileSource;
                }
            }
            catch (Exception ex)
            {
                if (throwException) throw ex; else return null;
            }
        }

        public static void WriteFile(string fileFullName, byte[] fileSource)
        {
            if (fileSource == null) return;
            var fileInfo = new FileInfo(fileFullName);
            if (fileInfo.Exists) fileInfo.Delete();
            try
            {
                using (FileStream fileStream = fileInfo.OpenWrite())
                {
                    fileStream.Write(fileSource, 0, fileSource.Length);
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// 检查文件是否存在.
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        ///
        public static bool IsExists(string fileFullName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileFullName)) return false;
                if (!System.IO.File.Exists(fileFullName))
                {
                    return false;
                }
                else return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CopyFile(string fileFromFullName, string fileToFullName)
        {
            try
            {
                var fileInfo = new FileInfo(fileFromFullName);
                if (!IsExists(fileToFullName)) fileInfo.CopyTo(fileToFullName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检查目录是否存在,如果不存在则新增目录.
        /// </summary>
        /// <param name="folderFullName"></param>
        public static void FolderChecking(string folderFullName)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(folderFullName);
                if (!directoryInfo.Exists) directoryInfo.Create();
            }
            catch { throw; }
        }

        public static void DeleteFile(string fileFullName)
        {
            if (!string.IsNullOrEmpty(fileFullName) && IsExists(fileFullName))
            {
                try
                {
                    if (System.IO.File.Exists(fileFullName)) System.IO.File.Delete(fileFullName);
                }
                catch { throw; }
            }
        }

        public static IEnumerable<string> GetFolderFilesName(string folderFullName)
        {
            var files = GetFolderFiles(folderFullName);
            if (files == null)
                return null;
            else
                return files.Select(f => GetFileName(f));
        }

        public static IEnumerable<FileInfo> GetFolderFiles(string folderFullName)
        {
            return GetFolderFiles(folderFullName, null);
        }

        public static IEnumerable<FileInfo> GetFolderFiles(string folderFullName, params string[] notIncludeSubFolders)
        {
            try
            {
                return GetDirectoryFiles(new DirectoryInfo(folderFullName), notIncludeSubFolders);
            }
            catch { throw; }
        }

        private static IEnumerable<FileInfo> GetDirectoryFiles(DirectoryInfo directoryInfo, IEnumerable<string> notIncludeSubFolders)
        {
            if (directoryInfo == null || !directoryInfo.Exists) return null;
            var fileList = new List<FileInfo>();

            var directories = directoryInfo.GetDirectories();
            if (directories != null && directories.Count() > 0)
            {
                foreach (var directory in directories)
                {
                    if (notIncludeSubFolders.Count(f => f.ToUpper() == directory.Name.ToUpper()) > 0) continue;
                    var files = GetDirectoryFiles(directory, notIncludeSubFolders);
                    if (files != null) fileList.AddRange(files);
                }
            }

            var direFiles = directoryInfo.GetFiles();
            if (direFiles == null) return null;
            fileList.AddRange(direFiles);
            return fileList;
        }

        private static string GetFileName(FileInfo file)
        {
            if (file == null || !file.Exists) return null;
            return file.FullName;
        }

        public static byte[] DeCompress(byte[] bytInput)
        {
            using (MemoryStream ms = new MemoryStream(bytInput))
            {
                using (Stream gs = new GZipStream(ms, CompressionMode.Decompress))
                {
                    return ReadStreamToEnd(gs);
                }
            }
        }

        public static byte[] Compress(byte[] bytData)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Stream gs = new GZipStream(ms, CompressionMode.Compress))
                {
                    gs.Write(bytData, 0, bytData.Length);
                }

                return ms.ToArray();
            }
        }

        private static byte[] ReadStreamToEnd(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buffer = new byte[4096];
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead <= 0) break;
                    ms.Write(buffer, 0, bytesRead);
                }
                return ms.ToArray();
            }
        }


        // 按模版比例生成缩略图（以流的方式获取源文件）
        //生成缩略图函数
        //顺序参数：源图文件流、缩略图存放地址、模版宽、模版高
        //注：缩略图大小控制在模版区域内
        public static void MakeSmallImg(Stream fromFileStream, string fileSaveUrl, Double templateWidth, Double templateHeight)
        {
            //从文件取得图片对象，并使用流中嵌入的颜色管理信息
            Image myImage = Image.FromStream(fromFileStream, true);
            //缩略图宽、高
            Double newWidth = myImage.Width;
            Double newHeight = myImage.Height;
            //宽大于模版的横图
            if (myImage.Width > myImage.Height || myImage.Width == myImage.Height)
            {
                if (myImage.Width > templateWidth)
                {
                    //宽按模版，高按比例缩放
                    newWidth = templateWidth;
                    newHeight = myImage.Height * (newWidth / myImage.Width);
                }
            }
            //高大于模版的竖图
            else
            {
                if (myImage.Height > templateHeight)
                {
                    //高按模版，宽按比例缩放
                    newHeight = templateHeight;
                    newWidth = myImage.Width * (newHeight / myImage.Height);
                }
            }
            //取得图片大小
            Size mySize = new Size((int)newWidth, (int)newHeight);
            //新建一个bmp图片
            Image bitmap = new Bitmap(mySize.Width, mySize.Height);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode =  InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode =  SmoothingMode.HighQuality;
            //清空一下画布
            g.Clear(Color.White);
            //在指定位置画图
            g.DrawImage(myImage, new  Rectangle(0, 0, bitmap.Width, bitmap.Height),new  Rectangle(0, 0, myImage.Width, myImage.Height),GraphicsUnit.Pixel);
            ///文字水印
            System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(bitmap);
            System.Drawing.Font f = new Font("宋体", 10);
            System.Drawing.Brush b = new SolidBrush(Color.Black);
            G.DrawString("九凤专用", f, b, 10, 10);
            G.Dispose();
            ///图片水印
            //Image copyImage = Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("pic/1.gif"));
            //Graphics a = Graphics.FromImage(bitmap);
            //a.DrawImage(copyImage, new Rectangle(bitmap.Width - copyImage.Width, bitmap.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
            //copyImage.Dispose();
            //a.Dispose();
            //copyImage.Dispose();
            //保存缩略图
            bitmap.Save(fileSaveUrl, ImageFormat.Jpeg);
            g.Dispose();
            myImage.Dispose();
            bitmap.Dispose();
        }
   
    
    
    
    }
}