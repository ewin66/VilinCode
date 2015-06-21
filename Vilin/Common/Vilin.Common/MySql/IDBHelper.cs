namespace JF.Common.Libary.MySQL
{
    public interface IDBHelper
    {
        IDBTransaction BuildTransaction();

        IDBTransaction Transaction { get; set; }
    }
}