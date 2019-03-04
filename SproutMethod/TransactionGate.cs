using SproutMethod.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutMethod
{
    public class TransactionGate
    {
        TransactionBundle<Entry> transactionBundle = new TransactionBundle<Entry>();

        public void postEntries(List<Entry> entries)
        {
            foreach(Entry entry in entries)
            {
                entry.setPostDate();
            }
            transactionBundle.GetListManager().Add(entries);
        }
    }
}
