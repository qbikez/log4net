using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static bool IsEnumerable(this Type t)
        {
#if COREFX
            return t.GetTypeInfo().IsEnum;
#else
            return t.IsEnum;
#endif
        }

#if COREFX
        public static bool IsSubclassOf(this Type t, Type other)
        {
            return t.GetTypeInfo().IsSubclassOf(other);
        }

        public static IEnumerable<Attribute> GetCustomAttributes(this Type t)
        {
            return t.GetTypeInfo().GetCustomAttributes();
        }
        public static object[] GetCustomAttributes(this Type t, Type attributeType, bool inherit)
        {
            return t.GetTypeInfo().GetCustomAttributes(attributeType, inherit).ToArray();
        }

        public static object Invoke(this MethodBase b, object obj, BindingFlags flags, object someAttr, object[] parameters, CultureInfo cultures)
        {
            return b.Invoke(obj, parameters);
        }
#endif
    }
}
