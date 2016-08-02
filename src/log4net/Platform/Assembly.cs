using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Reflection
{
    public class AssemblyUtils
    {
        public static Assembly GetCallingAssembly()
        {
#if COREFX
            return Assembly.GetEntryAssembly();
#else
            return Assembly.GetCallingAssembly();
#endif
        }
    }
}
