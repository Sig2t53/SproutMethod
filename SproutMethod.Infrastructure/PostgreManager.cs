using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutMethod.Infrastructure
{
    public class PostgreManager : IDataBaseManager,IDisposable
    {
        private NpgsqlConnection dbConnection;
        private IDbCommand dbCommand;
        private IDbTransaction dbTransaction;

        public PostgreManager()
        {

        }

        public void BeginTransaction()
        {

            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public ConnectionState State()
        {
            return dbConnection.State;
        }

        public void DatabaseOpen()
        {
            string connectionString = @"Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=sample"; ;
            dbConnection = new NpgsqlConnection(connectionString);
            dbConnection.Open();
        }

        public IReadOnlyList<T> ExecuteQuery<T>(string sql, Func<IDataReader, T> createEntity)
        {
            return ExecuteQuery(sql, null, createEntity);
        }

        public IReadOnlyList<T> ExecuteQuery<T>(string sql, IDataParameter dataParameter, Func<IDataReader, T> createEntity)
        {
            
            var command = new NpgsqlCommand(sql, dbConnection);
            if(dataParameter != null)
            {
                command.Parameters.Add(dataParameter);
            }

            var result = new List<T>();
            using (var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    result.Add(createEntity(reader));
                }
            }
            return result;
        }

        public int ExecuteUpdate(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteUpdate(string sql, IDataParameter dataParameter)
        {
            throw new NotImplementedException();
        }

        public bool Isbegin()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if(!dbConnection.State.Equals(ConnectionState.Closed))
            {
                dbConnection.Close();
            }
        }

    }
}
