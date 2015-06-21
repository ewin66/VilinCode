using System;
using System.Data;
using System.Data.SqlClient;

namespace JF.Common.Libary.DataAccess
{
    /// <summary>
    /// IEntityDAO.interface.
    /// </summary>
    public interface IEntityDAO : IDisposable
    {
        //find all records
        DataSet FindAll();

        //add new record
        bool Insert();

        //add new record,use transaction
        bool Insert(SqlTransaction transaction);

        //modify record
        bool Update();

        //modify record,use transaction
        bool Update(SqlTransaction transaction);

        //delete record
        bool Delete();

        //delete record,use transaction
        bool Delete(SqlTransaction transaction);
    }
}