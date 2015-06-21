using System;
using System.Collections;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;
using NHibernate.Mapping;
using JF.Common.Libary.JEncodeFunc;

namespace JF.Common.Libary.NHibernate
{
    public class SessionManagement
    {
        private Hashtable _Factorys = new Hashtable();
        private static SessionManagement instance;
        private static object objMonitor = new object();

        public static SessionManagement GetInstance()
        {
            if (instance == null)
            {
                Monitor.Enter(objMonitor);
                instance = new SessionManagement();
                Monitor.Exit(objMonitor);
            }
            return instance;
        }

        private SessionManagement()
        {
            try
            {
                string ConnectionName = "connection.connection_string";
                System.Configuration.ConnectionStringSettingsCollection configs = System.Configuration.ConfigurationManager.ConnectionStrings;
                List<string> dblist = new List<string>(Enum.GetNames(typeof(JDB.Database)));
                for (int i = 0; i < configs.Count; i++)
                {
                    if (dblist.Contains(configs[i].Name))
                    {
                        string ConnectionValue = System.Configuration.ConfigurationManager.ConnectionStrings[configs[i].Name].ToString();
                        foreach (var item in ConnectionValue.Split(';'))
                        {
                           if( item.StartsWith("PWD=") || item.StartsWith("UID="))
                           {
                               ConnectionValue = ConnectionValue.Replace(item.Substring(4), EncodeAndDecodeHelper.PasswordDecryption(item.Substring(4)));
                           }
                        }
                        Configuration config = new Configuration();
                        config.SetProperty(ConnectionName, ConnectionValue);
                        config.Configure();
                        _Factorys.Add(configs[i].Name, config.BuildSessionFactory());
                    }
                }
            }
            catch (HibernateConfigException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ISession GetSession(string key)
        {
            return ((ISessionFactory)_Factorys[key]).OpenSession();
        }

        public IStatelessSession GetStatelessSession(string key)
        {
            return ((ISessionFactory)_Factorys[key]).OpenStatelessSession();
        }
    }
}