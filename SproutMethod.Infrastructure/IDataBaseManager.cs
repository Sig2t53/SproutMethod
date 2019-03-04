using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutMethod.Infrastructure
{
    public interface IDataBaseManager
    {

        void DatabaseOpen();
        IReadOnlyList<T> ExecuteQuery<T>(string sql,Func<IDataReader,T> createEntity);
        IReadOnlyList<T> ExecuteQuery<T>(string sql, IDataParameter dataParameter, Func<IDataReader, T> createEntity);
        bool Isbegin();
        void BeginTransaction();
        void Commit();
        void Rollback();
        int  ExecuteUpdate(string sql);
        int  ExecuteUpdate(string sql,IDataParameter dataParameter);
    }
}
