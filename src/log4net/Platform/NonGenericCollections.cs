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
    }

    public class Hashtable : Dictionary<object, object>
    {
    }

    public class Stack : Stack<object>
    {
        
    }
}
#endif