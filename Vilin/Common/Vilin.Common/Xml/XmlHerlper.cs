/********************************************************************************** 
* 
* ����˵��:XML������� 
* ����: ����ѫ; 
* �汾:V0.1(C#2.0);ʱ��:2006-12-13 
* 
* *******************************************************************************/
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Vilin.Common
{
    /// <summary> 
    /// XML �������� 
    /// </summary> 
    public class XmlHerlper : IDisposable
    {

        public void EntyToXMLFile()
        {
            //var path = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\AlarmClock.xml";
            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Encoding = Encoding.UTF8;
            //settings.Indent = true;

            //using (XmlWriter writer = XmlWriter.Create(path, settings))
            //{
            //    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //    ns.Add("", "");
            //    XmlSerializer formatter = new XmlSerializer(typeof(List<AlarmClockModel>), new XmlRootAttribute("AlarmClocksModel"));
            //    formatter.Serialize(writer, list, ns);
            //}

        }

        /// <summary> 
        /// ����:��ȡXML��DataSet�� 
        /// </summary> 
        /// <param name="XmlPath">xml·��</param> 
        /// <returns>DataSet</returns> 
        public static DataSet GetXml( string XmlPath )
        {
            DataSet ds = new DataSet();
            ds.ReadXml( @XmlPath );
            return ds;
        }

        /// <summary> 
        /// ��ȡxml�ĵ�������һ���ڵ�:������һ���ڵ� 
        /// </summary> 
        /// <param name="XmlPath">xml·��</param> 
        /// <param name="NodeName">�ڵ�</param> 
        /// <returns></returns> 
        public static string ReadXmlReturnNode( string XmlPath, string Node )
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load( @XmlPath );
            XmlNodeList xn = docXml.GetElementsByTagName( Node );
            if(xn.Count>0){
            return xn.Item( 0 ).InnerText.ToString();
            }
            else
            {
             return "";
            }
        }

        /// <summary> 
        /// ��������,���ص�ǰ�ڵ�������¼��ڵ�,��䵽һ��DataSet�� 
        /// </summary> 
        /// <param name="xmlPath">xml�ĵ�·��</param> 
        /// <param name="XmlPathNode">�ڵ��·��:���ڵ�/���ڵ�/��ǰ�ڵ�</param> 
        /// <returns></returns> 
        public static DataSet GetXmlData( string xmlPath, string XmlPathNode )
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load( xmlPath );
            DataSet ds = new DataSet();
            StringReader read = new StringReader( objXmlDoc.SelectSingleNode( XmlPathNode ).OuterXml );
            ds.ReadXml( read );
            return ds;
        }
        /// <summary> 
        /// ����Xml�ڵ����� 
        /// </summary> 
        /// <param name="xmlPath">xml·��</param> 
        /// <param name="Node">Ҫ�������ݵĽڵ�:�ڵ�·�� ���ڵ�/���ڵ�/��ǰ�ڵ�</param> 
        /// <param name="Content">�µ�����</param> 
        public static void XmlNodeReplace( string xmlPath, string Node, string Content )
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load( xmlPath );
            objXmlDoc.SelectSingleNode( Node ).InnerText = Content;
            objXmlDoc.Save( xmlPath );
        }

        /// <summary> 
        /// ɾ��XML�ڵ�ʹ˽ڵ��µ��ӽڵ� 
        /// </summary> 
        /// <param name="xmlPath">xml�ĵ�·��</param> 
        /// <param name="Node">�ڵ�·��</param> 
        public static void XmlNodeDelete( string xmlPath, string Node )
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load( xmlPath );
            string mainNode = Node.Substring( 0, Node.LastIndexOf( "/" ) );
            objXmlDoc.SelectSingleNode( mainNode ).RemoveChild( objXmlDoc.SelectSingleNode( Node ) );
            objXmlDoc.Save( xmlPath );
        }

        /// <summary> 
        /// ����һ���ڵ�ʹ˽ڵ���ֽڵ� 
        /// </summary> 
        /// <param name="xmlPath">xml·��</param> 
        /// <param name="MailNode">��ǰ�ڵ�·��</param> 
        /// <param name="ChildNode">�²���ڵ�</param> 
        /// <param name="Element">����ڵ���ӽڵ�</param> 
        /// <param name="Content">�ӽڵ������</param> 
        public static void XmlInsertNode( string xmlPath, string MailNode, string ChildNode, string Element, string Content )
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load( xmlPath );
            XmlNode objRootNode = objXmlDoc.SelectSingleNode( MailNode );
            XmlElement objChildNode = objXmlDoc.CreateElement( ChildNode );
            objRootNode.AppendChild( objChildNode );
            XmlElement objElement = objXmlDoc.CreateElement( Element );
            objElement.InnerText = Content;
            objChildNode.AppendChild( objElement );
            objXmlDoc.Save( xmlPath );
        }

        /// <summary>
        /// ����һ���ڵ�ʹ˽ڵ�Ķ���ӽڵ� 
        /// </summary>
        /// <param name="xmlPath">xml·��</param> 
        /// <param name="MailNode">��ǰ�ڵ�·��</param> 
        /// <param name="ChildNode">�²���ڵ�</param> 
        /// <param name="ElementInfo">�ӽڵ���Ϣ</param>
        ///  <param name="TableName">���� ��Ϊ����</param>
        public static void XmlInsertNodeForTable( string xmlPath, string MailNode, string ChildNode, DataTable ElementInfo,string TableName )
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load( xmlPath );
            XmlNode objRootNode = objXmlDoc.SelectSingleNode( MailNode );

            
            for( int i = 0; i < ElementInfo.Rows.Count; i++ ) {
                XmlElement ObjNextChildNode = objXmlDoc.CreateElement( "FromInfo" );
                objRootNode.AppendChild( ObjNextChildNode );
                XmlElement objElement = objXmlDoc.CreateElement("TableName");
                objElement.InnerText = TableName;
                ObjNextChildNode.AppendChild( objElement );
                for( int Num = 0; Num < ElementInfo.Columns.Count; Num++ ) {

                    objElement = objXmlDoc.CreateElement( ElementInfo.Columns[Num].ColumnName );
                    objElement.InnerText = ElementInfo.Rows[i][ElementInfo.Columns[Num].ColumnName].ToString();

                    ObjNextChildNode.AppendChild( objElement );
                }
            }
            objXmlDoc.Save( xmlPath );
        }

        /// <summary> 
        /// ����һ�ڵ�,��һ���� 
        /// </summary> 
        /// <param name="xmlPath">Xml�ĵ�·��</param> 
        /// <param name="MainNode">��ǰ�ڵ�·��</param> 
        /// <param name="Element">�½ڵ�</param> 
        /// <param name="Attrib">��������</param> 
        /// <param name="AttribContent">����ֵ</param> 
        /// <param name="Content">�½ڵ�ֵ</param> 
        public static void XmlInsertElement( string xmlPath, string MainNode, string Element, string Attrib, string AttribContent, string Content )
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load( xmlPath );
            XmlNode objNode = objXmlDoc.SelectSingleNode( MainNode );
            XmlElement objElement = objXmlDoc.CreateElement( Element );
            objElement.SetAttribute( Attrib, AttribContent );
            objElement.InnerText = Content;
            objNode.AppendChild( objElement );
            objXmlDoc.Save( xmlPath );
        }

        public static void XmlInsertElement( string xmlPath, string MainNode, string Element, string Content )
        {
            XmlDocument objXmlDoc = new XmlDocument();
            objXmlDoc.Load( xmlPath );
            XmlNode objNode = objXmlDoc.SelectSingleNode( MainNode );
            XmlElement objElement = objXmlDoc.CreateElement( Element );
            objElement.InnerText = Content;
            objNode.AppendChild( objElement );
            objXmlDoc.Save( xmlPath );
        }

        //���봴���������ʹ�õ��� 
        private bool _alreadyDispose = false;
        private string xmlPath;
        private XmlDocument xmlDoc = new XmlDocument();
        private XmlNode xmlNode;
        private XmlElement xmlElem;

        #region �������͹�
        public XmlHerlper()
        {
        }
        ~XmlHerlper()
        {
            Dispose();
        }
        protected virtual void Dispose( bool isDisposing )
        {
            if( _alreadyDispose ) return;
            if( isDisposing ) {
                // 
            }
            _alreadyDispose = true;
        }
        #endregion
        #region IDisposable ��Ա
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
        #endregion
    }
}
