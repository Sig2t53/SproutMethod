using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutMethod
{
    public class ListManager<T>
    {
        private List<T> list;
        public ListManager()
        {
            list = new List<T>();
        }

        public void Add(List<T> addList)
        {
            list.AddRange(addList);
        }

    }
}
