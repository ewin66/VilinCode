using System.Collections.Generic;

namespace JF.Common.Libary.NHibernate
{
    public interface ICommonDAO<T>
    {
        int Insert(T objectInfo);

        bool Insert(List<T> objectInfo);

        //bool Insert(List<T> objectInfo, ITransaction transaction);
        bool Update(T objectInfo);

        bool Delete(T objectInfo);

        bool Delete(List<T> objectInfo);

        //bool Delete(List<T> objectInfo, ITransaction transaction);
        T GetByID(object id);

        IList<T> GetAll();

        IList<T> Search(T objectInfo);

        IList<T> Search(string keywords);

        IList<T> Execute(string storageProcess);
    }
}