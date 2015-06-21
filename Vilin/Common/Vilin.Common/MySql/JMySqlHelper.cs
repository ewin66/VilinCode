using System;
using System.Collections.Generic;
using System.Data;
using JF.Common.Libary.MySQL;
using MySql.Data.MySqlClient;
using JF.Common.Libary.JDB;
using System.Configuration;

namespace JF.Common.Libary.MySQL
{
    public struct TransactionPararms
    {
        public string TPSqlString;
        public IEnumerable<MySqlParameter> MySqlParameters;
        public CommandType TPCommandType;
    }

    public delegate void ExecuteReaderDelegate(MySqlDataReader MySqlDataReader);

    public class JMySqlHelper : IDBHelper
    {
        private const int COMMANDTIMEOUT = 300;

        public readonly string connectString = string.Empty;

        public static readonly object _DBNull = (object)DBNull.Value;

        public JMySqlHelper(Database dbname)
        {
            connectString = ConfigurationManager.ConnectionStrings[dbname.ToString()].ConnectionString;
        }

        private static void CommandPrepare(MySqlConnection conn, MySqlTransaction sqltrans, MySqlCommand cmd, CommandType cmdType, string cmdText, IEnumerable<MySqlParameter> cmdParams)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (sqltrans != null)
                cmd.Transaction = sqltrans;

            if (cmdParams != null)
            {
                foreach (MySqlParameter parm in cmdParams)
                    cmd.Parameters.Add(parm);
            }
        }

        #region ExecuteDataSet

        public DataSet ExecuteDataSet(string TableName)
        {
            return ExecuteDataSet(TableName, CommandType.TableDirect, (MySqlParameter[])null);
        }

        public DataSet ExecuteDataSet(string sqlString, MySqlParameter MySqlParameters)
        {
            return ExecuteDataSet(sqlString, CommandType.Text, new MySqlParameter[] { MySqlParameters });
        }

        public DataSet ExecuteDataSet(string sqlString, IEnumerable<MySqlParameter> MySqlParameters)
        {
            return ExecuteDataSet(sqlString, CommandType.Text, MySqlParameters);
        }

        public DataSet ExecuteDataSet(String sqlString, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            if (!string.IsNullOrEmpty(sqlString))
                return CommandExecuteDataSet(connectString, sqlString, commandType, MySqlParameters);
            else
                throw new Exception("MySqlCommand Text is null");
        }

        public DataSet CommandExecuteDataSet(String connectString, String commandText, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            DataSet dsSet = new DataSet();
            using (MySqlConnection MySqlConnection = new MySqlConnection(connectString))
            {
                MySqlConnection.Open();
                try
                {
                    using (MySqlCommand MySqlCommand = new MySqlCommand())
                    {
                        try
                        {
                            CommandPrepare(MySqlConnection, null, MySqlCommand, commandType, commandText, MySqlParameters);
                            MySqlCommand.CommandTimeout = COMMANDTIMEOUT;
                            using (MySqlDataAdapter _da = new MySqlDataAdapter(MySqlCommand))
                            {
                                try
                                {
                                    _da.Fill(dsSet);
                                }
                                catch (MySqlException ex) { throw new Exception(ex.Message); }
                                finally { _da.Dispose(); }
                            }
                        }
                        catch (MySqlException ex) { throw new Exception(ex.Message); }
                        finally { MySqlCommand.Dispose(); }
                    }
                }
                catch (MySqlException ex) { throw new Exception(ex.Message); }
                finally
                {
                    if (MySqlConnection.State == ConnectionState.Open)
                        MySqlConnection.Close();
                    MySqlConnection.Dispose();
                }
                return dsSet;
            }
        }

        #endregion ExecuteDataSet

        #region ExecuteScalar

        public object ExecuteScalar(string sqlText)
        {
            return ExecuteScalar(sqlText, CommandType.Text, (MySqlParameter[])null);
        }

        public object ExecuteScalar(string sqlText, MySqlParameter MySqlParameter)
        {
            return ExecuteScalar(sqlText, CommandType.Text, new MySqlParameter[] { MySqlParameter });
        }

        public object ExecuteScalar(string sqlText, IEnumerable<MySqlParameter> MySqlParameter)
        {
            return ExecuteScalar(sqlText, CommandType.Text, MySqlParameter);
        }

        public object ExecuteScalar(string sqlText, CommandType commandType, MySqlParameter MySqlParameter)
        {
            return ExecuteScalar(sqlText, commandType, new MySqlParameter[] { MySqlParameter });
        }

        public object ExecuteScalar(string sqlText, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            if (!string.IsNullOrEmpty(sqlText))
                if (this.Transaction != null && this.Transaction.Transaction != null)
                {
                    MySqlTransaction sqlTrans = (MySqlTransaction)this.Transaction.Transaction;
                    return CommandExecuteScalar(sqlTrans.Connection, sqlTrans, sqlText, commandType, MySqlParameters);
                }
                else
                {
                    return CommandExecuteScalar(sqlText, commandType, MySqlParameters);
                }
            else
                throw new Exception("MySqlCommand Text is null");
        }

