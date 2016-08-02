using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Reflection
{
    public static class ReflectionExtensions
    {
        public static Type GetBaseType(this Type obj)
        {
#if COREFX
            return obj.GetTypeInfo().BaseType;
#else
            return obj.BaseType;
#endif
        }

        public static Assembly GetAssembly(this Type t)
        {
#if COREFX
            return t.GetTypeInfo().Assembly;
#else
            return t.Assembly;
#endif

        }
    }
}
