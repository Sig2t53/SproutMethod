using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutMethod.Entities
{
    public class Entry
    {
        public int EntryId { get; }
        public string Memo { get; }
        public DateTime? _postDate;

        public Entry(int entryId, string memo) : this(entryId, memo, null) { }
        public Entry(int entryId,string memo, DateTime? postDate)
        {
            EntryId = entryId;
            Memo = memo;
            _postDate = postDate;
        }

        public DateTime? GetPostDate()
        {
            return _postDate;
        }

        public void setPostDate()
        {
            _postDate = DateTime.Now;
        }
    }
}