        public object CommandExecuteScalar(string sqlText, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            object result = null;
            using (MySqlConnection MySqlConnection = new MySqlConnection(connectString))
            {
                MySqlConnection.Open();
                try
                {
                    using (MySqlCommand MySqlCommand = new MySqlCommand(sqlText, MySqlConnection))
                    {
                        MySqlCommand.CommandType = commandType;
                        if (MySqlParameters != null)
                        {
                            foreach (MySqlParameter parameter in MySqlParameters)
                            {
                                MySqlCommand.Parameters.Add(parameter);
                            }
                        }
                        result = MySqlCommand.ExecuteScalar();
                    }
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    if (MySqlConnection.State == ConnectionState.Open)
                        MySqlConnection.Close();
                    MySqlConnection.Dispose();
                }
            }

            if ((Object.Equals(result, null)) || (Object.Equals(result, System.DBNull.Value)))
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        private static object CommandExecuteScalar(MySqlConnection MySqlConnection, MySqlTransaction MySqlTransaction, string sqlText, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            using (MySqlCommand MySqlCommand = new MySqlCommand(sqlText, MySqlConnection, MySqlTransaction))
            {
                MySqlCommand.CommandType = commandType;
                if (MySqlParameters != null)
                {
                    foreach (MySqlParameter parameter in MySqlParameters)
                    {
                        MySqlCommand.Parameters.Add(parameter);
                    }
                }
                return MySqlCommand.ExecuteScalar();
            }
        }

        #endregion ExecuteScalar

        #region ExecuteDataReader

        public void ExecuteReader(ExecuteReaderDelegate executeReaderDelegate, string sqlText)
        {
            ExecuteReader(executeReaderDelegate, sqlText, CommandType.Text, (MySqlParameter[])null);
        }

        public void ExecuteReader(ExecuteReaderDelegate executeReaderDelegate, string sqlText, MySqlParameter MySqlParameter)
        {
            ExecuteReader(executeReaderDelegate, sqlText, CommandType.Text, new MySqlParameter[] { MySqlParameter });
        }

        public void ExecuteReader(ExecuteReaderDelegate executeReaderDelegate, string sqlText, IEnumerable<MySqlParameter> MySqlParameters)
        {
            ExecuteReader(executeReaderDelegate, sqlText, CommandType.Text, MySqlParameters);
        }

        public void ExecuteReader(ExecuteReaderDelegate executeReaderDelegate, string sqlText, CommandType commandType, MySqlParameter MySqlParameter)
        {
            ExecuteReader(executeReaderDelegate, sqlText, commandType, new MySqlParameter[] { MySqlParameter });
        }

        public void ExecuteReader(ExecuteReaderDelegate executeReaderDelegate, string sqlText, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            if (!string.IsNullOrEmpty(sqlText))
                CommandExecuteReader(executeReaderDelegate, connectString,sqlText, commandType, MySqlParameters);
            else
                throw new Exception("MySqlCommand Text is null");
        }

        private static void CommandExecuteReader(ExecuteReaderDelegate executeReaderDelegate, string connectString, string sqlText, CommandType commaondType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            try
            {
                using (MySqlConnection mySqlconn = new MySqlConnection(connectString))
                {
                    mySqlconn.Open();
                    try
                    {
                        using (MySqlCommand MySqlCommand = new MySqlCommand(sqlText, mySqlconn))
                        {
                            try
                            {
                                MySqlCommand.CommandType = commaondType;
                                if (MySqlParameters != null)
                                {
                                    foreach (MySqlParameter parameter in MySqlParameters)
                                    {
                                        MySqlCommand.Parameters.Add(parameter);
                                    }
                                }
                                using (MySqlDataReader MySqlDataReader = MySqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
                                {
                                    try
                                    {
                                        if (executeReaderDelegate != null) executeReaderDelegate.Invoke(MySqlDataReader);
                                    }
                                    catch (Exception ex) { throw ex; }
                                    finally
                                    {
                                        MySqlDataReader.Close();
                                    }
                                }
                            }
                            catch (MySqlException ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (mySqlconn.State == ConnectionState.Open)
                            mySqlconn.Close();
                        mySqlconn.Dispose();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        #endregion ExecuteDataReader

        #region ExecuteNonQuery

        public int ExecuteNonQuery(string sqlText, MySqlParameter MySqlParameter)
        {
            return ExecuteNonQuery(sqlText, CommandType.Text, new MySqlParameter[] { MySqlParameter });
        }

        public int ExecuteNonQuery(string sqlText, IEnumerable<MySqlParameter> MySqlParameters)
        {
            return ExecuteNonQuery(sqlText, CommandType.Text, MySqlParameters);
        }

        public int ExecuteNonQuery(string sqlText, CommandType commandType, MySqlParameter MySqlParameter)
        {
            return ExecuteNonQuery(sqlText, commandType, new MySqlParameter[] { MySqlParameter });
        }

        public int ExecuteNonQuery(string sqlText, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            if (!string.IsNullOrEmpty(sqlText))
            {
                if (this.Transaction != null && this.Transaction.Transaction != null)
                {
                    return ExcutingWithTransactions(new TransactionPararms() { TPSqlString = sqlText, TPCommandType = commandType, MySqlParameters = MySqlParameters });
                }
                else
                {
                    return ExcutingWithOutTransactions(connectString, new TransactionPararms() { TPSqlString = sqlText, TPCommandType = commandType, MySqlParameters = MySqlParameters });
                }
            }
            else { return 0; }
        }

        private static int CommandExecuteNonQuery(MySqlConnection MySqlConnection, MySqlTransaction MySqlTransaction, string sqlText, CommandType commandType, IEnumerable<MySqlParameter> MySqlParameters)
        {
            using (MySqlCommand MySqlCommand = new MySqlCommand(sqlText, MySqlConnection, MySqlTransaction))
            {
                MySqlCommand.CommandType = commandType;
                if (MySqlParameters != null)
                {
                    foreach (MySqlParameter parameter in MySqlParameters)
                    {
                        MySqlCommand.Parameters.Add(parameter);
                    }
                }
                return MySqlCommand.ExecuteNonQuery();
            }
        }

        #endregion ExecuteNonQuery

        #region TransactionExecute

        public static bool ExcutingTransactions(string connectString, IEnumerable<TransactionPararms> TParameters)
        {
            using (MySqlConnection MySqlConnection = new MySqlConnection(connectString))
            {
                try
                {
                    MySqlConnection.Open();
                    using (MySqlTransaction MySqlTransaction = MySqlConnection.BeginTransaction())
                    {
                        try
                        {
                            MySqlCommand sqlCmd = MySqlConnection.CreateCommand();
                            sqlCmd.Connection = MySqlConnection;
                            sqlCmd.Transaction = MySqlTransaction;
                            foreach (TransactionPararms Item in TParameters)
                            {
                                sqlCmd.CommandText = Item.TPSqlString;
                                sqlCmd.CommandType = Item.TPCommandType;
                                foreach (MySqlParameter Ipara in Item.MySqlParameters)
                                {
                                    sqlCmd.Parameters.Add(Ipara);
                                }
                                sqlCmd.ExecuteNonQuery();
                            }
                            MySqlTransaction.Commit();
                            return true;
                        }
                        catch (Exception ex2)
                        {
                            try
                            {
                                MySqlTransaction.Rollback();
                                return false;
                            }
                            catch (Exception ex3)
                            {
                                throw ex3;
                            }
                            throw ex2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (MySqlConnection.State == ConnectionState.Open)
                        MySqlConnection.Close();
                    MySqlConnection.Dispose();
                }
            }
        }

        private int ExcutingWithTransactions(TransactionPararms tParameters)
        {
            MySqlTransaction sqlTrans = (MySqlTransaction)this.Transaction.Transaction;
            return CommandExecuteNonQuery(sqlTrans.Connection, sqlTrans, tParameters.TPSqlString, tParameters.TPCommandType, tParameters.MySqlParameters);
        }

        private int ExcutingWithOutTransactions(string connectString, TransactionPararms tParameters)
        {
            using (MySqlConnection MySqlConnection = new MySqlConnection(connectString))
            {
                MySqlConnection.Open();
                try
                {
                    using (MySqlTransaction MySqlTransaction = MySqlConnection.BeginTransaction())
                    {
                        try
                        {
                            int ReutnValue = CommandExecuteNonQuery(MySqlConnection, MySqlTransaction, tParameters.TPSqlString, tParameters.TPCommandType, tParameters.MySqlParameters);
                            MySqlTransaction.Commit();
                            return ReutnValue;
                        }
                        catch (MySqlException ex)
                        {
                            MySqlTransaction.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            MySqlTransaction.Dispose();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    MySqlConnection.Close();
                    MySqlConnection.Dispose();
                }
            }
        }

        #endregion TransactionExecute

        #region IDBHelper 成员

        public IDBTransaction BuildTransaction()
        {
            if (Transaction == null)
            {
                IDBTransaction dbTransaction = new DBTransaction();
                MySqlConnection sqlConn = new MySqlConnection(connectString);
                sqlConn.Open();
                dbTransaction.Transaction = sqlConn.BeginTransaction();
                this.Transaction = dbTransaction;
                return dbTransaction;
            }
            else
            {
                if (Transaction.Transaction == null)
                {
                    Transaction.Transaction = new MySqlConnection(connectString).BeginTransaction();
                    return Transaction;
                }
                else { return null; }
            }
        }

        public IDBTransaction Transaction { get; set; }

        #endregion IDBHelper 成员
    }
}