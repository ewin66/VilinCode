using System;

namespace JF.Common.Libary.MySQL
{
    public interface IDBTransaction : IDisposable
    {
        object Transaction { get; set; }

        bool IsBeginning { get; set; }

        void Commit();

        void Rollback();

        event Action AfterCommit;

        event Action AfterRollback;
    }

    public interface IDBTransaction<T> : IDBTransaction
    {
        T Connection { get; }
    }
}