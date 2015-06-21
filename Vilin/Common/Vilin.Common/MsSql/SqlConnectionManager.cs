using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JF.Common.Libary.DataAccess
{
    /// <summary>
    /// Summary description for SqlConnectionManager.
    /// </summary>
    public sealed class SqlConnectionManager
    {
        private static string connString = null;

        private static Hashtable _ColumnTypeCache = new Hashtable();

        private static readonly int MAX_REC = 10000000;

        public static SqlConnection getConnection()
        {
            if (connString == null)
                connString = ConfigurationManager.AppSettings["ConnectionString"].ToString();

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();

                return conn;
            }
            catch (InvalidOperationException e)
            {
                throw new DataAccessException(e.Message, e);
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }
        }

        //
        // 执行一条非查询的 SQL 语句, 如果查询失败抛出异常.
        // 返回受到影响的行数.
        //
        public static int ExecuteNonQuery(string commandText)
        {
            int affectedRows;
            SqlConnection conn = null;

            try
            {
                conn = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                affectedRows = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }

            return affectedRows;
        }

        //
        // 执行一条非查询的 SQL 语句, 如果查询失败抛出异常.
        // 返回受到影响的行数.
        //
        public static int ExecuteNonQuery(SqlConnection conn, SqlTransaction transaction, string commandText)
        {
            int affectedRows;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                affectedRows = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }

            return affectedRows;
        }

        //
        // 执行一条查询的 SQL 语句, 如果查询失败抛出异常.
        // 返回查询结果 DataSet.
        //
        public static DataSet ExecuteQuery(string commandText, string tableName)
        {
            DataSet dataSet = new DataSet();
            SqlConnection conn = null;

            try
            {
                conn = getConnection();

                SqlDataAdapter sda = new SqlDataAdapter(commandText, conn);
                sda.Fill(dataSet, tableName);
                sda.Dispose();
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return dataSet;
        }

        //
        // 执行一条查询的 SQL 语句, 如果查询失败抛出异常.
        // 返回查询结果 DataSet.
        //
        public static DataSet ExecuteQuery(SqlConnection conn, SqlTransaction transaction, string commandText,
                                           string tableName)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(commandText, conn);
                sda.SelectCommand.Transaction = transaction;
                sda.Fill(dataSet, tableName);
                sda.Dispose();
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }

            return dataSet;
        }

        public static DataTable ExecuteQuery(string commandText)
        {
            return ExecuteQuery(commandText, MAX_REC);
        }

        public static DataTable ExecuteQuery(string commandText, int maxRec)
        {
            SqlConnection conn = null;

            try
            {
                conn = getConnection();
                ExecuteNonQuery(conn, ("SET ROWCOUNT " + maxRec));

                DataTable table = new DataTable();

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }

                ExecuteNonQuery(conn, ("SET ROWCOUNT 0"));
                return table;
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public static DataTable ExecuteQuery(SqlConnection conn, SqlTransaction transaction, string commandText)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.SelectCommand.Transaction = transaction;

                DataTable table = new DataTable();
                adapter.Fill(table);

                adapter.Dispose();
                cmd.Dispose();

                return table;
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }
        }

        private static void ToUpper(SqlCommand command)
        {
            if (command != null)
            {
                command.CommandText = command.CommandText.ToUpper();

                if (command.Parameters != null)
                {
                    foreach (SqlParameter parameter in command.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.ToUpper();
                    }
                }
            }
        }

        public static DataTable ExecuteQuery(SqlCommand command)
        {
            return ExecuteQuery(command, MAX_REC);
        }

        public static DataTable ExecuteQuery(SqlTransaction transaction, SqlCommand command)
        {
            DataTable table = new DataTable();

            try
            {
                command.Connection = transaction.Connection;
                command.Transaction = transaction;

                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                }

                return table;
            }
            catch (Exception e)
            {
                throw new DataAccessException(e.Message, e);
            }
        }

        private static DataTable ExecuteQuery(SqlCommand command, int maxRec)
        {
            SqlConnection conn = null;
            DataTable table = new DataTable();

            try
            {
                conn = getConnection();

                ExecuteNonQuery(conn, ("SET ROWCOUNT " + maxRec));

                command.Connection = conn;
                ToUpper(command);
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                }

                ExecuteNonQuery(conn, ("SET ROWCOUNT 0"));
                return table;
            }
            catch (Exception e)
            {
                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public static int ExecuteNonQuery(SqlCommand command)
        {
            int affectedRows;
            SqlConnection conn = null;

            try
            {
                conn = getConnection();
                command.Connection = conn;
                ToUpper(command);

                affectedRows = command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception e)
            {
                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return affectedRows;
        }

        public static int ExecuteNonQuery(SqlConnection conn, SqlTransaction transaction, SqlCommand command)
        {
            int affectedRows;

            try
            {
                command.Connection = conn;
                command.Transaction = transaction;
                ToUpper(command);
                affectedRows = command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception e)
            {
                throw new DataAccessException(e.Message, e);
            }

            return affectedRows;
        }

        public static void BatchExecuteNonQuery(SqlCommand[] commands)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;

            try
            {
                conn = getConnection();
                transaction = conn.BeginTransaction();

                foreach (SqlCommand command in commands)
                {
                    ToUpper(command);
                    int affectedRows = ExecuteNonQuery(conn, transaction, command);
                    if (affectedRows == 0)
                        throw new DataException("Update failed: The value of affectedRows is 0, commandText is \"" +
                                                command.CommandText + "\".");
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                if (transaction != null)
                    transaction.Rollback();

                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public static object ExecuteScalar(SqlCommand command)
        {
            SqlConnection conn = null;

            try
            {
                conn = getConnection();
                command.Connection = conn;
                ToUpper(command);
                Object returnObj = command.ExecuteScalar();
                command.Dispose();

                return returnObj;
            }
            catch (Exception e)
            {
                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        public static object ExecuteScalar(SqlConnection conn, SqlTransaction transaction, SqlCommand command)
        {
            try
            {
                command.Connection = conn;
                command.Transaction = transaction;
                ToUpper(command);
                Object returnObj = command.ExecuteScalar();
                command.Dispose();

                return returnObj;
            }
            catch (Exception e)
            {
                throw new DataAccessException(e.Message, e);
            }
        }

        private static DbType StringToDbType(string dbTypeStr)
        {
            switch (dbTypeStr.ToLower())
            {
                case "varchar":
                case "char":
                    return DbType.String;
                case "bigint":
                case "int":
                    return DbType.Int32;
                case "bit":
                    return DbType.Int16;
                case "datetime":
                    return DbType.DateTime;
                case "decimal":
                    return DbType.Decimal;
                default:
                    return DbType.String;
            }
        }

        public static DbType GetColumnType(string tableName, string columnName)
        {
            if (tableName == null)
                tableName = "";

            if (columnName == null)
                columnName = "";

            tableName = tableName.Trim().ToUpper();
            columnName = columnName.Trim().ToUpper();

            string key = tableName + "." + columnName;

            if (_ColumnTypeCache.Contains(key))
            {
                return (DbType)_ColumnTypeCache[key];
            }
            else
            {
                string commandText =
                    "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=@TABLE_NAME";
                SqlCommand command = new SqlCommand(commandText);
                SqlParameter param = new SqlParameter("@TABLE_NAME", DbType.String);
                param.Value = tableName;
                command.Parameters.Add(param);

                DataTable dataTable = ExecuteQuery(command);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    _ColumnTypeCache.Add(
                        tableName.Trim().ToUpper() + "." + ((string)dataRow["COLUMN_NAME"]).ToUpper().Trim(),
                        StringToDbType((string)dataRow["DATA_TYPE"]));
                }

                dataTable.Dispose();
                return (DbType)_ColumnTypeCache[key];
            }
        }

        public static DataTable ExecuteQuerySP(string spName, IDictionary parameters)
        {
            return ExecuteQuerySP(spName, parameters, MAX_REC);
        }

        public static DataTable ExecuteQuerySP(string spName, IDictionary parameters, int maxRec)
        {
            SqlConnection conn;
            DataTable table = new DataTable();

            if (spName == null)
                throw new ArgumentNullException();

            if (spName.Trim().Length == 0)
                throw new ArgumentException();

            if (parameters == null)
                parameters = new Hashtable();

            IDictionary spParamsDef = RetrieveSPParameters(spName);
            IDictionary spParams = new Hashtable();

            foreach (DictionaryEntry paramDefEntry in spParamsDef)
            {
                string key = Convert.ToString(paramDefEntry.Key);
                if (key.StartsWith("@"))
                    key = key.Substring(1);

                foreach (DictionaryEntry paramEntry in parameters)
                {
                    if (Convert.ToString(paramEntry.Key).ToUpper().Equals(key.ToUpper()))
                    {
                        spParams.Add(paramDefEntry.Key, paramEntry.Value);
                        break;
                    }
                }
            }

            using (conn = getConnection())
            {
                ExecuteNonQuery(conn, ("SET ROWCOUNT " + maxRec));

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = spName;
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (DictionaryEntry entry in spParams)
                        command.Parameters.AddWithValue(entry.Key.ToString(), entry.Value);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }

                ExecuteNonQuery(conn, ("SET ROWCOUNT 0"));
                return table;
            }
        }

        //
        // 执行一条非查询的 SQL 语句, 如果查询失败抛出异常.
        // 返回受到影响的行数.
        //
        public static int ExecuteNonQuery(SqlConnection conn, string commandText)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = commandText;
                command.CommandType = CommandType.Text;
                return command.ExecuteNonQuery();
            }
        }

        public static IDictionary RetrieveSPParameters(string spName)
        {
            if (spName == null)
                throw new ArgumentNullException();

            if (spName.Trim().Length == 0)
                throw new ArgumentException();

            IDictionary parameters = new Hashtable();

            string cmdText = "select dbo.syscolumns.name as SP_NAME from dbo.syscolumns,dbo.sysobjects"
                             + " where dbo.syscolumns.id=dbo.sysobjects.id"
                             + " and dbo.sysobjects.xtype='P'"
                             + " and dbo.sysobjects.name=@spName";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@spName", spName);

            DataTable dt = ExecuteQuery(cmd);
            if (dt == null)
                return parameters;

            foreach (DataRow row in dt.Rows)
            {
                string parameterName = (row["SP_NAME"] != null) ? ((string)row["SP_NAME"]) : string.Empty;
                if (!parameters.Contains(parameterName))
                    parameters.Add(parameterName, string.Empty);
            }

            return parameters;
        }

        public static DataTable ExecuteQuery(string cmdText, IDictionary parameters)
        {
            SqlConnection conn = null;

            try
            {
                conn = getConnection();
                cmdText = cmdText.ToUpper();

                SqlCommand cmd = new SqlCommand(cmdText, conn);

                if (parameters != null && parameters.Count > 0)
                {
                    IDictionaryEnumerator enumerator = parameters.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        string name = "@" + enumerator.Key.ToString().ToUpper();
                        if (cmdText.IndexOf(name) > 0)
                        {
                            cmd.Parameters.AddWithValue(name, enumerator.Value);
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                adapter.Dispose();
                cmd.Dispose();

                return table;
            }
            catch (SqlException e)
            {
                throw new DataAccessException(e.Message, e);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
    }
}