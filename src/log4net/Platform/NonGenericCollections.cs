#if COREFX
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Collections
{
    public class ArrayList : List<object>
    {
        public ArrayList() : base()
        {

        }

        public ArrayList(int capacity) : base(capacity)
        {

        }

        public object SyncRoot => this.GetSyncRoot();
    }

    public class Hashtable : Dictionary<object, object>
    {
        public Hashtable()
        {

        }

        public Hashtable(int capacity) : base(capacity)
        {

        }

        public Hashtable(IEqualityComparer<object> comparer) : base(comparer)
        {
        }

        public bool Contains(object key) => ContainsKey(key);

        public bool IsSynchronized => true;

        public bool IsFixedSize => false;

        internal void CopyTo(Array array, int index)
        {
            foreach (var item in this)
            {
                array.SetValue(item.Value, index++);
            }
        }

        internal static Hashtable Synchronized(Hashtable hashtable)
        {
            var h = new Hashtable();
            foreach(var kvp in hashtable)
            {
                h.Add(kvp.Key, kvp.Value);
            }
            return h;
        }
    }

    public class CaseInsensitiveHashtable : Hashtable
    {
        public CaseInsensitiveHashtable() : base(new CaseInsensitiveComparer())
        {
            
        }

        public class CaseInsensitiveComparer : IEqualityComparer<string>, IEqualityComparer<object>
        {
            public bool Equals(string x, string y)
            {
                return x.Equals(y, StringComparison.CurrentCultureIgnoreCase);
            }

            public int GetHashCode(string obj)
            {
                return obj.ToLower().GetHashCode();
            }

            bool IEqualityComparer<object>.Equals(object x, object y)
            {
                return this.Equals((string)x, (string)y);
            }

            int IEqualityComparer<object>.GetHashCode(object obj)
            {
                return this.GetHashCode((string)obj);
            }
        }
    }

    public class Stack : Stack<object>
    {
        public Stack()
        {

        }
        public Stack(IEnumerable<object> collection) : base(collection)
        {
        }
    }
}
#endif