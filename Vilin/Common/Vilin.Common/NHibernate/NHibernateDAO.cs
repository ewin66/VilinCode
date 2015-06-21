using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using JF.Common.Libary.JEnum;
using NHibernate;
using NHibernate.Criterion;

using Hib = NHibernate;
using JF.Common.Libary.DataAccess;
using JF.Common.Libary.JLogHelper;
using JF.Common.Libary.TimeFunc;

namespace JF.Common.Libary.NHibernate
{
    //public class NHibernateDAO<T> : BaseDAO, ICommonDAO<T>
    //{
    //    public NHibernateDAO(ISession session)
    //        : base(session)
    //    {
    //    }

    //    #region ICommonDAO<T> Members

    //    public int Insert(T objectInfo)
    //    {
    //        int id = (int)_Session.Save(objectInfo);
    //        return id;
    //    }

    //    public bool Insert(List<T> objectInfo)
    //    {
    //        bool result = false;
    //        using (ITransaction ts = _Session.BeginTransaction())
    //        {
    //            try
    //            {
    //                foreach (T objectInfoSub in objectInfo)
    //                {
    //                    _Session.Save(objectInfoSub);
    //                }
    //                ts.Commit();
    //                result = true;
    //            }
    //            catch (HibernateException ex)
    //            {
    //                ts.Rollback();
    //                result = false;
    //                throw ex;
    //            }
    //            finally
    //            {
    //                if (_Session != null && _Session.IsOpen)
    //                    _Session.Close();
    //            }
    //        }
    //        return result;
    //    }

    //    public bool Update(T objectInfo)
    //    {
    //        _Session.Update(objectInfo);
    //        return true;
    //    }

    //    public bool Delete(T objectInfo)
    //    {
    //        _Session.Delete(objectInfo);
    //        return true;
    //    }

    //    public bool Delete(List<T> objectInfo)
    //    {
    //        bool result = false;
    //        using (ITransaction ts = _Session.BeginTransaction())
    //        {
    //            try
    //            {
    //                foreach (T objectInfoSub in objectInfo)
    //                {
    //                    _Session.Delete(objectInfoSub);
    //                }
    //                ts.Commit();
    //                result = true;
    //            }
    //            catch (HibernateException ex)
    //            {
    //                ts.Rollback();
    //                result = false;
    //                throw ex;
    //            }
    //            finally
    //            {
    //                if (_Session != null && _Session.IsOpen)
    //                    _Session.Close();
    //            }
    //        }
    //        return result;
    //    }

    //    public T GetByID(object id)
    //    {
    //        try
    //        {
    //            OpenConnect();
    //            T objectInfo = _Session.Get<T>(id);
    //            return objectInfo;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            Disconnect();
    //        }
    //    }

    //    public IList<T> GetAll()
    //    {
    //        try
    //        {
    //            OpenConnect();
    //            string strHQL = string.Format(" From {0}", typeof(T).Name);
    //            IList<T> objectInfo = _Session.CreateQuery(strHQL).List<T>();
    //            return objectInfo;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            Disconnect();
    //        }
    //    }

    //    public IList<T> Search(T objectInfo)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IList<T> Search(string keywords)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IList<T> Execute(string storageProcess)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    #endregion ICommonDAO<T> Members
    //}

    /// <summary>
    /// the interface for dao layer.
    /// </summary>
    public interface IPersistentDAO
    {
        void Update(object data);

        /// <summary>
        /// Saves the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Add(object data);

        /// <summary>
        /// Deletes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        void Delete(object data);

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        void Flush();

        /// <summary>
        /// Begins the tran.
        /// </summary>
        /// <returns></returns>
        Hib.ITransaction BeginTransaction();

        /// <summary>
        /// Closes the session.
        /// </summary>
        void CloseSession();
    }

