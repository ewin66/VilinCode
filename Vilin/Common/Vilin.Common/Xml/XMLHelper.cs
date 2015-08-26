﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Vilin.Common
{
    public static class XMLHelper<T> 
    {
        public static List<T> Get
        {
            get
            {
                try
                {
                    if (XMLContainer.ContainsKey(Getkey))
                    {
                        return (List<T>)XMLContainer.GetByKey(Getkey);
                    }

                    string path = string.Format("~/Data/{0}.xml", Getkey);
                    List<T> obj = LoadEntity(path);
                    if (obj != null)
                    {
                        Add(obj);
                    }

                    return obj;
                }
                catch (Exception ex)
                {
                    //LogHelper.WebLog("StaticResourceContainer.Get Exception：" + ex.Message + ex.StackTrace);
                    return null;
                }
            }
        }

        public static void Add(List<T> obs)
        {
            try
            {
                object lockObj = new object();
                lock (lockObj)
                {
                    XMLContainer.Add(Getkey, obs);
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WebLog("StaticResourceContainer.Add Exception：" + ex.Message + ex.StackTrace);
            }
        }

        private static string Getkey
        {
            get
            {
                string key = typeof(T).Name;
                key = key.Replace("Info", "");
                key = key.Replace("Model", "");

                return key;
            }
        }

        private static List<T> LoadEntity(string path)
        {
            string rootName = typeof(T).Name;
            rootName = rootName.Replace("Info", "sInfo");
            rootName = rootName.Replace("Model", "sModel");

            XmlSerializer ser = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));
            FileStream fs = File.OpenRead(System.Web.HttpContext.Current.Server.MapPath(path));
            List<T> obs = (List<T>)ser.Deserialize(fs);
            fs.Close();

            return obs;
        }
    }
}