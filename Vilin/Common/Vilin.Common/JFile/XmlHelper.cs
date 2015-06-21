using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using System.Web;
using JF.Common.Libary.TimeFunc;

namespace JF.Common.Libary.JFile
{
    /// <summary>
    /// 操作xml文件通用类
    /// </summary>
    public sealed class XmlHelper
    {
        private string strXmlFile;
        private XmlDocument objXmlDoc = new XmlDocument();

        public XmlHelper(string xmlfile)
        {
            try
            {
                objXmlDoc.Load(xmlfile);
                strXmlFile = xmlfile;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查找xml数据,返回一个DataView
        /// </summary>
        /// <param name="XmlPathNode"></param>
        /// <returns></returns>
        public DataView GetData(string XmlPathNode)
        {
            DataSet ds = new DataSet();
            StringReader read = new StringReader(objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 追加元素
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newElementName"></param>
        /// <param name="innerValue"></param>
        /// <returns></returns>
        public XmlNode AppendElement(XmlNode node, string newElementName, string innerValue)
        {
            XmlNode node2;
            if (node is XmlDocument)
            {
                node2 = node.AppendChild(((XmlDocument)node).CreateElement(newElementName));
            }
            else
            {
                node2 = node.AppendChild(node.OwnerDocument.CreateElement(newElementName));
            }
            if (!string.IsNullOrEmpty(innerValue))
            {
                node2.AppendChild(node.OwnerDocument.CreateTextNode(innerValue));
            }
            return node2;
        }

        /// <summary>
        /// 创建属性
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute attribute = xmlDocument.CreateAttribute(name);
            attribute.Value = value;
            return attribute;
        }

        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetAttribute(XmlNode node, string attributeName, string defaultValue)
        {
            XmlAttribute attribute = node.Attributes[attributeName];
            if (attribute != null)
            {
                return attribute.Value;
            }
            return defaultValue;
        }



        /// <summary>
        /// 获取节点的值
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="nodeXPath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public string GetNodeValue(XmlNode parentNode, string nodeXPath, string defaultValue)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeXPath);
            if (node.FirstChild != null)
            {
                return node.FirstChild.Value;
            }
            if (node != null)
            {
                return node.Value;
            }
            return defaultValue;
        }


        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        public void SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            if (node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].Value = attributeValue;
            }
            else
            {
                node.Attributes.Append(CreateAttribute(node.OwnerDocument, attributeName, attributeValue));
            }
        }

        public bool UpdateNode(string xmlFileName, string nodePath, string newInnerText)
        {
            try
            {
                objXmlDoc.Load(xmlFileName);
                XmlNode xmlnode = objXmlDoc.SelectSingleNode(nodePath);
                if (xmlnode != null)
                {
                    xmlnode.InnerText = newInnerText;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        ///保存文檔
        /// </summary>
        public bool Save()
        {
            try
            {
                objXmlDoc.Save(strXmlFile);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objXmlDoc = null;
            }

        }


        /// <summary>
        ///替换xml中无效字符
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string XmlIllegalCharacters(string content)
        {
            return System.Text.RegularExpressions.Regex.Replace(content, "[\x00-\x08|\x0b-\x0c|\x0e-\x1f]", "");
        }

        public static bool ChangeXmlCacheConfig(String key)
        {
            bool isSuc = false;
            try
            {
                string xmlPath = HttpContext.Current.Server.MapPath(string.Format(@"~/App_Data/{0}", key + ".xml"));
                XmlHelper xmlhelper = new XmlHelper(xmlPath);
                isSuc = xmlhelper.UpdateNode(xmlPath, "/RunOptions/Version", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (isSuc)
                {
                    isSuc = xmlhelper.Save();
                    //TextLogger.ServiceLog("CacheRecord", string.Format("CHANGE CACHE CONFIG FOR {0} SUC:AT {1}", key, DateTimeConvertor.LongStrYearMonthDayHourMinuteSecond));
                }
                return isSuc;
            }
            catch (Exception ex)
            {
                //TextLogger.ServiceLog("CacheRecord", string.Format("CHANGE CACHE CONFIG FOR {0} ERROR: {1} AT {2}", key, ex.Message, DateTimeConvertor.LongStrYearMonthDayHourMinuteSecond));
                return false;
            }
        }
    }

}