    /// <summary>
    /// the base database access class,u need implement this class in your DAO
    /// </summary>
    public abstract class NHibernateDAO : IPersistentDAO, IDisposable
    {
        protected ISession _Session;
        private IDbConnection _connection = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateDAO"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public NHibernateDAO(ISession session)
        {
            _Session = session;
            EnumHelper<SysEnum>.GetEnumInfoList();
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        /// <value>The session.</value>
        public ISession Session
        {
            get
            {
                return _Session;
            }
        }

        /// <summary>
        ///  Disconnect the ISession from the current ADO.NET connection.
        /// </summary>
        /// <remarks>
        ///  If the connection was obtained by Hibernate, close it or return it to the
        ///     connection pool. Otherwise return it to the application. This is used by
        ///     applications which require long transactions.
        /// </remarks>
        public void Disconnect()
        {
            if (!Session.Transaction.IsActive)
            {
                if (Session.IsConnected)
                {
                    _connection = Session.Disconnect();//testing.....
                }
            }
        }

        /// <summary>
        ///  Obtain a new ADO.NET connection.
        /// </summary>
        public void OpenConnect()
        {
            if (!Session.Transaction.IsActive)
            {
                if (!Session.IsConnected)
                {
                    //testing.....
                    if (!Session.IsOpen) _Session = _Session.SessionFactory.OpenSession();
                    else
                    {
                        if (_connection != null)
                            Session.Reconnect(_connection);
                        else
                            Session.Reconnect();
                    }
                }
            }
        }

        /// <summary>
        /// Logs the exepttion.
        /// </summary>
        /// <param name="ex">The exeption.</param>
        public void LogExepttion(Exception ex)
        {
            TextLogger.ServiceLog("ErroRecord", string.Format("{0} AT {1}", ex.Message, DateTimeConvertor.LongStrYearMonthDayHourMinuteSecond));
        }

        /// <summary>
        /// Gets the entity by id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id">The id.</param>
        /// <returns></returns>
        public T GetById<T>(object Id)
        {
            if (Id == null) return default(T);
            try
            {
                OpenConnect();
                return _Session.Get<T>(Id);
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                return default(T);
            }
            finally
            {
                Disconnect();
            }
        }

        protected int GetRowCount<T>(Conjunction con)
        {
            try
            {
                OpenConnect();
                ICriteria cri = Session.CreateCriteria(typeof(T));
                cri.Add(con);
                cri.SetProjection(Projections.RowCount());
                return cri.UniqueResult<int>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        public IList<T> QueryByPage<T>(Conjunction con, int pageSize, int startIndex, params Order[] orders)
        {
            try
            {
                OpenConnect();
                ICriteria cri = Session.CreateCriteria(typeof(T));
                cri.Add(con);
                if (orders != null)
                {
                    foreach (Order or in orders)
                    {
                        cri.AddOrder(or);
                    }
                }
                cri.SetFirstResult(startIndex);
                cri.SetMaxResults(pageSize);
                IList<T> list = cri.List<T>();
                return list;
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        ///<summary>
        /// 获取分页记录,并返回某个字段的SUM值
        ///</summary>
        public IList<T> FindByPage<T>(int currentPage, int pageSize, out int recordCount, ICriteria criteria)
        {
            try
            {
                OpenConnect();
                //利用投影得到总记录数
                var criteriaCount = CriteriaTransformer.Clone(criteria);
                criteriaCount.Orders.Clear();//清除Order
                recordCount = criteriaCount.SetProjection(Projections.RowCount()).UniqueResult<int>();
                return criteria.SetFirstResult((currentPage - 1) * pageSize)
                        .SetMaxResults(pageSize)
                        .List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        ///<summary>
        /// 获取分页记录,并返回某个字段的SUM值
        ///</summary>
        public IList<T> FindByPage<T>(int currentPage, int pageSize, out int recordCount, out decimal totalAmount, string sumKeyName, ICriteria criteria)
        {
            try
            {
                OpenConnect();
                //利用投影得到总记录数
                var criteriaCount = CriteriaTransformer.Clone(criteria);
                //清除Order
                criteriaCount.Orders.Clear();
                recordCount = criteriaCount.SetProjection(Projections.RowCount()).UniqueResult<int>();
                if (!string.IsNullOrEmpty(sumKeyName))
                {
                    var criteriaSum = CriteriaTransformer.Clone(criteria);
                    criteriaSum.Orders.Clear();
                    totalAmount = criteriaSum.SetProjection(Projections.Sum(sumKeyName)).UniqueResult<decimal>();
                }
                else
                {
                    totalAmount = 0;
                }
                return criteria.SetFirstResult((currentPage - 1) * pageSize)
                        .SetMaxResults(pageSize)
                        .List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        /// <summary>
        /// Get all models.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orders">The order parameters,it is optional</param>
        /// <returns></returns>
        public IList<T> GetAll<T>(params Hib.Criterion.Order[] orders)
        {
            try
            {
                OpenConnect();
                return GetList<T>(null as Hib.Criterion.ICriterion, orders);
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        /// <summary>
        /// Gets the entity list from respersitory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions">The criterion expressions,for example:new ICriterion[]{Restriction.Eq("AField","xy")}.</param>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IList<T> GetList<T>(Hib.Criterion.ICriterion expression, params Hib.Criterion.Order[] orders)
        {
            try
            {
                OpenConnect();
                Hib.ICriteria criteria = _Session.CreateCriteria(typeof(T));
                if (expression != null)
                    criteria.Add(expression);

                foreach (Hib.Criterion.Order o in orders)
                {
                    criteria.AddOrder(o);
                }
                return criteria.List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }
        /// <summary>
        /// Gets the entity list from respersitory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions">The criterion expressions,for example:new ICriterion[]{Restriction.Eq("AField","xy")}.</param>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IList<T> GetList<T>(ICriteria criteria)
        {
            try
            {
                OpenConnect();
                return criteria.List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }



        /// <summary>
        /// Gets the entity list from respersitory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions">The criterion expressions,for example:new ICriterion[]{Restriction.Eq("AField","xy")}.</param>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IList<T> GetList<T>(Hib.Criterion.ICriterion[] expressions, params Hib.Criterion.Order[] orders)
        {
            try
            {
                OpenConnect();
                Hib.ICriteria criteria = _Session.CreateCriteria(typeof(T));
                if (expressions != null)
                    foreach (Hib.Criterion.ICriterion exp in expressions)
                    {
                        criteria.Add(exp);
                    }
                foreach (Hib.Criterion.Order o in orders)
                {
                    criteria.AddOrder(o);
                }
                return criteria.List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Gets the entity list from respersitory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions">The criterion expressions,for example:new ICriterion[]{Restriction.Eq("AField","xy")}.</param>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IList<T> GetList<T>(Hib.Criterion.ICriterion expressions, string associatePath, string alias, params Hib.Criterion.Order[] orders)
        {
            try
            {
                OpenConnect();
                Hib.ICriteria criteria = _Session.CreateCriteria(typeof(T));
                criteria.CreateAlias(associatePath, alias);
                if (expressions != null)
                    criteria.Add(expressions);

                foreach (Hib.Criterion.Order o in orders)
                {
                    criteria.AddOrder(o);
                }
                return criteria.List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Gets the entity list  from respersitory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hQuery">The hibernate query string.</param>
        /// <param name="paras">The parameters in the query string,a dictionary,its key represent the parameter name,and its value is the parameter value.</param>
        /// <returns></returns>
        public IList<T> GetList<T>(string hQuery, Dictionary<string, object> paras)
        {
            try
            {
                OpenConnect();
                Hib.IQuery query = _Session.CreateQuery(hQuery);
                if (paras != null)
                    foreach (string key in paras.Keys)
                    {
                        query.SetParameter(key, paras[key]);
                    }
                return query.List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Gets the entity list from respersitory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions">The criterion expressions,for example:new ICriterion[]{Restriction.Eq("AField","xy")}.</param>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IList<T> GetList<T>(Hib.Criterion.ICriterion[] expressions, string associatePath, string alias, params Hib.Criterion.Order[] orders)
        {
            try
            {
                OpenConnect();
                Hib.ICriteria criteria = _Session.CreateCriteria(typeof(T));
                criteria.CreateAlias(associatePath, alias);
                if (expressions != null)
                    foreach (Hib.Criterion.ICriterion exp in expressions)
                    {
                        criteria.Add(exp);
                    }
                foreach (Hib.Criterion.Order o in orders)
                {
                    criteria.AddOrder(o);
                }
                return criteria.List<T>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Gets the distict list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="distictPropertys">The distict propertys.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IList<object[]> GetDistinctList<T>(string[] distictPropertys, Hib.Criterion.ICriterion[] expressions, params Hib.Criterion.Order[] orders)
        {
            try
            {
                OpenConnect();
                Hib.ICriteria criteria = _Session.CreateCriteria(typeof(T));
                if (distictPropertys != null)
                {
                    ProjectionList projects = Projections.ProjectionList();
                    foreach (string p in distictPropertys)
                    {
                        projects.Add(Projections.Property(p));
                    }
                    criteria.SetProjection(Projections.Distinct(projects));
                }
                else throw new Exception("the disctinct property can't be null.");
                if (expressions != null)
                    foreach (Hib.Criterion.ICriterion exp in expressions)
                    {
                        criteria.Add(exp);
                    }
                foreach (Hib.Criterion.Order o in orders)
                {
                    criteria.AddOrder(o);
                }
                return criteria.List<object[]>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Gets the distict list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="distictPropertys">The distict propertys.</param>
        /// <param name="expressions">The expressions.</param>
        /// <param name="orders">The orders.</param>
        /// <returns></returns>
        public IList<valT> GetDistinctList<T, valT>(string[] distictPropertys, Hib.Criterion.ICriterion expressions, params Hib.Criterion.Order[] orders)
        {
            try
            {
                OpenConnect();
                Hib.ICriteria criteria = _Session.CreateCriteria(typeof(T));
                if (distictPropertys != null)
                {
                    ProjectionList projects = Projections.ProjectionList();
                    foreach (string p in distictPropertys)
                    {
                        projects.Add(Projections.Property(p));
                    }
                    criteria.SetProjection(Projections.Distinct(projects));
                }
                else throw new Exception("the disctinct property can't be null.");
                if (expressions != null)
                    criteria.Add(expressions);

                foreach (Hib.Criterion.Order o in orders)
                {
                    criteria.AddOrder(o);
                }
                return criteria.List<valT>();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                Disconnect();
            }
        }

        /// <summary>
        /// Executes the data table.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="paras">The paras.</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, Dictionary<string, object> paras)
        {
            try
            {
                OpenConnect();
                IDbCommand command = _Session.Connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = commandType;
                if (_Session.Transaction.IsActive)
                    _Session.Transaction.Enlist(command);
                SetParameter(command, paras);
                using (IDataReader reader = command.ExecuteReader())
                {
                    DataTable result = new DataTable();
                    DataTable schemaTable = reader.GetSchemaTable();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        result.Columns.Add(schemaTable.Rows[i][0].ToString(), (Type)schemaTable.Rows[i]["DataType"]);
                    }
                    while (reader.Read())
                    {
                        int fieldCount = reader.FieldCount;
                        object[] values = new Object[fieldCount];
                        for (int i = 0; i < fieldCount; i++)
                        {
                            values[i] = reader.GetValue(i);
                        }
                        result.Rows.Add(values);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public DataSet ExecuteDataSet(string sql, CommandType commandType, Dictionary<string, object> paras)
        {
            try
            {
                DataSet dt = new DataSet();
                OpenConnect();
                IDbCommand command = _Session.Connection.CreateCommand();
                command.CommandText = sql;
                command.CommandType = commandType;
                if (_Session.Transaction.IsActive)
                    _Session.Transaction.Enlist(command);
                SetParameter(command, paras);
                int counter = 1;
                using (IDataReader reader = command.ExecuteReader())
                {
                    do
                    {
                        DataTable result = new DataTable();
                        DataTable schemaTable = reader.GetSchemaTable();
                        for (int i = 0; i < schemaTable.Rows.Count; i++)
                        {
                            result.Columns.Add(schemaTable.Rows[i][0].ToString(), (Type)schemaTable.Rows[i]["DataType"]);
                        }
                        while (reader.Read())
                        {
                            int fieldCount = reader.FieldCount;
                            object[] values = new Object[fieldCount];
                            for (int i = 0; i < fieldCount; i++)
                            {
                                values[i] = reader.GetValue(i);
                            }
                            result.Rows.Add(values);
                        }
                        result.TableName = "Table" + counter.ToString();
                        dt.Tables.Add(result);
                        counter++;
                    }
                    while (reader.NextResult());
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Disconnect();
            }
        }

        public object ExecuteScalar(string sql, CommandType commandType, Dictionary<string, object> paras, bool keepSession)
        {
            try
            {
                OpenConnect();
                IDbCommand command = _Session.Connection.CreateCommand();
                //Jeffrey
                command.CommandTimeout = 600;

                command.CommandText = sql;
                command.CommandType = commandType;
                if (_Session.Transaction.IsActive)
                    _Session.Transaction.Enlist(command);
                SetParameter(command, paras);
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                if (!keepSession)
                {
                    Disconnect();
                }
            }
        }

        public int ExecuteNonQuery(string sql, CommandType commandType, Dictionary<string, object> paras, bool keepSession)
        {
            try
            {
                OpenConnect();
                IDbCommand command = _Session.Connection.CreateCommand();
                //Jeffrey
                command.CommandTimeout = 600;

                command.CommandText = sql;
                command.CommandType = commandType;
                if (_Session.Transaction.IsActive)
                    _Session.Transaction.Enlist(command);
                SetParameter(command, paras);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                throw;
            }
            finally
            {
                if (!keepSession)
                {
                    Disconnect();
                }
            }
        }

        public IList<T> ExecuteStoredProcedure<T>(ISession session, string storedProcName, SqlParameter[] parameters, out int recordCount, bool keepSession) where T : new()
        {
            try
            {
                OpenConnect();
                DataTable dt = MsSqlHelper.ExecuteDataTable(session.Connection as SqlConnection, CommandType.StoredProcedure, storedProcName, parameters);
                IList<T> list = JF.Common.Libary.ModelFunc.ModelConvertHelper<T>.ToList(dt);
                if (list == null)
                {
                    recordCount = 0;
                    return null;
                }
                recordCount = list.Count;
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
             {
                if (!keepSession)
                {
                    Disconnect();
                }
            }
        }

        public bool ExecuteStoredProcedure(ISession session, string storedProcName, SqlParameter[] parameters, bool keepSession)
        {
            try
            {
                OpenConnect();
                MsSqlHelper.ExecuteDataTable(session.Connection as SqlConnection, CommandType.StoredProcedure, storedProcName, parameters);
                return true;
            }
            catch (Exception ex)
            {
                LogExepttion(ex);
                return false;
            }
            finally
            {
                if (!keepSession)
                {
                    Disconnect();
                }
            }
        }

        /// <summary>
        /// Sets the parameter.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="paras">The paras.</param>
        private void SetParameter(IDbCommand command, Dictionary<string, object> paras)
        {
            if (paras != null)
            {
                foreach (string key in paras.Keys)
                {
                    IDataParameter pa = command.CreateParameter();
                    pa.ParameterName = key;
                    pa.Value = paras[key];
                    command.Parameters.Add(pa);
                }
            }
        }

        #region IPersistentDAO Members

        /// <summary>
        /// Saves   or update the given instance,depend on the identity property.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Update(object data)
        {
            OpenConnect();
            _Session.Merge(data);
        }

        /// <summary>
        /// Saves the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Add(object data)
        {
            OpenConnect();
            _Session.Save(data);
        }

        /// <summary>
        /// insert obj by batch
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectInfo"></param>
        /// <returns></returns>
        public bool Insert<T>(List<T> objectInfo)
        {
            bool result = false;
            using (ITransaction ts = this.BeginTransaction())
            {
                try
                {
                    foreach (T objectInfoSub in objectInfo)
                    {
                        this._Session.Save(objectInfoSub);
                    }
                    ts.Commit();
                    result = true;
                }
                catch (HibernateException ex)
                {
                    ts.Rollback();
                    result = false;
                    throw ex;
                }
                finally
                {
                    Disconnect();
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Delete(object data)
        {
            OpenConnect();
            _Session.Delete(data);
        }

        /// <summary>
        /// delete obj by batch
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectInfo"></param>
        /// <returns></returns>
        public bool Delete<T>(List<T> objectInfo)
        {
            bool result = false;
            using (ITransaction ts = this.BeginTransaction())
            {
                try
                {
                    foreach (T objectInfoSub in objectInfo)
                    {
                        this._Session.Delete(objectInfoSub);
                    }
                    ts.Commit();
                    result = true;
                }
                catch (HibernateException ex)
                {
                    ts.Rollback();
                    result = false;
                    throw ex;
                }
                finally
                {
                    Disconnect();
                }
            }
            return result;
        }

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        public void Flush()
        {
            OpenConnect();
            if (_Session != null) _Session.Flush();
        }

        /// <summary>
        /// Begins the tran.
        /// </summary>
        /// <returns></returns>
        public ITransaction BeginTransaction()
        {
            OpenConnect();
            if (_Session.Transaction.IsActive)
            {
                return _Session.Transaction;
            }
            else
            {
                return _Session.BeginTransaction();
            }
        }

        /// <summary>
        /// Commit the tran.
        /// </summary>
        /// <returns></returns>
        public void Commit()
        {
            if (_Session.Transaction.IsActive && !_Session.Transaction.WasCommitted)
            {
                _Session.Transaction.Commit();
            }
        }

        /// <summary>
        /// Rollback the tran.
        /// </summary>
        /// <returns></returns>
        public void RollbackTransaction()
        {
            if (_Session.Transaction.IsActive && !_Session.Transaction.WasRolledBack)
            {
                _Session.Transaction.Rollback();
            }
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            OpenConnect();
            return _Session.BeginTransaction(isolationLevel);
        }

        public ITransaction Transaction
        {
            get
            {
                return _Session.Transaction;
            }
        }

        public FlushMode FlushMode
        {
            get
            {
                return _Session.FlushMode;
            }
            set
            {
                _Session.FlushMode = value;
            }
        }

        /// <summary>
        /// Closes the session.
        /// </summary>
        public void CloseSession()
        {
            Disconnect();
        }

        #endregion IPersistentDAO Members

        ~NHibernateDAO()
        {
            Dispose();
        }

        #region IDisposable Members

        public void Dispose()
        {
            //if (_Session != null)
            //CloseSession();
            _Session = null;
        }

        #endregion IDisposable Members
    }
}