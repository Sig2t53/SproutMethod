using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SproutMethod.Entities;
using SproutMethod.Infrastructure;

namespace SproutMethodTest
{
    [TestClass]
    public class PostgreManagerTest
    {
        [TestMethod]
        public void データベースに接続する()
        {
            PostgreManager pgMgr = new PostgreManager();
            pgMgr.DatabaseOpen();
            Assert.AreEqual(ConnectionState.Open, pgMgr.State());
        }

        [TestMethod]
        public void データベースから値を取得する()
        {
            PostgreManager pgMgr = new PostgreManager();
            pgMgr.DatabaseOpen();
            EntryPostgre entryPg = new EntryPostgre(pgMgr);
            IReadOnlyList<Entry> list = entryPg.GetData();
            Assert.AreEqual(1, list.Count);
            foreach(Entry entry in list)
            {
                Assert.AreEqual(1, entry.EntryId);
                Assert.AreEqual("aaa", entry.Memo);
                Assert.AreEqual(Convert.ToDateTime("2018-01-20 00:00:00"), entry.GetPostDate());
            }
        }
    }
}
