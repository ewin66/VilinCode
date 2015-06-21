using System;
using MySql.Data.MySqlClient;

namespace JF.Common.Libary.MySQL
{
    public class DBTransaction : IDBTransaction
    {
        private MySqlTransaction _sqlTransaction = null;

        public object Transaction
        {
            get { return _sqlTransaction; }
            set { _sqlTransaction = value as MySqlTransaction; }
        }

        public bool IsBeginning { get; set; }

        public void Commit()
        {
            if (_sqlTransaction != null)
            {
                _sqlTransaction.Commit();
                this.IsBeginning = false;
            }
        }

        public void Rollback()
        {
            if (_sqlTransaction != null)
            {
                _sqlTransaction.Rollback();
                this.IsBeginning = false;
            }
        }

        public event Action AfterCommit
        {
            add { }
            remove { }
        }

        public event Action AfterRollback
        {
            add { }
            remove { }
        }

        public void Dispose()
        {
            if (_sqlTransaction != null)
            {
                if (this.IsBeginning == true)
                    _sqlTransaction.Rollback();
            }
            _sqlTransaction.Dispose();
        }
    }
}