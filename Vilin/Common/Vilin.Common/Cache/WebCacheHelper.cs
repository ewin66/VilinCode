/* 
 * Autor:wanghao
 * Date :2009-12-27
 * Description: Chche基类 这里使用webchche 
 */
using System;
using System.Text;
using System.Web;
using System.Collections;
using System.Web.Caching;
using System.Text.RegularExpressions;
namespace ComLib
{
    public class WebCacheHelper
    {
        private static readonly Cache _cache;
        public static readonly int DayFactor;
        private static int Factor;
        public static readonly int HourFactor;
        public static readonly int MinuteFactor;

        static WebCacheHelper()
        {
            DayFactor = 17280;
            HourFactor = 720;
            MinuteFactor = 12;
            Factor = 5;
            _cache = HttpRuntime.Cache;
        }

        private WebCacheHelper()
        {
        }

        public static void Clear()
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            while( enumerator.MoveNext() ) {
                _cache.Remove( enumerator.Key.ToString() );
            }
        }

        public static object Get( string key )
        {
            return _cache[key];
        }

        public static void Insert( string key, object obj )
        {
            Insert( key, obj, null, 1 );
        }

        public static void Insert( string key, object obj, int seconds )
        {
            Insert( key, obj, null, seconds );
        }

        /*************************************************************************************
         * CacheDependency
         * 在存储于 ASP.NET 应用程序的 Cache 对象中的项与文件、缓存键、文件或缓存键的数组
         * 或另一个 CacheDependency 对象之间建立依附性关系。CacheDependency 类监视依附性关系，
         * 以便在任何这些对象更改时，该缓存项都会自动移除。 
         *如需在文件改变时候加入事件 判断一下
         if (dep.HasChanged)
         Response.Write("<p>The dependency has changed.");  
         else Response.Write("<p>The dependency has not changed.");
         **************************************************************************************/
        public static void Insert( string key, object obj, CacheDependency dep )
        {
            Insert( key, obj, dep, HourFactor * 12 );
        }


        /*CacheItemPriority
         * 优先级枚举 */
        public static void Insert( string key, object obj, int seconds, CacheItemPriority priority )
        {
            Insert( key, obj, null, seconds, priority );
        }

        public static void Insert( string key, object obj, CacheDependency dep, int seconds )
        {
            Insert( key, obj, dep, seconds, CacheItemPriority.Normal );
        }

        public static void Insert( string key, object obj, CacheDependency dep, int seconds, CacheItemPriority priority )
        {
            if( obj != null ) {
                _cache.Insert( key, obj, dep, DateTime.Now.AddSeconds( (double)(Factor * seconds) ), TimeSpan.Zero, priority, null );
            }
        }

        public static void Max( string key, object obj )
        {
            Max( key, obj, null );
        }

        public static void Max( string key, object obj, CacheDependency dep )
        {
            if( obj != null ) {
                _cache.Insert( key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, null );
            }
        }

        public static void MicroInsert( string key, object obj, int secondFactor )
        {
            if( obj != null ) {
                _cache.Insert( key, obj, null, DateTime.Now.AddSeconds( (double)(Factor * secondFactor) ), TimeSpan.Zero );
            }
        }

        public static void Remove( string key )
        {
            _cache.Remove( key );
        }

        public static void RemoveByPattern( string pattern )
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            Regex regex1 = new Regex( pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase );
            while( enumerator.MoveNext() ) {
                if( regex1.IsMatch( enumerator.Key.ToString() ) ) {
                    _cache.Remove( enumerator.Key.ToString() );
                }
            }
        }

        public static void ReSetFactor( int cacheFactor )
        {
            Factor = cacheFactor;
        }

        /// <summary>
        /// SQL缓存依赖  用于SQL2000数据库 sql2005不需要
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static SqlCacheDependency GetDependency( string ConnectionString_SQL2000, string table )
        {
            SqlCacheDependencyAdmin.EnableNotifications( ConnectionString_SQL2000 );     //启动数据库的数据缓存依赖功能                    
            SqlCacheDependencyAdmin.EnableTableForNotifications( ConnectionString_SQL2000, table );        //启用数据表缓存
            SqlCacheDependency dependency = new SqlCacheDependency(
                new System.Data.SqlClient.SqlConnectionStringBuilder(
                    ConnectionString_SQL2000
                    ).InitialCatalog, table );
            return dependency;
        }
        #region "SQL2K缓存依赖列子"
         //public static void ReadSettings()
        //{
        //    Hashtable htSettings = BlogsaCore.BaseWebCache.Get("Blogsa.Settings") as Hashtable;
        //    if (htSettings != null)
        //    {
        //        Blogsa.Settings = htSettings;
        //        GetLanguages((string)Settings["language"]);
        //        return;
        //    }

        //    Blogsa.Settings = new Hashtable();
        //    Blogsa.Settings.Clear();
        //    SettingsCollection _settingCoollection = new SettingsCollection();
        //    if (_settingCoollection.GetMulti(null))
        //    {
        //        foreach (SettingsEntity Item in _settingCoollection)
        //            if (!Settings.ContainsKey(Item.Name.ToString()))
        //                Settings.Add(Item.Name.ToString(), Item.Value.ToString());

        //        //建立Fro SQL2K数据库缓存依赖
        //        BlogsaCore.BaseWebCache.Insert("Blogsa.Settings",
        //            Blogsa.Settings,
        //        BlogsaCore.BaseWebCache.GetDependency(
        //            ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString,
        //            ConfigurationManager.AppSettings["CacheTables"]));
        //    }
        //    else
        //    {
        //        throw new Exception("setting 表中不存在配置记录 ");
        //    }
        //}
        //Config配置
         //<appSettings>
        // <!--开启缓存用的表 用于SQL2000-->
        //<add key="CacheTables" value="Settings"/>
        //<system.web>
        //<!--开启缓存轮询 用于SQL2000  pollTime单位为毫秒 即1秒=1000毫秒-->
        //<caching>
        //    <sqlCacheDependency enabled="true" pollTime="30000">
        //        <databases>
        //            <add name="OpenOurHeart" connectionStringName="Main.ConnectionString"/>
        //        </databases>
        //    </sqlCacheDependency>
        //</caching>
        #endregion

        #region "文件依赖例子"
    //     public static StringDictionary GetLanguageDictionary(string strFile)
    //{
    //    string TempKey = strFile;
    //    object fileCache = BaseWebCache.Get( TempKey );
    //    if( fileCache != null ) return fileCache as StringDictionary;
        
    //    StringDictionary SD = new StringDictionary();
    //    try
    //    {
    //        DataSet DS = new DataSet();
    //        strFile = HttpContext.Current.Server.MapPath( "~/" + strFile );
    //        DS.ReadXml( strFile );
    //        foreach (DataRow Dr in DS.Tables["word"].Rows)
    //        {
    //            string strKeyword = Dr["Keyword"].ToString();
    //            string strTranslate = Dr["Translate"].ToString();
    //            strTranslate = strTranslate == "!" ? Dr["word_Text"].ToString() : strTranslate;
    //            SD.Add(strKeyword, strTranslate);
    //        }
    //        DS.Dispose();
    //        BaseWebCache.Insert( TempKey, SD, new CacheDependency( strFile ) );
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception( ex.Message );
    //    }
        
    //    return SD;
    //}
        #endregion
    } 

}
