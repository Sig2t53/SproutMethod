using SproutMethod.Entities;
using SproutMethod.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutMethod.Infrastructure
{
    public class EntryPostgre : IEntryRepository
    {
        private IDataBaseManager _dataBaseManager;
        public EntryPostgre(IDataBaseManager dataBaseManager)
        {
            _dataBaseManager = dataBaseManager;
        }
        public IReadOnlyList<Entry> GetData()
        {
            string sql = @"SELECT id ,memo ,postdate FROM public.entry where id = 1";
            return _dataBaseManager.ExecuteQuery<Entry>(
                 sql
                , reader =>
                  {
                      return new Entry(
                        Convert.ToInt32(reader["id"])
                      , Convert.ToString(reader["memo"])
                      , Convert.ToDateTime(reader["postdate"])
                      );
                  }
                );
        }
    }
}
