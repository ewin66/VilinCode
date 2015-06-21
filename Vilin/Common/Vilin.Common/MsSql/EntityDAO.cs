using System;
using System.Data;
using System.Data.SqlClient;

namespace JF.Common.Libary.DataAccess
{
    [Serializable()]
    public abstract class EntityDAO : IEntityDAO
    {
        //find all records
        public virtual DataSet FindAll()
        {
            return null;
        }

        //add new record
        public virtual bool Insert()
        {
            return false;
        }

        //add new record,use transaction
        public virtual bool Insert(SqlTransaction transaction)
        {
            return false;
        }

        //modify record
        public virtual bool Update()
        {
            return false;
        }

        //modify record,use transaction
        public virtual bool Update(SqlTransaction transaction)
        {
            return false;
        }

        //delete record
        public virtual bool Delete()
        {
            return false;
        }

        //delete record,use transaction
        public virtual bool Delete(SqlTransaction transaction)
        {
            return false;
        }

        //dispose resource
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            //add your method
        }
    }
}