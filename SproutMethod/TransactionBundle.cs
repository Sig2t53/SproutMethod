using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutMethod
{
    public class TransactionBundle<T>
    {
        private ListManager<T> lm;
        public ListManager<T> GetListManager()
        {
            if(lm == null)
            {
                lm = new ListManager<T>();
            }
            return lm;
        }
    }
}
